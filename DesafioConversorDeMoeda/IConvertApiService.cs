using Refit;

namespace DesafioConversorDeMoeda
{
    internal interface IConvertApiService
    {
        [Get("/convert?from={from}&to={to}&amount={amount}")]
        Task<ConvertResponse> GetAddressAsync(string from, string to, double amount);   
    }
}
