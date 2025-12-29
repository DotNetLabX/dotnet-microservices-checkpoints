namespace Blocks.Exceptions;

public class DomainException(string message, Exception? innerException = null)
    : Exception(message, innerException);
