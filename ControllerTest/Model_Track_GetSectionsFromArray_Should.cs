using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerTest
{
    public class Model_Track_GetSectionsFromArray_Should
    {
        private Track _track;

        [SetUp]
        public void SetUp()
        {
            _track = new Track("Test Track", new SectionTypes[] { SectionTypes.StartGrid, SectionTypes.RightCorner, SectionTypes.Finish });
        }

        [Test]
        public void GetSectionsFromArray_ValidArray_ReturnLinkedListOfSections()
        {
            LinkedList<Section> sections = _track.GetSectionsFromArray(new SectionTypes[] { SectionTypes.StartGrid, SectionTypes.RightCorner, SectionTypes.Finish });
            Assert.IsNotNull(sections);
            Assert.IsTrue(sections.Count == 3);
            Assert.AreEqual(sections.First.Value.SectionType, SectionTypes.StartGrid);
            Assert.AreEqual(sections.Last.Value.SectionType, SectionTypes.Finish);
        }

        [Test]
        public void GetSectionsFromArray_EmptyArray_ReturnEmptyLinkedList()
        {
            LinkedList<Section> sections = _track.GetSectionsFromArray(new SectionTypes[] { });
            Assert.IsNotNull(sections);
            Assert.IsTrue(sections.Count == 0);
        }

        [Test]
        public void GetSectionsFromArray_NullArray_ThrowArgumentNullException()
        {
            Assert.Throws<NullReferenceException>(() => _track.GetSectionsFromArray(null));
        }



    }
}
