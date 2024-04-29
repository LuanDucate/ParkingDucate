using ParkingDucate.Domain.Model;
using ParkingDucate.Domain.Model.Enums;
using System.Net.Http.Json;

namespace Client
{
    public class Menu
    {
        private static readonly string baseUrl = "https://localhost:7081/";
        public static async Task ExibirMenuAsync()
        {
            var _http = new HttpClient { BaseAddress = new Uri(baseUrl) };
            await _http.GetAsync("Parking/InitialValues");
            bool continuar = true;
            do
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Selecione o tipo de serviço para o estacionamento:");
                Console.WriteLine("0 - Finalizar");
                Console.WriteLine("1 - Estacionar moto");
                Console.WriteLine("2 - Estacionar carro");
                Console.WriteLine("3 - Estacionar van");
                Console.WriteLine("4 - Retirar moto");
                Console.WriteLine("5 - Retirar carro");
                Console.WriteLine("6 - Retirar van");
                Console.WriteLine("7 - Buscar número de vagas atualizado");
                Console.WriteLine("8 - Listar veiculos estacionados");
                Console.WriteLine("9 - Atualizar numero de vagas");
                Console.WriteLine("------------------------------------------");

                Console.Write("Digite o número para serviço desejado: ");
                var escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        EstacionarVeiculoAsync(VehicleType.Bike);
                        break;
                    case "2":
                        EstacionarVeiculoAsync(VehicleType.Car);
                        break;
                    case "3":
                        EstacionarVeiculoAsync(VehicleType.Van);
                        break;
                    case "4":
                        RetirarVeiculoAsync(VehicleType.Bike);
                        break;
                    case "5":
                        RetirarVeiculoAsync(VehicleType.Car);
                        break;
                    case "6":
                        RetirarVeiculoAsync(VehicleType.Van);
                        break;
                    case "7":
                        GetVagasAsync();
                        break;
                    case "8":
                        ListarVeiculosEstacionadosAsync();
                        break;
                    case "9":
                        AtualizarNumeroDeVagasAsync();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Escolha inválida.");
                        break;
                }
            } while (continuar);

        }

        private static async Task AtualizarNumeroDeVagasAsync()
        {
            var _http = new HttpClient { BaseAddress = new Uri(baseUrl) };

            Console.Write("Digite o número de vagas para MOTO: ");
            var inputMoto = Console.ReadLine();
            int vagasmoto;
            while (!int.TryParse(inputMoto, out vagasmoto) || vagasmoto < 0)
            {
                Console.WriteLine("Por favor, insira um número válido de vagas para motos.");
                inputMoto = Console.ReadLine();
            }

            Console.Write("Digite o número de vagas para CARRO: ");
            var inputCarro = Console.ReadLine();
            int vagascarro;
            while (!int.TryParse(inputCarro, out vagascarro) || vagascarro < 0)
            {
                Console.WriteLine("Por favor, insira um número válido de vagas para carros.");
                inputCarro = Console.ReadLine();
            }

            Console.Write("Digite o número de vagas para VAN: ");
            var inputVan = Console.ReadLine();
            int vagasvan;
            while (!int.TryParse(inputVan, out vagasvan) || vagasvan < 0)
            {
                Console.WriteLine("Por favor, insira um número válido de vagas para vans.");
                inputVan = Console.ReadLine();
            }

            var response = await _http.PostAsync($"Parking/SetNumberOfVacancies?bike={vagasmoto}&car={vagascarro}&van={vagasvan}", null);
            response.EnsureSuccessStatusCode();

            var newVacanciesInfo = await response.Content.ReadFromJsonAsync<Vacancies>();
            Console.WriteLine($"Vagas disponíveis: Bikes = {newVacanciesInfo.AvailableBike}, Carros = {newVacanciesInfo.AvailableCar}, Vans = {newVacanciesInfo.AvailableVan}");
        }

        private static async Task ListarVeiculosEstacionadosAsync()
        {
            var _http = new HttpClient { BaseAddress = new Uri(baseUrl) };

            var vehicles = await _http.GetFromJsonAsync<Vehicle[]>("Parking/GetVehicles");
            Console.WriteLine("Veículos estacionados:");
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"Placa: {vehicle.Plate}, Tipo: {vehicle.Type}");
            }
        }

        private static async Task GetVagasAsync()
        {
            var _http = new HttpClient { BaseAddress = new Uri(baseUrl) };

            var vacancies = await _http.GetFromJsonAsync<Vacancies>("Parking/GetVacancies");
            Console.WriteLine($"Vagas disponíveis: Bikes = {vacancies.AvailableBike}, Carros = {vacancies.AvailableCar}, Vans = {vacancies.AvailableVan}");
        }

        private static async Task RetirarVeiculoAsync(VehicleType bike)
        {
            var _http = new HttpClient { BaseAddress = new Uri(baseUrl) };
            Console.Write("Digite a placa do veículo:");
            var plateToRemove = Console.ReadLine();
            var ticketResponse = await _http.PostAsync($"Parking/FinalizeVehicleStay?plate={plateToRemove}", null);
            ticketResponse.EnsureSuccessStatusCode();
            var ticket = await ticketResponse.Content.ReadFromJsonAsync<Ticket>();
            Console.WriteLine($"Ticket de saída: {ticket.Plate} \n Entrada: {ticket.Entry} \n Saída: {ticket.Departure} \n Valor Total: {ticket.TotalValue}");
        }

        private static async Task EstacionarVeiculoAsync(VehicleType type)
        {
            var _http = new HttpClient { BaseAddress = new Uri(baseUrl) };

            Console.Write("Digite a placa do veículo:");
            var placa = Console.ReadLine();
            var newVehicle = new Vehicle(placa, (int)type, type, ParkingStatus.Started);
            var newVacancies = await _http.PostAsJsonAsync("Parking/AddVehicle", newVehicle);
            newVacancies.EnsureSuccessStatusCode();
            var updatedVacancies = await newVacancies.Content.ReadFromJsonAsync<Vacancies>();
            Console.WriteLine($"Vagas disponíveis: Bikes = {updatedVacancies.AvailableBike}, Carros = {updatedVacancies.AvailableCar}, Vans = {updatedVacancies.AvailableVan}");
        }
    }
}
