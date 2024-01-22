using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RaceEndedEventArgs
    {
        public Track Track {  get; set; }

        public RaceEndedEventArgs(Track track)
        {
            Track = track;
        }
    }
}
