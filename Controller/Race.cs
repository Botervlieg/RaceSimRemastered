using Model;

namespace Controller
{
    public class Race
    {
        public Track Track { get; set; }
        public List<IParticipant> Participants { get; set; }
        public DateTime StartTime { get; set; }
        private Random _random;
        private Dictionary<Section, SectionData> _positions;
        private System.Timers.Timer _timer;
        public int finished = 0;
        public int PlacementPoints;

        public event EventHandler<DriversChangedEventArgs> DriversChanged;
        public event EventHandler<EventArgs> RaceEnded;


        public Race(Track track, List<IParticipant> participants)
        {
            PlacementPoints = participants.Count;
            Track = track;
            Participants = participants;
            _positions = new Dictionary<Section, SectionData>();
            _random = new Random(DateTime.Now.Millisecond);
            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += OnTimedEvent;
            RandomizeEquipment();
            PlaceParticipants();
            Start();
        }

        public void OnTimedEvent(object source, EventArgs e)
        {
            FixEquipment();
            BreakEquipment();
            Move();
            if (DriversChanged != null)
            {
                DriversChanged.Invoke(this, new DriversChangedEventArgs(Track));
            }
            
        }

        public void Debug()
        {
            Move();
            DriversChanged.Invoke(this, new DriversChangedEventArgs(Track));
            Debug();
        }

        private void BreakEquipment()
        {
            foreach (IParticipant participant in Participants)
            {
                if (!participant.Equipment.IsBroken)
                {
                    if (_random.Next(1, participant.Equipment.Quality) == 1)
                    {
                        participant.Equipment.Speed = 1;
                        participant.Equipment.IsBroken = true;
                    }
                }
            }
        }

        private void FixEquipment()
        {
            foreach (IParticipant participant in Participants)
            {
                if (participant.Equipment.IsBroken)
                {
                    if(_random.Next(1, 10) == 1)
                    {
                        participant.Equipment.IsBroken = false;
                    }
                }
            }
        }

        private void Move()
        {
            foreach (IParticipant participant in Participants)
            {
                if (!participant.Equipment.IsBroken && !participant.IsFinished)
                {
                    participant.Distance += (participant.Equipment.Speed * participant.Equipment.Performance);
                    participant.TotalDistance += (participant.Equipment.Speed * participant.Equipment.Performance);
                    if (participant.Equipment.Speed < 20)
                    {
                        participant.Equipment.Speed += 2;
                    }
                    if (participant.Distance > 100)
                    {
                        participant.Distance -= 100;
                        MoveSection(participant);
                    }
                }
            }
        }

        private void MoveSection(IParticipant participant)
        {
            LinkedListNode<Section> section = Track.Sections.First;

            bool done = false;

            while (section != null)
            {
                SectionData data = GetSectionData(section.Value);
                if (data.Left == participant)
                {
                    SectionData nextSectionData = GetSectionData(GetNextSection(section).Value);
                    if (nextSectionData.Left == null)
                    {
                        nextSectionData.Left = participant;
                        data.Left = null;
                        done = true;
                    }
                    else if (nextSectionData.Right == null)
                    {
                        nextSectionData.Right = participant;
                        data.Left = null;
                        done = true;
                    }

                }
                else
                if (data.Right == participant)
                {
                    SectionData nextSectionData = GetSectionData(GetNextSection(section).Value);
                    if (nextSectionData.Left == null)
                    {
                        nextSectionData.Left = participant;
                        data.Right = null;
                        done = true;
                    }
                    else if (nextSectionData.Right == null)
                    {
                        nextSectionData.Right = participant;
                        data.Right = null;
                        done = true;
                    }
                }

                if (done)
                {
                    if (section.Value.SectionType == SectionTypes.Finish)
                    {
                        NextLap(participant, section.Next.Value);
                    }
                    return;
                }
                if (section.Next != null)
                {
                    section = section.Next;
                }
                else
                {
                    return;
                }
            }
        }

        private void NextLap(IParticipant participant, Section section)
        {
            participant.Lap++;
            if (participant.Lap >= 1)
            {
                participant.IsFinished = true;
                participant.Points += PlacementPoints;
                PlacementPoints--;
                finished++;
                SectionData data = GetSectionData(section);
                if (data.Left == participant)
                {
                    data.Left = null;
                }
                if (data.Right == participant)
                {
                    data.Right = null;
                }
                if (finished == Participants.Count)
                {
                    StopRace();
                    PlacementPoints = Participants.Count;
                }
            }
        }

        private LinkedListNode<Section> GetNextSection(LinkedListNode<Section> section)
        {
            if (section.Next == null)
            {
                return Track.Sections.First;
            }
            else
            {
                return section.Next;
            }

        }




        public SectionData GetSectionData(Section section)
        {
            if (!_positions.ContainsKey(section))
            {
                _positions.Add(section, new SectionData());
            }
            return _positions[section];
        }

        public void RandomizeEquipment()
        {
            foreach (IParticipant participant in Participants)
            {
                participant.Equipment.Quality = _random.Next(20, 50);
                participant.Equipment.Performance = _random.Next(3, 5);
                participant.Equipment.Speed = _random.Next(5, 20);
            }
        }

        public void PlaceParticipants()
        {
            foreach (IParticipant participant in Participants)
            {
                foreach (Section section in Track.Sections)
                {
                    if (section.SectionType == SectionTypes.StartGrid)
                    {
                        SectionData sectionData = GetSectionData(section);
                        if (sectionData.Left == null)
                        {
                            sectionData.Left = participant;
                            break;
                        }
                        else if (sectionData.Right == null)
                        {
                            sectionData.Right = participant;
                            break;
                        }
                    }
                }
            }
        }

        private void CleanUp()
        {
            foreach (IParticipant participant in Participants)
            {
                participant.IsFinished = false;
                participant.Distance = 0;
                participant.Lap = 0;
            }
            DriversChanged = null;
            finished = 0;
        }

        public void Start()
        {
            _timer.Start();
        }

        public void StopRace()
        {
            _timer.Stop();
            CleanUp();
            Data.NextRace();
            RaceEnded.Invoke(this, new EventArgs());
            Start();
        }
    }
}
