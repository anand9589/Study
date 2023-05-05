using GraphQL.Types;
using GraphQL_Core.Contracts;
using GraphQL_Core.Entities;
using GraphQL_Core.GraphQL.GraphQLTypes;

namespace GraphQL_Core.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IOwnerRepository ownerRepository)
        {
            Field<ListGraphType<OwnerType>>("owners", resolve: context => ownerRepository.GetAll());
        }
    }
}
