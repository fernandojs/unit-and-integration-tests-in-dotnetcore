using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simple_CRM.Domain;

namespace Simple_CRM.Infra.Data.Configuration
{
    public class BusinessConfig : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Name).HasMaxLength(200);
        }
    }
}
