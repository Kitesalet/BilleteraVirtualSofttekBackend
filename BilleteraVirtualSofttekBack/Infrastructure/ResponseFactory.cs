using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace IntegradorSofttekImanol.Infrastructure
{
    /// <summary>
    /// A factory class for creating API response objects.
    /// </summary>
    public static class ResponseFactory
    {
        /// <summary>
        /// Creates a success response with the status code and data.
        /// </summary>
        /// <param name="statusCode">A HttpStatusCode </param>
        /// <param name="data">An object</param>
        /// <returns>An IActionResult representing the success response.</returns>
        public static IActionResult CreateSuccessResponse(HttpStatusCode statusCode, object? data)
        {
            var response = new ApiSuccessResponse()
            {
                StatusCode = statusCode,
                Data = data
            };

            return new ObjectResult(response)
            {
                StatusCode = (int?)statusCode
            };
        }

        /// <summary>
        /// Creates an error response with the status code and error messages.
        /// </summary>
        /// <param name="statusCode">A HttpStatusCode. /param>
        /// <param name="errors">A String Array</param>
        /// <returns>An IActionResult representing the error response.</returns>
        public static IActionResult CreateErrorResponse(HttpStatusCode statusCode, params string[] errors)
        {
            var response = new ApiErrorResponse()
            {
                StatusCode = statusCode,
                Errors = new List<ApiErrorResponse.ResponseError>()
            };

            foreach (var error in errors)
            {
                response.Errors.Add(new ApiErrorResponse.ResponseError() { Error = error });
            }

            return new ObjectResult(response)
            {
                StatusCode = (int?)statusCode
            };
        }
    }
}