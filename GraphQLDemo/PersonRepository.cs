using System.Collections.Generic;
using System.Linq;
using GraphQLDemo.Models;

namespace GraphQLDemo
{
    public class PersonRepository : IPersonRepository
    {
        private readonly Person[] _people;

        public PersonRepository()
        {
            Person[] friends = {
                new Person{Id = 4, Email = "friend1@email.com", Name = "Friend 1"},
                new Person{Id = 5, Email = "friend2@email.com", Name = "Friend 2"},
                new Person{Id = 6, Email = "friend3@email.com", Name = "Friend 3"},
            };

            _people = new[]
               {
                new Person{Id = 1, Email = "joe@email.com", Name = "Joe", Friends = friends},
                new Person{Id = 2, Email = "will@email.com", Name = "Will", Friends = friends},
                new Person{Id = 3, Email = "sam@email.com", Name = "Sam", Friends = friends}
               };
        }
        public IEnumerable<Person> GetAll()
        {
            return _people;
        }

        public Person GetOne(int id)
        {
            return _people.Single(p => p.Id == id);
        }
    }
}
