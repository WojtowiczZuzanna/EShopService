namespace EShop.Domain.Exceptions;

public class CardNumberTooLongException : Exception
{
    public CardNumberTooLongException()
        : base("Card number is too long.") { }

    public CardNumberTooLongException(string message)
        : base(message) { }

    public CardNumberTooLongException(string message, Exception innerException)
        : base(message, innerException) { }
}
