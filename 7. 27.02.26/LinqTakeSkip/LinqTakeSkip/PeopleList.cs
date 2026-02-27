using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTakeSkip
{
    public class PeopleList
    {
        public static readonly List<People> people = new List<People>
        {
            new People()
            {
                Id = 1,
                Name = "Toomas",
                Age = 27,
                GenderId = Guid.Parse("4292babd-92d7-4008-9b7d-574cf76e24cd")
            },
            new People()
            {
                Id = 2,
                Name = "Mark",
                Age = 83,
                GenderId = Guid.Parse("4292babd-92d7-4008-9b7d-574cf76e24cd")
            },
            new People()
            {
                Id = 3,
                Name = "Lauri",
                Age = 19,
                GenderId = Guid.Parse("4292babd-92d7-4008-9b7d-574cf76e24cd")
            },
            new People()
            {
                Id = 4,
                Name = "Franco",
                Age = 21,
                GenderId = Guid.Parse("4292babd-92d7-4008-9b7d-574cf76e24cd")
            },
            new People()
            {
                Id = 5,
                Name = "Mari",
                Age = 21,
                GenderId = Guid.Parse("37b4d908-0d23-4eda-b422-b7643deb84f9")
            },
            new People()
            {
                Id = 6,
                Name = "Marelle",
                Age = 16,
                GenderId = Guid.Parse("37b4d908-0d23-4eda-b422-b7643deb84f9")
            },
            new People()
            {
                Id = 7,
                Name = "Hugo",
                Age = 36,
                GenderId = Guid.Parse("4292babd-92d7-4008-9b7d-574cf76e24cd")
            },
        };

    }
}
