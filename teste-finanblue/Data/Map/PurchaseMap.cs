using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using teste_finanblue.Models;

namespace teste_finanblue.Data.Map
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.clientId).IsRequired();
            builder.Property(x => x.productId).IsRequired();
            builder.Property(x => x.companyId).IsRequired();
        }
    }
}

