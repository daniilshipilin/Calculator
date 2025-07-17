namespace Calculator.Helpers.MathExpressionParser.Exceptions;

using System;

public class UnknownOperatorException : Exception
{
    public UnknownOperatorException()
        : base("Unknown operator detected")
    {
    }
}
