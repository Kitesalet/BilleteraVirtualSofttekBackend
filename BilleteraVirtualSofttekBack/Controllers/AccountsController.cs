using BilleteraVirtualSofttekBack.Controllers.ApiHelper;
using BilleteraVirtualSofttekBack.Models.DTOs.Account;
using BilleteraVirtualSofttekBack.Models.DTOs.Transactions;
using BilleteraVirtualSofttekBack.Models.Enums;
using BilleteraVirtualSofttekBack.Models.Interfaces.ServiceInterfaces;
using IntegradorSofttekImanol.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace BilleteraVirtualSofttekBack.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly IAccountService _service;
        private readonly ILogger<AccountsController> _logger;
        private readonly IHttpClientFactory _httpClient;

        /// <summary>
        /// Initializes an instance of AccountController using dependency injection with its parameters.
        /// </summary>
        /// <param name="service">An IAccountService.</param>
        /// <param name="logger">An ILogger.</param>
        public AccountsController(IAccountService service, IHttpClientFactory httpClient , ILogger<AccountsController> logger)
        {
            _service = service;
            _logger = logger;
            _httpClient = httpClient;

        }

        /// <summary>
        /// Gets all Accounts from a client.
        /// </summary>
        /// <returns>
        /// 200 OK response with the list of Accounts if successful.
        /// </returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("accounts/{id:int}")]
        public async Task<IActionResult> GetAllAccountsByClient(int id)
        {

            if(id < 1)
            {
                _logger.LogInformation($"Client id was invalid, id = {id}!");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The client id was invalid");
            }
        
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
            if(id <= 0)
            {
                _logger.LogError($"Invalid id introduced, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The id introduced was invalid");
            }

            var account = await _service.GetAccountByIdAsync(id);

            if(account == null)
            {
                _logger.LogError($"The account wasnt found!, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, $"The account introduced wasn't found!");
            }

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

            if(dto.Type != AccountType.Crypto && dto.Type != AccountType.Dollar && dto.Type != AccountType.Peso)
            {
                _logger.LogError($"The account type was incorrect!, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, $"The account type submitted was incorrect!");
            }

            var flag = await _service.CreateAccountAsync(dto);

            if(flag == false)
            {
                _logger.LogError($"There was a problem with the creation of the account, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.Conflict, $"The account couldn't be created!");
            }

            _logger.LogInformation($"Account was created, dto = ${dto}");
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

            if(id <= 0)
            {
                _logger.LogInformation($"The id introduced was invalid, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The id introduced was invalid!");
            }

            var result = await _service.DeleteAccountAsync(id);

            if(result == false)
            {

                _logger.LogInformation($"Account was not deleted or not found, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "The account submited was not found!");

            }

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

        public async Task<IActionResult> DepositAsync(int id, AccountDepositDto depositDto)
        {
            if (depositDto.Amount <= 1)
            {
                _logger.LogInformation($"The amount introduced was invalid, dto = {depositDto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Amount must be greater than 1");

            }

            if(depositDto.Id != id)
            {
                _logger.LogInformation($"The ids introduced didnt match, id = {id}, dto = {depositDto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Ids dont match!");
            }

            var acc = await _service.GetAccountByIdAsync(id);

            if (acc == null)
            {
                _logger.LogInformation($"The selected account didnt exist!, dto = {depositDto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "The selected account doesnt exist!");            
            }

            var clientId = int.Parse(User.FindFirst("NameIdentifier").Value);

            if (clientId != acc.ClientId)
            {
                _logger.LogInformation($"The user in the token doesnt match with the account client id!, dto = {depositDto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The user in the token doesnt match with the account user!");
            }

            var flag = await _service.DepositAsync(depositDto);
       
            if(flag == false)
            {
                _logger.LogInformation($"There was a problem with the deposit, dto = {depositDto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "There was a problem with the deposit!");
            }

            //Add transaction

            TransactionCreateDto transactionCreate = new TransactionCreateDto()
            {
                DestinationAccountId = id,
                SourceAccountId = id,
                Amount = depositDto.Amount,
                ClientId = clientId,
                Type = TransactionType.Deposit,
                Concept = ""
            };

            var baseApi = new BaseApi(_httpClient);

            var token = HttpContext.Request.Headers["Authorization"].ToString();

            var transaction = baseApi.PostToApi("transaction/create", transactionCreate, token);



            _logger.LogInformation($"Deposit Transaction was completed!, id = {id}, transaction = {transaction}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, $"The deposit transaction was completed! The new account balance is {acc.Balance + depositDto.Amount}");

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
                _logger.LogInformation($"The amount introduced was invalid, dto = {extractionDto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Amount must be greater than 1");

            }

            if (extractionDto.Id != id)
            {
                _logger.LogInformation($"The ids introduced didnt match, id = {id}, dto = {extractionDto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Ids dont match!");
            }

            var acc = await _service.GetAccountByIdAsync(id);

            if (acc == null)
            {
                _logger.LogInformation($"The selected account didnt exist!, dto = {extractionDto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "The selected account doesnt exist!");
            }

            if (extractionDto.Amount > acc.Balance)
            {
                _logger.LogInformation($"The amount introduced was higher than the account balance, dto = {extractionDto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "You dont have enough funds for that extraction!");

            }

            var clientId = int.Parse(User.FindFirst("NameIdentifier").Value);

            if (clientId != acc.ClientId)
            {
                _logger.LogInformation($"The user in the token doesnt match with the account client id!, dto = {extractionDto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The user in the token doesnt match with the account user!");
            }

            var flag = await _service.ExtractAsync(extractionDto);

            if (flag == false)
            {
                _logger.LogInformation($"There was a problem with the extraction, dto = {extractionDto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "There was a problem with the extraction!");
            }

            //Add Transaction

            TransactionCreateDto transactionCreate = new TransactionCreateDto()
            {
                SourceAccountId = id,
                DestinationAccountId = id,
                Amount = extractionDto.Amount,
                ClientId = clientId,
                Type = TransactionType.Withdrawal,
                Concept = ""
            };
            
            var baseApi = new BaseApi(_httpClient);

            //Obtains the token
            var token = HttpContext.Request.Headers["Authorization"].ToString();

            var transaction = baseApi.PostToApi("transaction/create", transactionCreate, token);

            _logger.LogInformation($"Transaction was completed!, id = {id}, transaction = {transaction}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, $"The transaction was completed! The new account balance is {acc.Balance - extractionDto.Amount}");

        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("account/transfer")]

        public async Task<IActionResult> TransferAsync(TransferDto transferDto)
        {
            if (transferDto.Amount <= 1)
            {
                _logger.LogInformation($"The amount introduced was invalid, dto = {transferDto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Amount must be greater than 1");

            }

            if (String.IsNullOrEmpty(transferDto.Concept))
            {
                _logger.LogInformation($"The concept introduced was invalid, dto = {transferDto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "You have to introduce a concept");

            }

            if (transferDto.DestinationAccountId == transferDto.OriginAccountId)
            {
                _logger.LogInformation($"The accounts introduced as origin and destination were the same, dto = {transferDto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The accounts cant be the same!");

            }

            var acc = await _service.GetAccountByIdAsync(transferDto.OriginAccountId);

            if (acc == null)
            {
                _logger.LogInformation($"The account selected as origin didnt exist in the database, dto = {transferDto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The selected origin account doesnt exist!");
            }

            var clientId = int.Parse(User.FindFirst("NameIdentifier").Value);

           

            if (clientId != acc.ClientId)
            {
                _logger.LogInformation($"The user in the token doesnt match with the account client id!, dto = {transferDto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The user in the token doesnt match with the account user!");

            }

            if (acc.Balance < transferDto.Amount)
            {
                _logger.LogInformation($"There werent enough funds to make the perceived transaction, dto = {transferDto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "There arent enough funds to make this transaction!");

            }

            var flag = await _service.TransferAsync(transferDto);

            if (flag == false)
            {
                _logger.LogInformation($"There was a problem with the transfer, dto = {transferDto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, 
                    "There was a problem with the transfer! You can't buy Crypto with Pesos or Pesos with Crypto!");
            }

            //Add Transaction

            TransactionCreateDto transactionCreate = new TransactionCreateDto()
            {
                SourceAccountId = 1,
                DestinationAccountId = transferDto.DestinationAccountId,
                Concept = transferDto.Concept,
                Amount = transferDto.Amount,
                ClientId = clientId,
                Type = TransactionType.Transfer
            };

            var baseApi = new BaseApi(_httpClient);

            var token = HttpContext.Request.Headers["Authorization"].ToString();

            var transaction = await baseApi.PostToApi("transaction/create", transactionCreate, token);


            _logger.LogInformation($"Transaction was completed!, id = {transferDto.OriginAccountId}, transaction = {transaction}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, $"The transaction was completed! Your account balance is {acc.Balance - transferDto.Amount}");

        }

    }
}
