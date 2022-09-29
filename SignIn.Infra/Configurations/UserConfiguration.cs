using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignIn.Domain.Models;
using System.Xml;

namespace SignIn.Infra.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Firstname).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(p => p.Lastname).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(p => p.Snn).HasColumnType("VARCHAR(8)").IsRequired();
            builder.Property(P => P.Birthdate).HasColumnType("CHAR(8)").IsRequired();
            builder.Property(P => P.Password).HasColumnType("VARCHAR(32)").IsRequired();

            builder
                .HasIndex(i => i.Email)
                    .IsUnique();
        }
    }
}
