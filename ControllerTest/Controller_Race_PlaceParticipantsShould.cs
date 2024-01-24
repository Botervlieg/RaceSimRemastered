using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerTest
{
    public class Controller_Race_PlaceParticipantsShould
    {
        private Race _race;

        [Test]
        public void PlaceParticipants_StartGrid_PlaceParticipants_ReturnParticipants()
        {
            List<IParticipant> participants = new List<IParticipant>();
            participants.Add(new Driver("John", 0, new Car(), TeamColors.Yellow));
            participants.Add(new Driver("Jane", 0, new Car(), TeamColors.Blue));
            _race = new Race(new Track("Test Track", new SectionTypes[] { SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.RightCorner, SectionTypes.RightCorner, SectionTypes.Finish }), participants);

            Section section = _race.Track.Sections.First();
            SectionData data = _race.GetSectionData(section);
            Assert.AreEqual(_race.Participants[0], data.Left);
            Assert.AreEqual(_race.Participants[1], data.Right);
        }

        [Test]
        public void PlaceParticipants_StartGrid_PlaceParticipants_RightIsNull()
        {
            List<IParticipant> participants = new List<IParticipant>();
            participants.Add(new Driver("John", 0, new Car(), TeamColors.Yellow));
            _race = new Race(new Track("Test Track", new SectionTypes[] { SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.RightCorner, SectionTypes.RightCorner, SectionTypes.Finish }), participants);

            Section section = _race.Track.Sections.First();
            SectionData data = _race.GetSectionData(section);
            Assert.AreEqual(_race.Participants[0], data.Left);
            Assert.AreEqual(null, data.Right);
        }


    }
}
