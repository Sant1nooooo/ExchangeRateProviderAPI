using ExchangeRateProviderAPI.Models;

namespace ExchangeRateProviderAPI.Services;

public class ExchangeRateProvider(HttpClient httpClient) : IExchangeRateProvider
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ExchangeRateVM> GetCnbExchangeRateByDateAsync(string date, CancellationToken cancellation)
    {
        CnbExchangeRateResponse successResponse = new CnbExchangeRateResponse();
        HttpResponseMessage response = await _httpClient.GetAsync($"/cnbapi/exrates/daily?date={date}&lang=EN", cancellation);
        string responseBody = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            CnbErrorResponse? error = await response.Content.ReadFromJsonAsync<CnbErrorResponse>();
            if (error is null) throw new InvalidOperationException("Unable to deserialize CNB error response.");

            string errorValue = ExtractErrorValue(error.Description);

            throw new HttpRequestException($"Invalid date format: {errorValue}. Please use MM-DD-YYYY :)");
        }

        successResponse = (await response.Content.ReadFromJsonAsync<CnbExchangeRateResponse>())!;

        return new ExchangeRateVM
        {
            ValidFor = successResponse.Rates.Count != 0 ? successResponse.Rates.FirstOrDefault()!.ValidFor : "",
            Rates = successResponse.Rates
        };
    }

    private static string ExtractErrorValue(string description)
    {
        const string marker = "Value:";

        int index = description.IndexOf(marker, StringComparison.OrdinalIgnoreCase);

        if (index == -1)
            return string.Empty;

        return description[(index + marker.Length)..].Trim();
    }
}
