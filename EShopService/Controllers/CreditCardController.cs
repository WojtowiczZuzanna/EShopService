using Microsoft.AspNetCore.Mvc;
using EShop.Domain.Exceptions;
using EShop.Application;

namespace EShopService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CreditCardController : ControllerBase
{
    protected ICreditCardService _creditCardService;

    public CreditCardController(ICreditCardService creditCardService)
    {
        _creditCardService = creditCardService;
    }

    [HttpPost]
    public IActionResult ValidateCard([FromBody] string cardNumber)
    {
        try
        {
            var isValid = _creditCardService.ValidateCard(cardNumber);
            var provider = _creditCardService.GetCardType(cardNumber);
            return Ok();
        }
        catch (CardNumberTooLongException)
        {
            return StatusCode(414, "Card number is too long.");
        }
        catch (CardNumberTooShortException)
        {
            return StatusCode(400, "Card number too short.");
        }
        catch (CardNumberInvalidException)
        {
            return StatusCode(400, "Card number invalid.");
        }
        catch (NotSupportedException)
        {
            return StatusCode(406, "Card provider not supported.");
        }
    }

}
