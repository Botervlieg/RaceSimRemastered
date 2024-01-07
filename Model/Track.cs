using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Track
    {
        public string Name { get; set; }
        public LinkedList<Section> Sections { get; set; }

        public Track(string name, SectionTypes[] sections)
        {
            Name = name;
            Sections = GetSectionsFromArray(sections);
        }

        public LinkedList<Section> GetSectionsFromArray(SectionTypes[] sections)
        {
            LinkedList<Section> result = new LinkedList<Section>();
            foreach (SectionTypes section in sections)
            {
                result.AddLast(new Section(section));
            }
            return result;
        }
    }
}
