using ExchangeRateProviderAPI.Models;
using ExchangeRateProviderAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRateProviderAPI.Controllers;
[ApiController]
[Route("api/exchange-rates/[action]")]
public class ExchangeRateController(IExchangeRateProvider exchangeRateProvider) : ControllerBase
{
    private readonly IExchangeRateProvider _exchangeRateProvider = exchangeRateProvider;

    [HttpGet]
    [ProducesResponseType(typeof(ExchangeRateVM), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    public async Task<IActionResult> GetExchangeRates([FromQuery] string Date, CancellationToken cancellationToken)
    {
        try
        {
            ExchangeRateVM result = await _exchangeRateProvider.GetCnbExchangeRateByDateAsync(Date, cancellationToken);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
