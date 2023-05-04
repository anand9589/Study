using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL_Core.Entities.Context
{
    public class AccountContextConfiguration : IEntityTypeConfiguration<Account>
    {
        private Guid[] ids;

        public AccountContextConfiguration(Guid[] ids)
        {
            this.ids = ids;
        }


        public void Configure(EntityTypeBuilder<Account> builder)
        {
        }
    }
}
