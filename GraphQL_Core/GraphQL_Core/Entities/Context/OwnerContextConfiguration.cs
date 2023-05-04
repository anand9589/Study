using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL_Core.Entities.Context
{
    public class OwnerContextConfiguration : IEntityTypeConfiguration<Owner>
    {
        private Guid[] ids;

        public OwnerContextConfiguration(Guid[] ids)
        {
            this.ids = ids;
        }

        public void Configure(EntityTypeBuilder<Owner> builder)
        {
         
        }
    }
}
