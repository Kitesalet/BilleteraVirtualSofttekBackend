using System.Net;

namespace IntegradorSofttekImanol.Infrastructure
{
    /// <summary>
    /// Repreents an API success response containing a status code and an object.
    /// </summary>
    public class ApiSuccessResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public object? Data { get; set; }

    }
}
