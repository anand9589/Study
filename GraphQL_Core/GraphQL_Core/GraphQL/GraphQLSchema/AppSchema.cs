using GraphQL.Types;
using GraphQL_Core.GraphQL.GraphQLQueries;

namespace GraphQL_Core.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();
        }
    }
}
