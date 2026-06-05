namespace ExchangeRateProviderAPI.Models;

public class ExchangeRateVM
{
    public string ValidFor { get; set; } = string.Empty;
    public List<ExchangeRate> Rates { get; set; } = [];
}
