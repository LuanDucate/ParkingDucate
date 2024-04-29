using ParkingDucate.Domain.Model;
using ParkingDucate.Domain.Model.Enums;
using ParkingDucate.Domain.Repository.Interfaces;

namespace ParkingDucate.Domain.Repository
{
    public class Repository : IRepository
    {
        private ParkingDucate.Domain.Context.Context _context;
        public Repository(ParkingDucate.Domain.Context.Context context)
        {
            _context = context;
        }
        public void AddTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        public void AddVacancies(Vacancies v)
        {
            if (!_context.Vacancies.Any())
            {
                _context.Vacancies.Add(v);
                _context.SaveChanges();
            }
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }

        public IEnumerable<Vehicle> GetAllParkedVehicles()
        {
            var retorno = _context.Vehicles.Where(x => x.Status.Equals(ParkingStatus.Started)).ToList();
            return retorno.AsEnumerable();
        }

        public Ticket? getTicketByPlate(string plate)
        {
            return _context.Tickets.FirstOrDefault(x => x.Plate.Equals(plate)
            && x.Status.Equals(ParkingStatus.Started));
        }

        public Vacancies GetVacancies()
        {
            return _context.Vacancies.FirstOrDefault();
        }

        public Vehicle? GetVehicleByPlate(string plate)
        {
            return _context.Vehicles.FirstOrDefault(x => x.Plate.Equals(plate) && x.Status.Equals(ParkingStatus.Started));
        }

        public void UpdateVacancies(Vacancies vacancies)
        {
            var v = _context.Vacancies.FirstOrDefault();
            v = vacancies;
            _context.Vacancies.Update(vacancies);
            _context.SaveChanges();
        }
        public void UpdateVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            _context.SaveChanges();
        }
        public void UpdateTicket(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
        }
    }
}
