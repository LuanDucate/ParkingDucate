using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingDucate.Domain.Model;

namespace ParkingDucate.Domain.Context.Configuration
{
    public class VacanciesConfiguration : IEntityTypeConfiguration<Vacancies>
    {
        public void Configure(EntityTypeBuilder<Vacancies> builder)
        {
            builder.HasKey(v => v.Id);

            builder.HasData(
                new Vacancies
                {
                    Id = Guid.NewGuid(),
                    AvailableCar = 20,
                    AvailableVan = 10,
                    AvailableBike = 10,
                    TotalAvailable = 37,
                    OccupiedByCars = 1,
                    OccupiedByBikes = 1,
                    OccupiedByVans = 1
                }
            );
        }
    }
}
