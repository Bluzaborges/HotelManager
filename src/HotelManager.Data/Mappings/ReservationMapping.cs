using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelManager.Domain.Entities;

namespace HotelManager.Data.Mappings
{
    public class ReservationMapping : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(res => res.Id);

            builder.HasOne(res => res.User)
                .WithMany()
                .HasForeignKey(res => res.IdUser);

            builder.HasOne(res => res.Room)
                .WithMany()
                .HasForeignKey(res => res.IdRoom);

            builder.Property(res => res.Value)
                .IsRequired()
                .HasColumnType("float");

            builder.Property(res => res.StartDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(res => res.EndDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(res => res.Deleted)
                .HasDefaultValue(false)
                .HasColumnType("bit");

            builder.ToTable("reservations");
        }
    }
}