using Client;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Digite o nome do operador.");
        var nome = Console.ReadLine();
        Console.Clear();
        Console.WriteLine($"--- Seja muito bem vindo {nome} ---");

        await Menu.ExibirMenuAsync();
    }
}