namespace OSV.Client;

public class OSVException : Exception
{
    public OSVException(string? message)
        : base(message)
    {
    }

    public OSVException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}
