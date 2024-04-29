using ParkingDucate.Domain.Context;
using ParkingDucate.Domain.Repository.Interfaces;
using ParkingDucate.Domain.Repository;
using ParkingDucate.Domain.Services.Interfaces;
using ParkingDucate.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace ParkingDucate.api.ConfigureServices
{
    public class DependencyInjectionHelper
    {
        public static void ConfigureServices(IServiceCollection Services)
        {
            Services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase("MyDataBase"));
            Services.AddScoped<Context>();
            Services.AddTransient<IParkingService, ParkingService>();
            Services.AddTransient<IRepository, Repository>();
        }
    }
}
