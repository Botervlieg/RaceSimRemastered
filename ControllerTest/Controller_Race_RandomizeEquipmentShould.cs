using Controller;
using Model;
using NUnit.Framework;
using System.Collections.Generic;

namespace ControllerTest
{
    [TestFixture]
    public class Controller_RandomizeEquipmentShould
    {
        private Race _race;

        [SetUp]
        public void SetUp()
        {
            List<IParticipant> participants = new List<IParticipant>();
            participants.Add(new Driver("John", 0, new Car(), TeamColors.Yellow));
            participants.Add(new Driver("Jane", 0, new Car(), TeamColors.Blue));
            participants.Add(new Driver("Jack", 0, new Car(), TeamColors.Grey));

            _race = new Race(new Track("Test Track", new SectionTypes[] { SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.RightCorner, SectionTypes.RightCorner, SectionTypes.Finish }), participants);
        }

        [Test]
        public void RandomizeEquipment_SetQuality()
        {
            _race.RandomizeEquipment();
            Assert.IsTrue(_race.Participants.First().Equipment.Quality >= 20 && _race.Participants.First().Equipment.Quality <= 50);
            Assert.IsTrue(_race.Participants.Last().Equipment.Quality >= 20 && _race.Participants.Last().Equipment.Quality <= 50);
        }

        [Test]
        public void RandomizeEquipment_SetPerformance()
        {
            _race.RandomizeEquipment();
            Assert.IsTrue(_race.Participants.First().Equipment.Performance >= 3 && _race.Participants.First().Equipment.Performance <= 5);
            Assert.IsTrue(_race.Participants.Last().Equipment.Performance >= 3 && _race.Participants.Last().Equipment.Performance <= 5);
        }

        [Test]
        public void RandomizeEquipment_SetSpeed()
        {
            _race.RandomizeEquipment();
            Assert.IsTrue(_race.Participants.First().Equipment.Speed >= 5 && _race.Participants.First().Equipment.Speed <= 20);
            Assert.IsTrue(_race.Participants.Last().Equipment.Speed >= 5 && _race.Participants.Last().Equipment.Speed <= 20);
        }
    }
}
