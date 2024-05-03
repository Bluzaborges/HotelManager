using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelManager.Query.Model.Models;

namespace HotelManager.Query.Data.Mappings
{
    public class RoomValueMapping : IEntityTypeConfiguration<RoomValue>
    {
        public void Configure(EntityTypeBuilder<RoomValue> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Type)
                   .IsRequired()
                   .HasColumnType("varchar(30)");

            builder.Property(v => v.Name)
                  .IsRequired()
                  .HasColumnType("varchar(50)");

            builder.Property(v => v.Value)
                   .IsRequired()
                   .HasColumnType("float");

            builder.ToTable("rooms_values");
        }
    }
}