using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using teste_finanblue.Models;

namespace teste_finanblue.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.password).IsRequired().HasMaxLength(150);
        }
    }
}
