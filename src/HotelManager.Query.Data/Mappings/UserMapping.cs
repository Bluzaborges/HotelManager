using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelManager.Query.Model.Models;

namespace HotelManager.Query.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(u => u.Role)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(u => u.Cpf)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(u => u.Phone)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(u => u.Fine)
                .IsRequired()
                .HasColumnType("float");

            builder.Property(u => u.Blocked)
                .HasDefaultValue(false)
                .HasColumnType("bit");

            builder.Property(u => u.Deleted)
                .HasDefaultValue(false)
                .HasColumnType("bit");

            builder.ToTable("users");
        }
    }
}