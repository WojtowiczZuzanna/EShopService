using EShop.Domain.Exceptions;
using EShop.Application;

namespace EShop.Application.Test;

public class CreditCardServiceTest
{
    [Theory]
    [InlineData("3497 7965 8312 797", true)]
    [InlineData("345-470-784-783-010", true)]
    public void CreditCard_CorrectLength_ShouldReturnTrue(string cardNumber, bool expected)
    {
        var creditCardService = new CreditCardService();

        var result = creditCardService.ValidateCard(cardNumber);
        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData("3497 7965 8312 797 8765 908")]
    [InlineData("345-470-784-783-010-123-456")]
    public void CreditCard_TooLong_ShouldThrowException(string cardNumber)
    {
        var creditCardService = new CreditCardService();
        var result = creditCardService.ValidateCard(cardNumber);
        Assert.False(result);
    }


    [Theory]
    [InlineData("3497 7965")]
    [InlineData("123")]
    public void CreditCard_TooShort_ShouldThrowException(string cardNumber)
    {
        var creditCardService = new CreditCardService();
        var result = creditCardService.ValidateCard(cardNumber);
        Assert.False(result);
    }


    [Theory]
    [InlineData("1234 5678 9012 345")] 
    public void CreditCard_InvalidSum_ShouldThrowException(string cardNumber)
    {
        var creditCardService = new CreditCardService();
        var result = creditCardService.ValidateCard(cardNumber);
        Assert.False(result);
    }


    [Theory]
    [InlineData("3497 7965 8312 797", "American Express")]
    [InlineData("345-470-784-783-010", "American Express")]
    [InlineData("4024-0071-6540-1778", "Visa")]
    [InlineData("5105 1051 0510 5100", "MasterCard")]
    [InlineData("6011 0009 9013 9424", "Discover")]
    [InlineData("3566 0020 2036 0505", "JCB")]
    [InlineData("3056 9309 8254 97", "Diners Club")]
    [InlineData("5018 0000 0009", "Maestro")]
    [InlineData("1234 5678 9012 3456", "False")]

    public void CreditCard_CorrectType_ReturnTrue(string cardNumber, string expectedProvider)
    {
        var creditCardService = new CreditCardService();
        var result = creditCardService.GetCardType(cardNumber);
        Assert.Equal(expectedProvider, result);
    }


}