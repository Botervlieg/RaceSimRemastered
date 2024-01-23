using Controller;
using Model;

namespace RaceSimRemastered
{
    public static class Visuals
    {

        private static directions _direction;
        private static int _x;
        private static int _y;
        private static Race CurrentRace;

        public static void Initialize(Race race)
        {
            Data.CurrentRace.DriversChanged += OnDriversChanged;
            Data.CurrentRace.RaceEnded += OnRaceEnd;

            _direction = directions.East;
            _x = 30;
            _y = 30;
            CurrentRace = race;
            Console.BufferHeight = 1000;
            Console.BufferWidth = 1000;
        }


        public static void DrawTrack()
        {
            Track track = CurrentRace.Track;
            foreach (Section section in track.Sections)
            {
                switch (section.SectionType)
                {
                    case SectionTypes.StartGrid:
                        DrawSection((_direction == directions.East || _direction == directions.West)
                            ? _startGridHorizontal : _startGridVertical, CurrentRace.GetSectionData(section));
                        break;
                    case SectionTypes.Finish:
                        DrawSection((_direction == directions.East || _direction == directions.West)
                            ? _finishHorizontal : _finishVertical, CurrentRace.GetSectionData(section));
                        break;
                    case SectionTypes.Straight:
                        DrawSection((_direction == directions.East || _direction == directions.West)
                            ? _straigthHorizontal : _straigthVertical, CurrentRace.GetSectionData(section));
                        break;
                    case SectionTypes.LeftCorner:
                        switch (_direction)
                        {
                            case directions.North:
                                _direction = directions.West;
                                DrawSection(_cornerTopRight, CurrentRace.GetSectionData(section));
                                break;
                            case directions.East:
                                _direction = directions.North;
                                DrawSection(_cornerBottomRight, CurrentRace.GetSectionData(section));
                                break;
                            case directions.South:
                                _direction = directions.East;
                                DrawSection(_cornerBottomLeft, CurrentRace.GetSectionData(section));
                                break;
                            case directions.West:
                                _direction = directions.South;
                                DrawSection(_cornerTopLeft, CurrentRace.GetSectionData(section));
                                break;
                        }
                        break;
                    case SectionTypes.RightCorner:
                        switch (_direction)
                        {
                            case directions.North:
                                _direction = directions.East;
                                DrawSection(_cornerTopLeft, CurrentRace.GetSectionData(section));
                                break;
                            case directions.East:
                                _direction = directions.South;
                                DrawSection(_cornerTopRight, CurrentRace.GetSectionData(section));
                                break;
                            case directions.South:
                                _direction = directions.West;
                                DrawSection(_cornerBottomRight, CurrentRace.GetSectionData(section));
                                break;
                            case directions.West:
                                _direction = directions.North;
                                DrawSection(_cornerBottomLeft, CurrentRace.GetSectionData(section));
                                break;
                        }
                        break;
                }
            }
        }

        public static void DrawSection(string[] section, SectionData data)
        {
            int tempy = _y;
            string[] temp = new string[section.Length];
            if (data.Right != null && data.Left != null)
            {
                temp = DrawParticipants(section, data.Left, data.Right);
            }
            else if (data.Left != null)
            {
                temp = DrawLeftParticipants(section, data.Left);
            }
            else if (data.Right != null)
            {
                temp = DrawRightParticipants(section, data.Right);
            } else
            {
                for (int i = 0; i < section.Length; i++)
                {
                    temp[i] = section[i];
                }
            }
            //else
            //{
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = temp[i].Replace("1", " ").Replace("2", " ");
                }
            //}


            foreach (string line in temp)
            {
                Console.SetCursorPosition(_x, tempy);
                Console.Write(line);
                tempy++;
            }
            switch (_direction)
            {
                case directions.North:
                    _y -= 5;
                    break;
                case directions.East:
                    _x += 5;
                    break;
                case directions.South:
                    _y += 5;
                    break;
                case directions.West:
                    _x -= 5;
                    break;
            }
        }

        public static string[] DrawLeftParticipants(string[] section, IParticipant p1)
        {
            string[] temp = new string[section.Length];
            for (int i = 0; i < section.Length; i++)
            {
                temp[i] = section[i];
            }
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = p1.Equipment.IsBroken ? temp[i].Replace("1", "#") : temp[i].Replace("1", p1.Name[0].ToString());
            }
            return temp;
        }

        public static string[] DrawRightParticipants(string[] section, IParticipant p1)
        {
            string[] temp = new string[section.Length];
            for (int i = 0; i < section.Length; i++)
            {
                temp[i] = section[i];
            }
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = p1.Equipment.IsBroken ? temp[i].Replace("2", "#") : temp[i].Replace("2", p1.Name[0].ToString());
            }
            return temp;
        }

        public static string[] DrawParticipants(string[] section, IParticipant p1, IParticipant p2)
        {
            string[] temp = new string[section.Length];
            for (int i = 0; i < section.Length; i++)
            {
                temp[i] = section[i];
            }
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = p1.Equipment.IsBroken ? temp[i].Replace("1", "#") : temp[i].Replace("1", p1.Name[0].ToString());
                temp[i] = p2.Equipment.IsBroken ? temp[i].Replace("2", "#") : temp[i].Replace("2", p2.Name[0].ToString());
            }
            return temp;
        }

        public static void OnDriversChanged(object source, DriversChangedEventArgs e)
        {
            DrawTrack();
        }

        public static void OnRaceEnd(object source, EventArgs e)
        {
            Console.Clear();
            Initialize(Data.CurrentRace);
        }

        #region graphics

        private static string[] _finishHorizontal = {"-----",
                                                     "  1  ",
                                                     "  !  ",
                                                     "  2  ",
                                                     "-----"};

        private static string[] _finishVertical = {"|   |",
                                                   "|   |",
                                                   "|1!2|",
                                                   "|   |",
                                                   "|   |"};

        private static string[] _startGridHorizontal = {"-----",
                                                        "  1  ",
                                                        "  *  ",
                                                        "  2  ",
                                                        "-----"};

        private static string[] _startGridVertical = {"|   |",
                                                      "|   |",
                                                      "|1*2|",
                                                      "|   |",
                                                      "|   |"};

        private static string[] _straigthHorizontal = {"-----",
                                                       "  1  ",
                                                       "     ",
                                                       "  2  ",
                                                       "-----"};

        private static string[] _straigthVertical = {"|   |",
                                                     "|   |",
                                                     "|1 2|",
                                                     "|   |",
                                                     "|   |"};

        private static string[] _cornerTopRight = {"----\\",
                                                   "   1|",
                                                   "    |",
                                                   " 2  |",
                                                   "\\   |" };

        private static string[] _cornerBottomLeft = {"|   \\",
                                                   "|  1 ",
                                                   "|    ",
                                                   "|2   ",
                                                   "\\----"};

        private static string[] _cornerBottomRight = {"/   |",
                                                "2   |",
                                                "    |",
                                                "   1|",
                                                "----/"};

        private static string[] _cornerTopLeft = {"/----",
                                                  "|1   ",
                                                  "|    ",
                                                  "|  2 ",
                                                  "|   /" };

        #endregion

    }

    public enum directions
    {
        North,
        East,
        South,
        West
    }
}
