using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelManager.Query.Model.Models;

namespace HotelManager.Query.Data.Mappings
{
    public class ReservationMapping : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(res => res.Id);

            builder.HasOne(res => res.User)
                   .WithMany(u => u.Reservations)
                   .HasForeignKey("IdUser");

            builder.HasOne(res => res.Room)
                   .WithMany(r => r.Reservations)
                   .HasForeignKey("IdRoom");

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