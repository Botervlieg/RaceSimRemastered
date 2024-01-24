using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Driver : IParticipant
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public IEquipment Equipment { get; set; }
        public TeamColors TeamColor { get; set; }
        public int Distance { get; set; }
        public int TotalDistance { get; set; }
        public int Lap {  get; set; }
        public bool IsFinished { get; set; }

        public Driver(string name, int points, IEquipment equipment, TeamColors teamColor)
        {
            Name = name;
            Points = points;
            Equipment = equipment;
            TeamColor = teamColor;
            TotalDistance = 0;
            Distance = 0;
            Lap = 0;
            IsFinished = false;
        }

    }
}
