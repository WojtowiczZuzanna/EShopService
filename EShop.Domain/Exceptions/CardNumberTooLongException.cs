﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Exceptions;

public class CardNumberTooShortException : Exception
{
    public CardNumberTooShortException() { }

    public CardNumberTooShortException(string message) : base("Card Number is too short.") { }

    public CardNumberTooShortException(string message, Exception innerException) : base(message, innerException) { }
}
