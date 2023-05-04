using GraphQL_Core.Contracts;
using GraphQL_Core.Entities.Context;

namespace GraphQL_Core.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationContext context;

        public AccountRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}
