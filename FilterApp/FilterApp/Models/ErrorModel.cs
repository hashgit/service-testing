namespace FilterApp.Models
{
    public class ErrorModel
    {
        public ErrorModel(string message)
        {
            error = $"Could not decode request: {message}";
        }

        public string error { get; set; }
    }
}
