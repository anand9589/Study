using GraphQL_Core.Contracts;
using GraphQL_Core.Entities.Context;

namespace GraphQL_Core.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationContext context;

        public OwnerRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}
