using BilleteraVirtualSofttekBack.Helpers;
using BilleteraVirtualSofttekBack.Models.DTOs.Client;
using BilleteraVirtualSofttekBack.Models.HelperClasses;
using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;

namespace BilleteraVirtualSofttekBack.Controllers
{
    /// <summary>
    /// Generates a Controller responsible for user authentication and login.
    /// </summary>

    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private TokenJwtHelper _tokenJWTHelper;
        private readonly ILogger<LoginController> _logger;
        private readonly IUnitOfWork _unitOfWork;


        /// <summary>
        /// Initializes an instance of LoginController using dependency injection with its parameters.
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork.</param>
        /// <param name="configuration">IOptions with JwtSettings.</param>
        public LoginController(IUnitOfWork unitOfWork, IOptions<JwtSettings> configuration)
        {

            _unitOfWork = unitOfWork;
            _tokenJWTHelper = new TokenJwtHelper(configuration);

        }


        /// <summary>
        /// Authenticates a user and generates a JWT token for successful login.
        /// </summary>
        /// <param name="authenticate">UsuarioAuthenticateDTO</param>
        /// <returns>
        /// If authentication is successful, returns an OK response with the JWT token.
        /// |
        /// If authentication fails, returns an Unauthorized response with an error message.
        /// </returns>

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] ClientAuthenticateDto authenticate)
        {
            try
            {
                var userCredentials = await _unitOfWork.ClientRepository.AuthenticateCredentials(authenticate);

                if (userCredentials == null)
                {
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.Unauthorized, "The entered credentials are invalid");
                }

                var token = _tokenJWTHelper.GenerateToken(userCredentials);

                var user = new ClientLoginDto()
                {
                    Token = token,
                    Email = userCredentials.Email,
                    Name = userCredentials.Name
                    
                };

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.InternalServerError, "An unexpected error occurred.");
            }

        }

    }
}
