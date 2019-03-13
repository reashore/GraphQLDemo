using System.Collections.Generic;

namespace GraphQLDemo.Models
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person GetOne(int id);
    }
}
