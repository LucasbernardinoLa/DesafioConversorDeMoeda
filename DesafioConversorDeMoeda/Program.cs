using DesafioConversorDeMoeda;
using Refit;


while (true)
{
    try
    {
        var convertClient = RestService.For<IConvertApiService>("https://api.exchangerate.host");
        Console.Write("Moeda origem: ");
        string moedaOrigem = Console.ReadLine();
        if (String.IsNullOrEmpty(moedaOrigem)) break;

        Console.Write("Moeda Destino: ");
        string moedaDestino = Console.ReadLine();
        Console.Write("Valor: ");
        string valor = Console.ReadLine();

        ValidadorDados validador = new(moedaOrigem, moedaDestino, valor);

        Console.WriteLine();
        var address = await convertClient.GetAddressAsync(validador.MoedaOrigem, validador.MoedaDestino,
                                                          validador.ValorConvertido);

        Console.WriteLine($"{validador.MoedaOrigem} {validador.ValorConvertido:F2} => " +
                          $"{validador.MoedaDestino} {address.Result:F2}\ntaxa: {address.Info.Rate:F6}");
        Console.ReadKey();
        Console.Clear();
    }
    catch (ApiException e)
    {
        Console.WriteLine();
        Console.WriteLine($"Erro de comunicação com a API: {e.Message}");
        Console.WriteLine($"Erro de comunicação com a API: {e.InnerException.Message}");
        Console.ReadKey();
        Console.Clear();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}