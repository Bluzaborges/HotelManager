using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelManager.Query.Model.Models;

namespace HotelManager.Query.Data.Mappings
{
    public class RoomMapping : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Code)
                   .IsRequired()
                   .HasColumnType("varchar(2)");

            builder.Property(r => r.Deleted)
                    .HasDefaultValue(false)
                    .HasColumnType("bit");

            builder.HasOne(r => r.RoomValue)
                   .WithMany(v => v.Rooms)
                   .HasForeignKey("IdRoomValue");

            builder.ToTable("rooms");
        }
    }
}