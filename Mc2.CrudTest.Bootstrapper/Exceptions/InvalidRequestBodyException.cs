namespace Mc2.CrudTest.Bootstrapper.Exceptions;

public class InvalidRequestBodyException : Exception
{
    public string[] Errors { get; set; }
}