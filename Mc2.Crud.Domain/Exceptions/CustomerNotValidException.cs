namespace Mc2.CrudTest.Domain.Exceptions
{
    public class CustomerNotValidException :Exception
    {
        public CustomerNotValidException() 
        {
            ValidationErrors = new List<string>();
        }

        public CustomerNotValidException(string message): base(message)
        {
            ValidationErrors = new List<string>();
        }

        public List<string> ValidationErrors { get; }
    }
}