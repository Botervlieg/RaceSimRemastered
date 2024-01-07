using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class Race
    {
        public Track Track { get; set; }
        public List<IParticipant> Participants { get; set; }
        public DateTime StartTime { get; set; }
        private Random _random;
        private Dictionary<Section, SectionData> _positions;


        public Race(Track track, List<IParticipant> participants)
        {
            Track = track;
            Participants = participants;
            _positions = new Dictionary<Section, SectionData>();
            _random = new Random(DateTime.Now.Millisecond);
            RandomizeEquipment();
            PlaceParticipants();
        }

        public SectionData GetSectionData(Section section)
        {
            if(!_positions.ContainsKey(section))
            {
                _positions.Add(section, new SectionData());
            }
            return _positions[section];
        }

        public void RandomizeEquipment()
        {
            foreach (IParticipant participant in Participants)
            {
                participant.Equipment.Quality = _random.Next(5, 11);
                participant.Equipment.Performance = _random.Next(5, 11);
            }
        }

        public void PlaceParticipants()
        {
            foreach(IParticipant participant in Participants)
            {
                foreach(Section section in Track.Sections)
                {
                    if(section.SectionType == SectionTypes.StartGrid)
                    {
                        SectionData sectionData = GetSectionData(section);
                        if(sectionData.Left == null)
                        {
                            sectionData.Left = participant;
                            break;
                        }
                        else if(sectionData.Right == null)
                        {
                            sectionData.Right = participant;
                            break;
                        } 
                    } 
                }   
            }
        }
    }
}
