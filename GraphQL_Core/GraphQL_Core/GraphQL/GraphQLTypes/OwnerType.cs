using GraphQL.Types;
using GraphQL_Core.Entities;

namespace GraphQL_Core.GraphQL.GraphQLTypes
{
    public class OwnerType : ObjectGraphType<Owner>
    {
        public OwnerType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id Property from the owner object");
            Field(x => x.Name).Description("Name Property from the owner object");
            Field(x => x.Address).Description("Address Property from the owner object");
        }
    }
}
