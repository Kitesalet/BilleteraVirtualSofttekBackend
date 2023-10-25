using System.Net;

/// <summary>
/// This class is an API error response containing status code and error details.
/// </summary>
public class ApiErrorResponse
{
    /// <summary>
    /// Gets or sets the HTTP status code associated with the error.
    /// </summary>
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// Gets or sets a list of error details.
    /// </summary>
    public List<ResponseError>? Errors { get; set; }

    /// <summary>
    /// This class instantiates an individual error within an API error response.
    /// </summary>
    public class ResponseError
    {
        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string? Error { get; set; }

        /// <summary>
        /// Gets or sets additional data.
        /// </summary>
        public string? Data { get; set; }
    }
}