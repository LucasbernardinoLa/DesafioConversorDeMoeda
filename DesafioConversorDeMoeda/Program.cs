using DesafioConversorDeMoeda;
using Refit;

try
{
    var convertClient = RestService.For<IConvertApiService>("https://api.exchangerate.host");
    Console.Write("Moeda origem: ");
    string moedaOrigem = Console.ReadLine();
    Console.Write("Moeda Destino: ");
    string moedaDestino = Console.ReadLine();
    Console.Write("Valor: ");
    string valor = Console.ReadLine();

    ValidadorDados validador = new(moedaOrigem, moedaDestino, valor);

    var address = await convertClient.GetAddressAsync(validador.MoedaOrigem, validador.MoedaDestino,
        validador.ValorConvertido);
    
    Console.WriteLine($"\nresultado: {address.Result:F2}\nTaxa: {address.Info.Rate} ");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    return;
}