using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingDucate.Domain.Model;

namespace ParkingDucate.Domain.Context.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(v => v.Id);

            builder.HasData(
            new Ticket
            {
                Id = Guid.NewGuid(),
                Plate = "CAR2R00",
                Entry = DateTime.Now.AddHours(-3)
            },
            new Ticket
            {
                Id = Guid.NewGuid(),
                Plate = "BIK1R00",
                Entry = DateTime.Now.AddHours(-2)
            },
            new Ticket
            {
                Id = Guid.NewGuid(),
                Plate = "VAN3R00"
            }
        );
        }
    }
}
