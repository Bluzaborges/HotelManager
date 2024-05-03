using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelManager.Domain.Entities;

namespace HotelManager.Data.Mappings
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
                   .WithMany()
                   .HasForeignKey(r => r.IdRoomValue);

            builder.ToTable("rooms");
        }
    }
}