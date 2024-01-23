using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public static class Data
    {
        public static Competition Competition;
        public static Race CurrentRace;

        public static void initialize()
        {
            Competition = new Competition();
            AddParticipants();
            AddTracks();
        }

        public static void NextRace()
        {
            Track track = Competition.NextTrack();
            if (track != null)
            {
                CurrentRace = new Race(track, Competition.Participants);
                return;
            }
        }

        public static void AddParticipants()
        {
            Competition.Participants.Add(new Driver("piet", 0, new Car(), TeamColors.Red));
            Competition.Participants.Add(new Driver("henk", 0, new Car(), TeamColors.Blue));
            Competition.Participants.Add(new Driver("jan", 0, new Car(), TeamColors.Green));
            Competition.Participants.Add(new Driver("willem", 0, new Car(), TeamColors.Yellow));
        }

        public static void AddTracks()
        {
            Competition.Tracks.Enqueue(new Track("track1", new SectionTypes[]
            {
                SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.Finish ,SectionTypes.RightCorner,
                SectionTypes.RightCorner,SectionTypes.LeftCorner, SectionTypes.LeftCorner, SectionTypes.Straight,
                SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.LeftCorner,
                SectionTypes.RightCorner, SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.Straight,
                SectionTypes.Straight, SectionTypes.Straight, SectionTypes.LeftCorner,  SectionTypes.Straight,
                SectionTypes.LeftCorner, SectionTypes.Straight
            }));

            Competition.Tracks.Enqueue(new Track("track2", new SectionTypes[]
            {
                SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.Finish ,SectionTypes.Straight,
                SectionTypes.RightCorner,SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight,
                SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight,
                SectionTypes.Straight, SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.Straight,
                SectionTypes.Straight, SectionTypes.RightCorner
            }));

            Competition.Tracks.Enqueue(new Track("track3", new SectionTypes[]
            {
                SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.Finish ,SectionTypes.RightCorner,
                SectionTypes.RightCorner,SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight,
                SectionTypes.RightCorner, SectionTypes.RightCorner
            }));





            
        }
    }
}
