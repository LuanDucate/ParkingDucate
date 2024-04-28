using ParkingDucate.Domain.Model;
using ParkingDucate.Domain.Services.Interfaces;

namespace ParkingDucate.Domain.Services
{
    public class ParkingService : IParkingService
    {
        public void AddVehicle(Vehicle vehicle)
        {
            // Adicionar o objeto de veiculo no banco, criar o ticket
            throw new NotImplementedException();
        }

        public Ticket FinalizeVehicleStay(string plate)
        {
            // Atualizar o objeto na tabela de veiculo  e Ticket e retornar o ticket preenchido
            throw new NotImplementedException();
        }

        public Vacancies GetVacancies()
        {
            //popular todos os campos to objeto com as informações. 

            throw new NotImplementedException();
        }
    }
}
