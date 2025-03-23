namespace EShop.Domain.Exceptions;

public class CardNumberTooLongException : Exception
{
    public CardNumberTooLongException() { }
    
    public CardNumberTooLongException(string message) : base("Card Number is too long.") { }

    public CardNumberTooLongException(string message, Exception innerException) : base(message, innerException) { }
}
