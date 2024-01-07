using Model;

namespace ControllerTest
{
    [TestFixture]
    public class Model_Competition_NextTrackShould
    {
        private Competition _competition;

        [SetUp]
        public void SetUp()
        {
            _competition = new Competition();
        }

        [Test]
        public void NextTrack_EmptyQueue_ReturnNull()
        {
            Track result = _competition.NextTrack();
            Assert.IsNull(result);
        }

        [Test]
        public void NextTrack_OneInQueue_ReturnTrack()
        {
            Track track = new Track("test", new SectionTypes[] { SectionTypes.StartGrid });
            _competition.Tracks.Enqueue(track);
            Track result = _competition.NextTrack();
            Assert.AreEqual(track, result);
        }

        [Test]
        public void NextTrack_OneInQueue_RemoveTrackFromQueue()
        {
            Track track = new Track("test", new SectionTypes[] { SectionTypes.StartGrid });
            _competition.Tracks.Enqueue(track);
            Track result = _competition.NextTrack();
            result = _competition.NextTrack();
            Assert.AreEqual(null, result);
        }

        [Test]
        public void NextTrack_TwoInQueue_ReturnNextTrack()
        {
            Track track1 = new Track("test1", new SectionTypes[] { SectionTypes.StartGrid });
            Track track2 = new Track("test2", new SectionTypes[] { SectionTypes.StartGrid });
            _competition.Tracks.Enqueue(track1);
            _competition.Tracks.Enqueue(track2);
            Track result = _competition.NextTrack();
            Track result2 = _competition.NextTrack();
            Assert.AreEqual(track1, result);
            Assert.AreEqual(track2, result2);
        }


    }
}
