using GraphQL.Types;

namespace GraphQLDemo.Models
{
    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Email);
            Field<ListGraphType<PersonType>>("friends");
        }
    }
}
