namespace ExchangeRateProviderAPI.Models;

public class CnbErrorResponse
{
    public string Description { get; set; } = string.Empty;
    public string EndPoint { get; set; } = string.Empty;
    public string ErrorCode { get; set; } = string.Empty;
    public string HappenedAt { get; set; } = string.Empty;
    public string MessageId { get; set; } = string.Empty;
}
