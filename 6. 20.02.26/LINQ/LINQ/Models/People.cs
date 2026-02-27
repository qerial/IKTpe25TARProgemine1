namespace LINQ.Models

{ 
        namespace LINQ.Models
    {
        public class People
        {
            public static readonly List<PeopleList> peoples = new List<PeopleList>
        {
            new PeopleList()
            {
                Id = 1,
                Name = "Toomas",
                Age = 27,
                GenderId = Guid.Parse("4292babd-92d7-4008-9b7d-574cf76e24cd")
            },
            new PeopleList()
            {
                Id = 2,
                Name = "Mark",
                Age = 83,
                GenderId = Guid.Parse("4292babd-92d7-4008-9b7d-574cf76e24cd")
            },
            new PeopleList()
            {
                Id = 3,
                Name = "Lauri",
                Age = 19,
                GenderId = Guid.Parse("4292babd-92d7-4008-9b7d-574cf76e24cd")
            },
            new PeopleList()
            {
                Id = 4,
                Name = "Franco",
                Age = 31,
                GenderId = Guid.Parse("4292babd-92d7-4008-9b7d-574cf76e24cd")
            },
            new PeopleList()
            {
                Id = 5,
                Name = "Mari",
                Age = 19,
                GenderId = Guid.Parse("37b4d908-0d23-4eda-b422-b7643deb84f9")
            },
            new PeopleList()
            {
                Id = 6,
                Name = "Mari",
                Age = 21,
                GenderId = Guid.Parse("37b4d908-0d23-4eda-b422-b7643deb84f9")
            },
            new PeopleList()
            {
                Id = 7,
                Name = "William",
                Age = 21,
                GenderId = Guid.Parse("4292babd-92d7-4008-9b7d-574cf76e24cd")
            },
        };

        }
    }
}

