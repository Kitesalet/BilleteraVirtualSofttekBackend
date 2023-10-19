using BilleteraVirtualSofttekBack.Models.DTOs.Account;
using BilleteraVirtualSofttekBack.Models.DTOs.Transactions;
using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Interfaces.ServiceInterfaces;
using IntegradorSofttekImanol.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace BilleteraVirtualSofttekBack.Controllers
{
    [Route("api")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly IAccountService _service;
        private readonly ILogger<AccountsController> _logger;
        //private readonly IAccountValidator _validator;

        /// <summary>
        /// Initializes an instance of AccountController using dependency injection with its parameters.
        /// </summary>
        /// <param name="service">An IAccountService.</param>
        /// <param name="logger">An ILogger.</param>
        public AccountsController(IAccountService service, ILogger<AccountsController> logger)
        {
            _service = service;
            _logger = logger;

        }

        /// <summary>
        /// Gets all Accounts from a client.
        /// </summary>
        /// <returns>
        /// 200 OK response with the list of Accounts if successful.
        /// </returns>

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("accounts/{id:int}")]
        public async Task<IActionResult> GetAllAccountsByClient(int id)
        {
            /*
            #region Validations           
            var validation = _validator.GetAllAccountsValidator(page, units);
            if (validation != null)
            {
                return validation;
            }
            #endregion
            */

            var accounts = await _service.GetAllAccountsByClientAsync(id);

            _logger.LogInformation("All accounts were retrieved!");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, accounts);

        }

        /// <summary>
        /// Gets an account by their ID.
        /// </summary>
        /// <param name="id">ID of the account to get.</param>
        /// <returns>
        /// 200 OK response with the account if found.
        /// |
        /// 404 Not Found response if no account is found.
        /// </returns>

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("account/{id:int}")]
        public async Task<IActionResult> GetAccount([FromRoute] int id)
        {
            /*
            #region Validations
            var validation = _validator.GetAccountValidator(id);
            if (validation != null)
            {
                return validation;
            }
            #endregion
            */

            var account = await _service.GetAccountByIdAsync(id);

            /*
            var error = _validator.GetAccountError(Account, id);
            if (error != null)
            {
                return error;
            }
            */

            _logger.LogInformation($"Account was retrieved, id = {id}.");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, account);

        }

        /// <summary>
        /// Creates a new account.
        /// </summary>
        /// <param name="dto">account data in a DTO.</param>
        /// <returns>
        /// 201 Created response if account creation is successful.
        /// |
        /// 400 Bad Request response if account creation fails.
        /// |
        /// 409 Conflict if account was found in the database.
        /// </returns>

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Route("account/register")]
        public async Task<IActionResult> CreateAccount(AccountCreateDto dto)
        {

            //It creates the account
            var flag = await _service.CreateAccountAsync(dto);

            /*
            var validationError = _validator.CreateUserValidator(dto, flag);
            if (validationError != null)
            {
                return validationError;
            }
            */

            _logger.LogInformation($"Account was created, Email = {dto.Alias}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.Created, "The account was created!");

        }

        /// <summary>
        /// Updates an existing account by their ID.
        /// </summary>
        /// <param name="id">ID of the account to update.</param>
        /// <param name="dto">Updated account data in a DTO.</param>
        /// <returns>
        /// 204 No Content response if account update is successful.
        /// |
        /// 400 Bad Request response if account update fails.
        /// </returns>


        
        //[HttpPut]
        //[Authorize]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[Route("account/{id:int}")]
        //public async Task<IActionResult> UpdateAccount(int id, AccountUpdateDto dto)
        //{

        //    /*
        //    #region Validations
        //    var validation = await _validator.UpdateAccountValidator(id, dto);
        //    if (validation != null)
        //    {
        //        return validation;
        //    }
        //    #endregion
        //    */

        //    var result = await _service.UpdateAccount(dto);

        //    /*
        //    #region Errors
        //    var error = _validator.UpdateError(result, dto);
        //    if (error != null)
        //    {
        //        return error;
        //    }
        //    #endregion
        //    */

        //    _logger.LogInformation($"Account was properly updated, id = {id}");
        //    return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "Account was properly updated!");

        //}
    

        /// <summary>
        /// Deletes a account by their ID.
        /// </summary>
        /// <param name="id">ID of the account to delete.</param>
        /// <returns>
        /// 204 No Content response if account deletion is successful.
        /// |
        /// 404 Not Found response if account deletion fails.
        /// </returns>

        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("account/{id:int}")]
        public async Task<IActionResult> DeleteAccount([FromRoute] int id)
        {
            /*
            #region Validations
            var validation = _validator.DeleteGetUserValidator(id);
            if (validation != null)
            {
                return validation;
            }
            #endregion
            */

            var result = await _service.DeleteAccountAsync(id);

            /*
            #region Errors
            var error = _validator.DeleteGetUserValidator(id, result);
            if (error != null)
            {
                return error;
            }
            #endregion
            */

            _logger.LogInformation($"Account was deleted, id = {id}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "The Account was deleted!");

        }

        /// <summary>
        /// Makes a deposit of money into a single account
        /// </summary>
        /// <returns>Return a transaction object</returns>

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("account/deposit/{id:int}")]

        public async Task<IActionResult> DepositAsync(int id, AccountExtractionDto depositDto)
        {
            if (depositDto.Amount <= 1)
            {
                return BadRequest("Amount must be greater than 1");
            }

            if(depositDto.Id != id)
            {
                return BadRequest("Ids dont match!");
            }

            var acc = await _service.GetAccountByIdAsync(id);
            var clientId = int.Parse(User.FindFirst("NameIdentifier").Value);

            if (clientId != acc.ClientId)
            {                   
                
                return BadRequest("The user is in the token doesnt match with the account client id!");         
            }

            var flag = await _service.DepositAsync(depositDto);
       
            if(flag == false)
            {
                return BadRequest("There was a problem with the transaction!");
            }

            //Add transaction

            _logger.LogInformation($"Transaction was completed!, id = {id}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, $"The transaction was completed! The new account balance is {acc.Balance}");

        }

        /// <summary>
        /// Makes an extraction of money from a single account
        /// </summary>
        /// <returns>Return a transaction object</returns>

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("account/extract/{id:int}")]

        public async Task<IActionResult> ExtractionAsync(int id, AccountExtractDto extractionDto)
        {
            if (extractionDto.Amount <= 1)
            {
                return BadRequest("Amount must be greater than 1");
            }

            if (extractionDto.Id != id)
            {
                return BadRequest("Ids dont match!");
            }

            var acc = await _service.GetAccountByIdAsync(id);
            var clientId = int.Parse(User.FindFirst("NameIdentifier").Value);

            if (clientId != acc.ClientId)
            {
                return BadRequest("The user is in the token doesnt match with the account client id!");
            }

            if(acc.Balance <= extractionDto.Amount)
            {
                return BadRequest("There arent enough funds to make this extraction!");
            }

            var flag = await _service.ExtractAsync(extractionDto);

            if (flag == false)
            {
                return BadRequest("There was a problem with the transaction!");
            }

            //Add Transaction

            _logger.LogInformation($"Transaction was completed!, id = {id}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, $"The transaction was completed! The new account balance is {acc.Balance}");

        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("account/transfer/{id:int}")]

        public async Task<IActionResult> TransferAsync(int id, TransferDto transferDto)
        {
            if (transferDto.Amount <= 1)
            {
                return BadRequest("Amount must be greater than 1");
            }

            if (transferDto.OriginAccountId != id)
            {
                return BadRequest("Ids dont match!");
            }

            var acc = await _service.GetAccountByIdAsync(id);
            var clientId = int.Parse(User.FindFirst("NameIdentifier").Value);

            if (clientId != acc.ClientId)
            {
                return BadRequest("The user is in the token doesnt match with the account client id!");
            }

            if (acc.Balance <= transferDto.Amount)
            {
                return BadRequest("There arent enough funds to make this transaction!");
            }

            var flag = await _service.TransferAsync(transferDto);

            if (flag == false)
            {
                return BadRequest("There was a problem with the transaction!");
            }

            //Add Transaction

            _logger.LogInformation($"Transaction was completed!, id = {id}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, $"The transaction was completed! The new account balance is {acc.Balance - transferDto.Amount}");

        }

    }
}
