using BilleteraVirtualSofttekBack.Controllers.ApiHelper;
using BilleteraVirtualSofttekBack.Models.DTOs.Account;
using BilleteraVirtualSofttekBack.Models.DTOs.Transactions;
using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Enums;
using BilleteraVirtualSofttekBack.Models.Interfaces.ServiceInterfaces;
using IntegradorSofttekImanol.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Security.Claims;

namespace BilleteraVirtualSofttekBack.Controllers
{


    /// <summary>
    /// Generates a Controller responsible for account operations and account actions.
    /// </summary>
    
    [Route("api")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly IAccountService _service;
        private readonly ILogger<AccountsController> _logger;
        private readonly IHttpClientFactory _httpClient;

        /// <summary>
        /// Initializes an instance of the AccountsController using dependency injection with its parameters.
        /// </summary>
        /// <param name="service">An IAccountService for account-related operations.</param>
        /// <param name="httpClient">An IHttpClientFactory for making HTTP requests.</param>
        /// <param name="logger">An ILogger for logging and monitoring.</param>
        
        public AccountsController(IAccountService service, IHttpClientFactory httpClient, ILogger<AccountsController> logger)
        {
            _service = service;
            _httpClient = httpClient;
            _logger = logger;
        }


        /// <summary>
        /// Retrieves a list of clients with pagination support.
        /// </summary>
        /// <param name="page">The page number for pagination</param>
        /// <param name="units">The number of units to display per page.</param>
        /// <returns>
        /// 200 OK response with the list of accounts if successful.
        /// 401 Unauthorized response if the user is not authenticated.
        /// 400 Bad Request response if the pagination parameters are invalid.
        /// </returns>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("accounts")]
        public async Task<IActionResult> GetAllAccounts([FromQuery] int page = 1, [FromQuery] int units = 10)
        {
            if (page < 1 || units < 1)
            {
                _logger.LogInformation($"There was an error in the pagination, page = {page}, units = {units}!");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "There was an error in the pagination!");
            }

            var clients = await _service.GetAllAccounts(page, units);

            _logger.LogInformation("All accounts were retrieved!");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, clients);

        }


        /// <summary>
        /// Retrieves all accounts belonging to a client with the specified ID.
        /// </summary>
        /// <param name="id">An int id.</param>
        /// <returns>
        /// 200 OK response with the list of accounts if successful.
        /// 400 Bad Request response if the client ID is invalid.
        /// 401 Unauthorized response if the request is not authorized.
        /// </returns>

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("accounts/{id:int}")]
        public async Task<IActionResult> GetAllAccountsByClient(int id, [FromQuery] int page = 1, [FromQuery] int units = 99)
        {
            if (page < 1 || units < 1)
            {
                _logger.LogInformation($"There was an error in the pagination, page = {page}, units = {units}!");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "There was an error in the pagination!");
            }

            if (id < 1)
            {
                _logger.LogInformation($"Client ID was invalid, id = {id}!");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The client ID was invalid");
            }

            var accounts = await _service.GetAllAccountsByClientAsync(id, page, units);

            _logger.LogInformation("All accounts were retrieved!");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, accounts);
        }

        /// <summary>
        /// Retrieves an account by its unique ID.
        /// </summary>
        /// <param name="id">The unique identifier of the account to retrieve.</param>
        /// <returns>
        /// 200 OK response with the account if found.
        /// 404 Not Found response if no account with the specified ID is found.
        /// 400 Bad Request response if the ID introduced is invalid.
        /// 401 Unauthorized response if the request is not authorized.
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
            if (id <= 0)
            {
                _logger.LogError($"Invalid ID introduced, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The ID introduced was invalid");
            }

            var account = await _service.GetAccountByIdAsync(id);

            if (account == null)
            {
                _logger.LogError($"The account wasn't found!, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, $"The account with the specified ID wasn't found!");
            }

            _logger.LogInformation($"Account was retrieved, id = {id}.");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, account);
        }

        /// <summary>
        /// Creates a new account.
        /// </summary>
        /// <param name="dto">Account data in a DTO (Data Transfer Object).</param>
        /// <returns>
        /// 201 Created response if the account creation is successful.
        /// 400 Bad Request response if the account creation fails due to invalid data.
        /// 401 Unauthorized response if the request is not authorized.
        /// </returns>

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, $"The account couldn't be created!");
            }

            _logger.LogInformation($"Account was created, dto = ${dto}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.Created, "The account was created!");

        }

        /// <summary>
        /// Updates an existing account by their ID.
        /// </summary>
        /// <param name="id">ID of the account to update.</param>
        /// <param name="dto">Updated account data in a DTO (Data Transfer Object).</param>
        /// <returns>
        /// 204 No Content response if account update is successful.
        /// 400 Bad Request response if account update fails due to invalid data.
        /// 404 Not Found response if account update feilss due to not found data.
        /// </returns>

        [HttpPut]
        [Authorize(Policy = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Route("account/{id:int}")]
        public async Task<IActionResult> UpdateAccount(int id, AccountUpdateDto dto)
        {

            if(dto.AccountId != id)
            {
                _logger.LogError($"The ids didnt match!, dto = {dto}, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The entered ids dont match!");
            }

            if (dto.Type != AccountType.Crypto && dto.Type != AccountType.Dollar && dto.Type != AccountType.Peso)
            {
                _logger.LogError($"The account type was incorrect!, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The account type submitted was incorrect!");
            }

            else if (dto.Type == AccountType.Crypto)
            {
                if (string.IsNullOrEmpty(dto.UUID))
                {
                    _logger.LogError($"A Crypto account needs a valid UUID, dto = {dto}");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "A Crypto account needs a valid UUID!");
                }
                else if (dto.AccountNumber > 0 || string.IsNullOrEmpty(dto.Alias) == false || dto.CBU > 0)
                {
                    _logger.LogError($"A Crypto account can't have fiduciary values, dto = {dto}");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "A Crypto account can't have fiduciary values!");
                }
            }
            else if (dto.Type == AccountType.Dollar || dto.Type == AccountType.Peso)
            {
                if (dto.AccountNumber <= 0 || string.IsNullOrEmpty(dto.Alias) == true || dto.CBU <= 0)
                {
                    _logger.LogError($"A Fiduciary account needs a valid Account number, AccountId, and CBU, dto = {dto}");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "A Fiduciary account needs a valid Account number, AccountId, and CBU");
                }
                else if (string.IsNullOrEmpty(dto.UUID) == false)
                {
                    _logger.LogError($"A Fiduciary account can't have a UUID, dto = {dto}");
                    return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "A Fiduciary account can't have a UUID!");
                }
            }

            if (dto.Balance <= 1)
            {
                _logger.LogInformation($"The amount introduced was invalid, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Amount must be greater than 1");
            }

            var flag = await _service.UpdateAccount(dto);
         
            if(flag == false)
            {
                _logger.LogInformation($"There was an error with UUID | ALIAS | ACCOUNTID | CBU, or account or client was null, dto = {dto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "There was an error with the data you introduced, Account wasn't created!");
            }

            _logger.LogInformation($"Account was properly updated, id = {id}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "Account was properly updated!");

        }

        /// <summary>
        /// Deletes an account by their ID.
        /// </summary>
        /// <param name="id">ID of the account to delete.</param>
        /// <returns>
        /// 204 No Content response if account deletion is successful.
        /// 404 Not Found response if account deletion fails.
        /// 401 Unauthorized response if the user is not authorized.
        /// 403 Forbidden response if the user is forbidden from performing this action.
        /// 400 Bad Request response if the request is invalid.
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

                _logger.LogInformation($"Account was not deleted or not found or had balance left, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "The account submited has balance left, or was not found!");

            }

            _logger.LogInformation($"Account was deleted, id = {id}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, "The Account was deleted!");

        }

        /// <summary>
        /// Makes a deposit of money into a single account.
        /// </summary>
        /// <param name="id">ID of the account to deposit into.</param>
        /// <param name="depositDto">DTO with deposit details.</param>
        /// <returns>
        /// 200 OK response with a transaction object if the deposit is successful.
        /// 400 Bad Request response if the deposit data is invalid.
        /// 401 Unauthorized response if the user is not authorized.
        /// 404 Not Found response if the account or user is not found.
        /// </returns>

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("account/deposit/{id:int}")]

        public async Task<IActionResult> DepositAsync(int id, AccountDepositDto depositDto)
        {
           
            if(id != depositDto.Id)
            {
                _logger.LogInformation($"The ids introduced didnt match, dto = {depositDto}, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The ids introduced dont match");
            }

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
                Concept = TransactionConcept.Deposit
            };

            var baseApi = new BaseApi(_httpClient);

            var token = HttpContext.Request.Headers["Authorization"].ToString();

            var transaction = baseApi.PostToApi("transaction/create", transactionCreate, token);



            _logger.LogInformation($"Deposit Transaction was completed!, id = {id}, transaction = {transaction}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, $"The deposit transaction was completed! The new account balance is {acc.Balance + depositDto.Amount}");

        }

        /// <summary>
        /// Makes an extraction of money from a single account.
        /// </summary>
        /// <param name="id">ID of the account to extract from.</param>
        /// <param name="extractionDto">DTO (Data Transfer Object) with extraction details.</param>
        /// <returns>
        /// 200 OK response with a transaction object if the extraction is successful.
        /// 400 Bad Request response if the extraction data is invalid.
        /// 401 Unauthorized response if the user is not authorized.
        /// 404 Not Found response if the account, user, or extracted amount is not found.
        /// </returns>

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("account/extract/{id:int}")]

        public async Task<IActionResult> ExtractionAsync(int id, AccountExtractDto extractionDto)
        {
            if (id < 1)
            {
                _logger.LogInformation($"The ids introduced didnt match, dto = {extractionDto}, id = {id}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "The ids introduced dont match");
            }

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
                Concept = TransactionConcept.Extraction
            };
            
            var baseApi = new BaseApi(_httpClient);

            //Obtains the token
            var token = HttpContext.Request.Headers["Authorization"].ToString();

            var transaction = baseApi.PostToApi("transaction/create", transactionCreate, token);

            _logger.LogInformation($"Transaction was completed!, id = {id}, transaction = {transaction}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, $"The transaction was completed! The new account balance is {acc.Balance - extractionDto.Amount}");

        }


        /// <summary>
        /// Initiates a funds transfer between two accounts.
        /// </summary>
        /// <param name="transferDto">DTO (Data Transfer Object) with transfer details.</param>
        /// <returns>
        /// 200 OK response with a transaction object if the transfer is successful.
        /// 400 Bad Request response if the transfer data is invalid or the user is not authorized.
        /// 401 Unauthorized response if the user is not authenticated.
        /// 404 Not Found response if one or both of the accounts, amount, or concept is not found.
        /// </returns>

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("account/transfer")]

        public async Task<IActionResult> TransferAsync(TransferDto transferDto)
        {
            if(transferDto.DestinationAccountId < 1 || transferDto.DestinationAccountId < 1)
            {
                _logger.LogInformation($"One of the accounts introduced was invalid, dto = {transferDto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "One or both of the accounts introduced was invalid or it doesnt exist!");
            }

            if (transferDto.Amount <= 1)
            {
                _logger.LogInformation($"The amount introduced was invalid, dto = {transferDto}");
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.BadRequest, "Amount must be greater than 1");

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
                return ResponseFactory.CreateErrorResponse(HttpStatusCode.NotFound, "The selected origin account doesnt exist!");
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
                SourceAccountId = transferDto.OriginAccountId,
                DestinationAccountId = transferDto.DestinationAccountId,
                Concept = transferDto.Concept,
                Amount = transferDto.Amount,
                ClientId = clientId,
                Type = TransactionType.Transfer
            };

            var baseApi = new BaseApi(_httpClient);

            var token = HttpContext.Request.Headers["Authorization"].ToString();

            var transaction = baseApi.PostToApi("transaction/create", transactionCreate, token);


            _logger.LogInformation($"Transaction was completed!, id = {transferDto.OriginAccountId}, transaction = {transaction}");
            return ResponseFactory.CreateSuccessResponse(HttpStatusCode.OK, $"The transaction was completed! Your account balance is {acc.Balance - transferDto.Amount}");

        }



    }
}
