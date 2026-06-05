using ExchangeRateProviderAPI.Models;

namespace ExchangeRateProviderAPI.Services;

public interface IExchangeRateProvider
{
    Task<ExchangeRateVM> GetCnbExchangeRateByDateAsync(string date, CancellationToken cancellation);
}
