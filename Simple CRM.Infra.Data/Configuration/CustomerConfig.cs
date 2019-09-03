using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simple_CRM.Domain;

namespace Simple_CRM.Infra.Data.Configuration
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Name).HasMaxLength(200);
        }
    }
}
