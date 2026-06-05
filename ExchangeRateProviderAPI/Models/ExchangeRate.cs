namespace ExchangeRateProviderAPI.Models;

public class ExchangeRate
{
    public int Amount { get; set; }
    public string Country { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public string CurrencyCode { get; set; } = string.Empty;
    public int Order { get; set; }
    public decimal Rate { get; set; }
    public string ValidFor { get; set; } = string.Empty;
}
