using BilleteraVirtualSofttekBack.Controllers;
using BilleteraVirtualSofttekBack.Models.DTOs.Account;
using BilleteraVirtualSofttekBack.Models.DTOs.Client;
using BilleteraVirtualSofttekBack.Models.DTOs.Transactions;
using BilleteraVirtualSofttekBack.Models.Enums;
using BilleteraVirtualSofttekBack.Models.Interfaces.ServiceInterfaces;
using IntegradorSofttekImanol.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;
using System.Security.Claims;


namespace VirtualWalletUnitTesting
{
    [TestClass]
    public class AccountControllerTest
    {

        [TestMethod]
        public async Task GetAllAccountsBy_InvalidPagination_ReturnError()
        {

            //Arrange

            var accounts = new List<AccountGetDto>
            {
                new AccountGetDto { Id = 1, UUID = "12345", AccountNumber = 1, CBU = 9876, Alias = "Alias1", Balance = 1000.00m, Type = "Peso", ClientId = 1 },
                new AccountGetDto { Id = 2, UUID = "54321", AccountNumber = 2, CBU = 5678, Alias = "Alias2", Balance = 2000.00m, Type = "Dollar", ClientId = 1 },
                new AccountGetDto { Id = 3, UUID = "67890", AccountNumber = 3, CBU = 1234, Alias = "Alias3", Balance = 3000.00m, Type = "Crypto", ClientId = 1 },
                new AccountGetDto { Id = 4, UUID = "98765", AccountNumber = 4, CBU = 4321, Alias = "Alias4", Balance = 4000.00m, Type = "Peso", ClientId = 1 },
                new AccountGetDto { Id = 5, UUID = "24680", AccountNumber = 5, CBU = 7890, Alias = "Alias5", Balance = 5000.00m, Type = "Dollar", ClientId = 1 },
                new AccountGetDto { Id = 3, UUID = "67890", AccountNumber = 3, CBU = 4321, Alias = "Alias3", Balance = 6000.00m, Type = "Crypto", ClientId = 1 },
            };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.GetAllAccounts(1,10)).ReturnsAsync(accounts);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.GetAllAccounts(0,0);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("There was an error in the pagination!", responseResult);


        }

        [TestMethod]
        public async Task GetAllAccountsBy_Valid_ReturnAccounts()
        {

            //Arrange

            var accounts = new List<AccountGetDto>
            {
                new AccountGetDto { Id = 1, UUID = "12345", AccountNumber = 1, CBU = 9876, Alias = "Alias1", Balance = 1000.00m, Type = "Peso", ClientId = 1 },
                new AccountGetDto { Id = 2, UUID = "54321", AccountNumber = 2, CBU = 5678, Alias = "Alias2", Balance = 2000.00m, Type = "Dollar", ClientId = 1 },
                new AccountGetDto { Id = 3, UUID = "67890", AccountNumber = 3, CBU = 1234, Alias = "Alias3", Balance = 3000.00m, Type = "Crypto", ClientId = 1 },
                new AccountGetDto { Id = 4, UUID = "98765", AccountNumber = 4, CBU = 4321, Alias = "Alias4", Balance = 4000.00m, Type = "Peso", ClientId = 1 },
                new AccountGetDto { Id = 5, UUID = "24680", AccountNumber = 5, CBU = 7890, Alias = "Alias5", Balance = 5000.00m, Type = "Dollar", ClientId = 1 },
                new AccountGetDto { Id = 3, UUID = "67890", AccountNumber = 3, CBU = 4321, Alias = "Alias3", Balance = 6000.00m, Type = "Crypto", ClientId = 1 },
            };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.GetAllAccounts(1, 10)).ReturnsAsync(accounts);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.GetAllAccounts(1, 10);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiSuccessResponse;
            var responseResult = response.Data as List<AccountGetDto>;

            ///Assert

            Assert.AreEqual(accounts, responseResult);


        }

        [TestMethod]
        public async Task GetAllAccountsByClient_InvalidClientId_ReturnError()
        {

            //Arrange

            var accounts = new List<AccountGetDto>
            {
                new AccountGetDto { Id = 1, UUID = "12345", AccountNumber = 1, CBU = 9876, Alias = "Alias1", Balance = 1000.00m, Type = "Peso", ClientId = 1 },
                new AccountGetDto { Id = 2, UUID = "54321", AccountNumber = 2, CBU = 5678, Alias = "Alias2", Balance = 2000.00m, Type = "Dollar", ClientId = 1 },
                new AccountGetDto { Id = 3, UUID = "67890", AccountNumber = 3, CBU = 1234, Alias = "Alias3", Balance = 3000.00m, Type = "Crypto", ClientId = 1 },
                new AccountGetDto { Id = 4, UUID = "98765", AccountNumber = 4, CBU = 4321, Alias = "Alias4", Balance = 4000.00m, Type = "Peso", ClientId = 1 },
                new AccountGetDto { Id = 5, UUID = "24680", AccountNumber = 5, CBU = 7890, Alias = "Alias5", Balance = 5000.00m, Type = "Dollar", ClientId = 1 },
                new AccountGetDto { Id = 3, UUID = "67890", AccountNumber = 3, CBU = 4321, Alias = "Alias3", Balance = 6000.00m, Type = "Crypto", ClientId = 1 },
            };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.GetAllAccountsByClientAsync(0,1,99)).ReturnsAsync(accounts);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.GetAllAccountsByClient(0);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("The client ID was invalid", responseResult);


        }

        [TestMethod]
        public async Task GetAllAccountsByClient_Valid_ReturnAccounts()
        {

            //Arrange

            var accounts = new List<AccountGetDto>
            {
                new AccountGetDto { Id = 1, UUID = "12345", AccountNumber = 1, CBU = 9876, Alias = "Alias1", Balance = 1000.00m, Type = "Peso", ClientId = 1 },
                new AccountGetDto { Id = 2, UUID = "54321", AccountNumber = 2, CBU = 5678, Alias = "Alias2", Balance = 2000.00m, Type = "Dollar", ClientId = 1 },
                new AccountGetDto { Id = 3, UUID = "67890", AccountNumber = 3, CBU = 1234, Alias = "Alias3", Balance = 3000.00m, Type = "Crypto", ClientId = 1 },
                new AccountGetDto { Id = 4, UUID = "98765", AccountNumber = 4, CBU = 4321, Alias = "Alias4", Balance = 4000.00m, Type = "Peso", ClientId = 1 },
                new AccountGetDto { Id = 5, UUID = "24680", AccountNumber = 5, CBU = 7890, Alias = "Alias5", Balance = 5000.00m, Type = "Dollar", ClientId = 1 },
                new AccountGetDto { Id = 3, UUID = "67890", AccountNumber = 3, CBU = 4321, Alias = "Alias3", Balance = 6000.00m, Type = "Crypto", ClientId = 1 },
            };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.GetAllAccountsByClientAsync(1,1,99)).ReturnsAsync(accounts);
            var controller = new AccountsController(mockService.Object,mockFactory.Object,mockLogger.Object);

            //Act

            var result = await controller.GetAllAccountsByClient(1);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiSuccessResponse;
            var responseResult = response.Data as List<AccountGetDto>;

            ///Assert

            CollectionAssert.AreEqual(accounts, responseResult);


        }

        [TestMethod]
        public async Task GetAccount_InvalidId_ReturnError()
        {

            //Arrange

            var account = new AccountGetDto { Id = 1, UUID = "12345", AccountNumber = 1, CBU = 9876, Alias = "Alias1", Balance = 1000.00m, Type = "Peso", ClientId = 1 };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.GetAccountByIdAsync(0)).ReturnsAsync(account);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.GetAccount(0);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("The ID introduced was invalid", responseResult);

        }

        [TestMethod]
        public async Task GetAccount_Valid_ReturnAccount()
        {

            //Arrange

            var account = new AccountGetDto { Id = 1, UUID = "12345", AccountNumber = 1, CBU = 9876, Alias = "Alias1", Balance = 1000.00m, Type = "Peso", ClientId = 1 };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.GetAccountByIdAsync(1)).ReturnsAsync(account);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.GetAccount(1);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiSuccessResponse;
            var responseResult = response.Data as AccountGetDto;

            ///Assert

            Assert.AreEqual(account, responseResult);

        }

        [TestMethod]
        public async Task GetAccount_AccountNotFound_ReturnAccount()
        {

            //Arrange

            AccountCreateDto account = new AccountCreateDto { Type = AccountType.Crypto, ClientId = 1 };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.CreateAccountAsync(account)).ReturnsAsync(false);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.GetAccount(2);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("The account with the specified ID wasn't found!", responseResult);

        }

        [TestMethod]
        public async Task CreateAccount_InvalidType_ReturnError()
        {

            //Arrange

            AccountCreateDto account = new AccountCreateDto { ClientId = 1 };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.CreateAccountAsync(account)).ReturnsAsync(false);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.CreateAccount(account);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("The account type submitted was incorrect!", responseResult);

        }

        [TestMethod]
        public async Task CreateAccount_InvalidAccount_ReturnError()
        {

            //Arrange

            AccountCreateDto account = new AccountCreateDto { Type = AccountType.Crypto , ClientId = 1 };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.CreateAccountAsync(account)).ReturnsAsync(false);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.CreateAccount(account);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("The account couldn't be created!", responseResult);

        }

        [TestMethod]
        public async Task CreateAccount_Valid_ReturnSuccess()
        {

            //Arrange

            AccountCreateDto account = new AccountCreateDto { Type = AccountType.Crypto, ClientId = 1 };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.CreateAccountAsync(account)).ReturnsAsync(true);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.CreateAccount(account);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiSuccessResponse;
            var responseResult = response.Data as string;

            ///Assert

            Assert.AreEqual("The account was created!", responseResult);

        }

        [TestMethod]
        public async Task UpdateAccount_InvalidIds_ReturnError()
        {

            //Arrange

            AccountUpdateDto account = new AccountUpdateDto { Type = AccountType.Crypto, ClientId = 1, AccountId = 1 };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.UpdateAccount(account)).ReturnsAsync(false);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.UpdateAccount(2, account);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("The entered ids dont match!", responseResult);

        }

        [TestMethod]
        public async Task UpdateAccount_InvalidAccountType_ReturnError()
        {

            //Arrange

            AccountUpdateDto account = new AccountUpdateDto {  ClientId = 1, AccountId = 1 };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.UpdateAccount(account)).ReturnsAsync(false);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.UpdateAccount(1, account);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("The account type submitted was incorrect!", responseResult);

        }

        [TestMethod]
        public async Task UpdateAccount_CryptoNeedsUUID_ReturnError()
        {

            //Arrange

            AccountUpdateDto account = new AccountUpdateDto { Type = AccountType.Crypto, ClientId = 1, AccountId = 1 };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.UpdateAccount(account)).ReturnsAsync(false);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.UpdateAccount(1, account);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("A Crypto account needs a valid UUID!", responseResult);

        }

        [TestMethod]
        public async Task UpdateAccount_CryptoAlias_ReturnError()
        {

            //Arrange

            AccountUpdateDto account = new AccountUpdateDto { Type = AccountType.Crypto, ClientId = 1, AccountId = 1, UUID = "xxxxx", Alias = "xxxxx" };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.UpdateAccount(account)).ReturnsAsync(false);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.UpdateAccount(1, account);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("A Crypto account can't have fiduciary values!", responseResult);

        }

        [TestMethod]
        public async Task UpdateAccount_FiduciaryIncomplete_ReturnError()
        {

            //Arrange

            AccountUpdateDto account = new AccountUpdateDto { Type = AccountType.Dollar, ClientId = 1, AccountId = 1, Alias = "xxxxx" };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.UpdateAccount(account)).ReturnsAsync(false);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.UpdateAccount(1, account);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("A Fiduciary account needs a valid Account number, AccountId, and CBU", responseResult);

        }

        [TestMethod]
        public async Task UpdateAccount_FiduciaryWithUUID_ReturnError()
        {

            //Arrange

            AccountUpdateDto account = new AccountUpdateDto { Type = AccountType.Dollar, ClientId = 1, AccountId = 1,UUID = "xxxxx", CBU = 23, AccountNumber = 42 ,Alias = "xxxxx" };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.UpdateAccount(account)).ReturnsAsync(false);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.UpdateAccount(1, account);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("A Fiduciary account can't have a UUID!", responseResult);

        }

        [TestMethod]
        public async Task UpdateAccount_InvalidBalance_ReturnError()
        {

            //Arrange

            AccountUpdateDto account = new AccountUpdateDto { Balance = 0, Type = AccountType.Dollar, ClientId = 1, AccountId = 1, CBU = 23, AccountNumber = 42, Alias = "xxxxx" };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.UpdateAccount(account)).ReturnsAsync(false);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.UpdateAccount(1, account);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("Amount must be greater than 1", responseResult);

        }

        [TestMethod]
        public async Task UpdateAccount_GeneralInvalid_ReturnError()
        {

            //Arrange

            AccountUpdateDto account = new AccountUpdateDto { Balance = 100, Type = AccountType.Dollar, ClientId = 1, AccountId = 1, CBU = 23, AccountNumber = 42, Alias = "xxxxx" };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.UpdateAccount(account)).ReturnsAsync(false);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.UpdateAccount(1, account);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("There was an error with the data you introduced, Account wasn't created!", responseResult);

        }

        [TestMethod]
        public async Task UpdateAccount_ValidUpdate_ReturnUpdated()
        {

            //Arrange

            AccountUpdateDto account = new AccountUpdateDto { Balance = 100, Type = AccountType.Dollar, ClientId = 1, AccountId = 1, CBU = 23, AccountNumber = 42, Alias = "xxxxx" };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.UpdateAccount(account)).ReturnsAsync(true);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.UpdateAccount(1, account);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiSuccessResponse;
            var responseResult = response.Data as string;

            ///Assert

            Assert.AreEqual("Account was properly updated!", responseResult);

        }

        [TestMethod]
        public async Task DeleteAccount_InvalidId_ReturnError()
        {

            //Arrange

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.DeleteAccountAsync(0)).ReturnsAsync(false);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.DeleteAccount(0);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("The id introduced was invalid!", responseResult);

        }

        [TestMethod]
        public async Task DeleteAccount_Valid_ReturnSuccess()
        {

            //Arrange

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.DeleteAccountAsync(1)).ReturnsAsync(true);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.DeleteAccount(1);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiSuccessResponse;
            var responseResult = response.Data as string;

            ///Assert

            Assert.AreEqual("The Account was deleted!", responseResult);

        }

        [TestMethod]
        public async Task DepositAsync_InvalidAmount_ReturnError()
        {

            //Arrange

            AccountDepositDto deposit = new AccountDepositDto()
            {
                Id = 1,
                Amount = 0m,
                ClientId = 1
            };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.DepositAsync(deposit)).ReturnsAsync(false);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.DepositAsync(deposit.Id, deposit);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("Amount must be greater than 1", responseResult);

        }

        [TestMethod]
        public async Task DepositAsync_DifferentIds_ReturnError()
        {

            //Arrange

            AccountDepositDto deposit = new AccountDepositDto()
            {
                Id = 1,
                Amount = 1000m,
                ClientId = 1
            };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.DepositAsync(deposit)).ReturnsAsync(false);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.DepositAsync(2, deposit);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("The ids introduced dont match", responseResult);

        }

        [TestMethod]
        public async Task DepositAsync_AccountNotFound_ReturnError()
        {

            //Arrange

            AccountDepositDto deposit = new AccountDepositDto()
            {
                Id = 1,
                Amount = 1000m,
                ClientId = 2
            };

            AccountGetDto account = null;

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.GetAccountByIdAsync(2)).ReturnsAsync(account);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.DepositAsync(1, deposit);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("The selected account doesnt exist!", responseResult);

        }

        [TestMethod]
        public async Task DepositAsync_InvalidDeposit_ReturnError()
        {

            //Arrange

            AccountDepositDto deposit = new AccountDepositDto()
            {
                Id = 1,
                Amount = 1000m,
                ClientId = 2
            };

            AccountGetDto account = new AccountGetDto { Id = 1, ClientId = 2 };


            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.DepositAsync(deposit)).ReturnsAsync(false);
            mockService.Setup(service => service.GetAccountByIdAsync(1)).ReturnsAsync(account);
            var mockHttpContext = new Mock<HttpContext>();
            var mockUser = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
               new Claim("NameIdentifier", "1"),
            }));
            mockHttpContext.Setup(context => context.User).Returns(mockUser);

            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            controller.ControllerContext.HttpContext = mockHttpContext.Object;


            //Act

            var result = await controller.DepositAsync(1, deposit);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("The user in the token doesnt match with the account user!", responseResult);

        }

        [TestMethod]
        public async Task DepositAsync_TokenMismatch_ReturnError()
        {

            //Arrange

            AccountDepositDto deposit = new AccountDepositDto()
            {
                Id = 1,
                Amount = 1000m,
                ClientId = 2
            };

            AccountGetDto account = new AccountGetDto { Id = 1, ClientId = 2};


            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.DepositAsync(deposit)).ReturnsAsync(false);
            mockService.Setup(service => service.GetAccountByIdAsync(1)).ReturnsAsync(account);
            var mockHttpContext = new Mock<HttpContext>();
            var mockUser = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
               new Claim("NameIdentifier", "2"),                            
            }));
            mockHttpContext.Setup(context => context.User).Returns(mockUser);

            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            controller.ControllerContext.HttpContext = mockHttpContext.Object;


            //Act

            var result = await controller.DepositAsync(1, deposit);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("There was a problem with the deposit!", responseResult);

        }

        [TestMethod]
        public async Task DepositAsync_Valid_ReturnTransaction()
        {

            //Arrange

            AccountDepositDto deposit = new AccountDepositDto()
            {
                Id = 1,
                Amount = 1000m,
                ClientId = 2
            };

            AccountGetDto account = new AccountGetDto { Id = 1, ClientId = 2 };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.DepositAsync(deposit)).ReturnsAsync(true);
            mockService.Setup(service => service.GetAccountByIdAsync(1)).ReturnsAsync(account);

            //Mocking the httpContext
            var mockHttpContext = new Mock<HttpContext>();
            var mockUser = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
               new Claim("NameIdentifier", "2"),
            }));
            mockHttpContext.Setup(context => context.User).Returns(mockUser);
            mockHttpContext.Setup(context => context.Request.Headers["Authorization"]).Returns("xxxxxx");

            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            controller.ControllerContext.HttpContext = mockHttpContext.Object;


            //Act

            var result = await controller.DepositAsync(1, deposit);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiSuccessResponse;
            var responseResult = response.StatusCode;

            ///Assert

            Assert.AreEqual(HttpStatusCode.OK, responseResult);

        }

        [TestMethod]
        public async Task ExtractionAsync_InvalidAmount_ReturnError()
        {

            //Arrange

            AccountExtractDto extract = new AccountExtractDto()
            {
                Id = 1,
                Amount = 0m,
                
            };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.ExtractAsync(extract)).ReturnsAsync(false);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.ExtractionAsync(extract.Id, extract);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("Amount must be greater than 1", responseResult);

        }

        [TestMethod]
        public async Task ExtractAsync_DifferentIds_ReturnError()
        {

            //Arrange

            AccountExtractDto extract = new AccountExtractDto()
            {
                Id = 1,
                Amount = 1000m
            };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.ExtractAsync(extract)).ReturnsAsync(false);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.ExtractionAsync(2, extract);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("Ids dont match!", responseResult);

        }

        
        [TestMethod]
        public async Task ExtractionAsync_AccountNotFound_ReturnError()
        {

            //Arrange

            AccountExtractDto extract = new AccountExtractDto()
            {
                Id = 1,
                Amount = 1000m
            };

            AccountGetDto account = null;

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.GetAccountByIdAsync(1)).ReturnsAsync(account);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.ExtractionAsync(1, extract);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("The selected account doesnt exist!", responseResult);

        }


        
        [TestMethod]
        public async Task ExtractAsync_TokenMismatch_ReturnError()
        {

            //Arrange

            AccountExtractDto extract = new AccountExtractDto()
            {
                Id = 1,
                Amount = 1000m
            };

            AccountGetDto account = new AccountGetDto { Id = 1, ClientId = 2, Balance = 2000 };


            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.ExtractAsync(extract)).ReturnsAsync(false);
            mockService.Setup(service => service.GetAccountByIdAsync(1)).ReturnsAsync(account);
            var mockHttpContext = new Mock<HttpContext>();
            var mockUser = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
               new Claim("NameIdentifier", "1"),
            }));
            mockHttpContext.Setup(context => context.User).Returns(mockUser);

            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            controller.ControllerContext.HttpContext = mockHttpContext.Object;


            //Act

            var result = await controller.ExtractionAsync(1, extract);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("The user in the token doesnt match with the account user!", responseResult);

        }

        
        [TestMethod]
        public async Task ExtractAsync_InvalidDeposit_ReturnError()
        {

            //Arrange

            AccountExtractDto extract = new AccountExtractDto()
            {
                Id = 1,
                Amount = 1000m
            };

            AccountGetDto account = new AccountGetDto { Id = 1, ClientId = 2 };


            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.ExtractAsync(extract)).ReturnsAsync(false);
            mockService.Setup(service => service.GetAccountByIdAsync(1)).ReturnsAsync(account);
            var mockHttpContext = new Mock<HttpContext>();
            var mockUser = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
               new Claim("NameIdentifier", "2"),
            }));
            mockHttpContext.Setup(context => context.User).Returns(mockUser);

            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            controller.ControllerContext.HttpContext = mockHttpContext.Object;


            //Act

            var result = await controller.ExtractionAsync(1, extract);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("You dont have enough funds for that extraction!", responseResult);

        }

        [TestMethod]
        public async Task ExtractAsync_Valid_ReturnTransaction()
        {

            //Arrange

            AccountExtractDto extract = new AccountExtractDto()
            {
                Id = 1,
                Amount = 1000m
            };

            AccountGetDto account = new AccountGetDto { Id = 1, ClientId = 2, Balance = 2000 };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.ExtractAsync(extract)).ReturnsAsync(true);
            mockService.Setup(service => service.GetAccountByIdAsync(1)).ReturnsAsync(account);

            //Mocking the httpContext
            var mockHttpContext = new Mock<HttpContext>();
            var mockUser = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
               new Claim("NameIdentifier", "2"),
            }));
            mockHttpContext.Setup(context => context.User).Returns(mockUser);
            mockHttpContext.Setup(context => context.Request.Headers["Authorization"]).Returns("xxxxxx");

            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            controller.ControllerContext.HttpContext = mockHttpContext.Object;


            //Act

            var result = await controller.ExtractionAsync(1, extract);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiSuccessResponse;
            var responseResult = response.StatusCode;

            ///Assert

            Assert.AreEqual(HttpStatusCode.OK, responseResult);

        }

        [TestMethod]
        public async Task TransferAsync_InvalidAmount_ReturnError()
        {

            //Arrange

            TransferDto transfer = new TransferDto()
            {
                OriginAccountId = 1,
                DestinationAccountId = 2,
                Concept = TransactionConcept.Gambling,
                Amount = 0m

            };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.TransferAsync(transfer)).ReturnsAsync(false);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.TransferAsync(transfer);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("Amount must be greater than 1", responseResult);

        }

        [TestMethod]
        public async Task TransferAsync_SameAccountIds_ReturnError()
        {

            //Arrange

            TransferDto transfer = new TransferDto()
            {
                OriginAccountId = 1,
                DestinationAccountId = 1,
                Concept = TransactionConcept.Gambling,
                Amount = 1000m

            };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.TransferAsync(transfer)).ReturnsAsync(false);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.TransferAsync(transfer);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("The accounts cant be the same!", responseResult);

        }


        [TestMethod]
        public async Task TransferAsync_AccountNotFound_ReturnError()
        {

            //Arrange

            TransferDto transfer = new TransferDto()
            {
                OriginAccountId = 1,
                DestinationAccountId = 2,
                Concept = TransactionConcept.Gambling,
                Amount = 1000m

            };

            AccountGetDto account = null;

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.GetAccountByIdAsync(1)).ReturnsAsync(account);
            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            //Act

            var result = await controller.TransferAsync(transfer);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("The selected origin account doesnt exist!", responseResult);

        }



        [TestMethod]
        public async Task TransferAsync_TokenMismatch_ReturnError()
        {

            //Arrange

            TransferDto transfer = new TransferDto()
            {
                OriginAccountId = 1,
                DestinationAccountId = 2,
                Concept = TransactionConcept.Gambling,
                Amount = 1000m

            };

            AccountGetDto account = new AccountGetDto { Id = 2, ClientId = 2 };


            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.TransferAsync(transfer)).ReturnsAsync(false);
            mockService.Setup(service => service.GetAccountByIdAsync(1)).ReturnsAsync(account);
            var mockHttpContext = new Mock<HttpContext>();
            var mockUser = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
               new Claim("NameIdentifier", "1"),
            }));
            mockHttpContext.Setup(context => context.User).Returns(mockUser);

            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            controller.ControllerContext.HttpContext = mockHttpContext.Object;


            //Act

            var result = await controller.TransferAsync(transfer);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("The user in the token doesnt match with the account user!", responseResult);

        }


        [TestMethod]
        public async Task TransferAsync_NotEnoughFunds_ReturnError()
        {

            //Arrange

            TransferDto transfer = new TransferDto()
            {
                OriginAccountId = 1,
                DestinationAccountId = 2,
                Concept = TransactionConcept.Gambling,
                Amount = 1000m

            };

            AccountGetDto account = new AccountGetDto { Id = 1, ClientId = 2, Balance = 500 };


            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.TransferAsync(transfer)).ReturnsAsync(false);
            mockService.Setup(service => service.GetAccountByIdAsync(1)).ReturnsAsync(account);
            var mockHttpContext = new Mock<HttpContext>();
            var mockUser = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
               new Claim("NameIdentifier", "2"),
            }));
            mockHttpContext.Setup(context => context.User).Returns(mockUser);

            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            controller.ControllerContext.HttpContext = mockHttpContext.Object;


            //Act

            var result = await controller.TransferAsync(transfer);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("There arent enough funds to make this transaction!", responseResult);

        }

        [TestMethod]
        public async Task ExtractAsync_GeneralInvalid_ReturnTransaction()
        {

            //Arrange


            TransferDto transfer = new TransferDto()
            {
                OriginAccountId = 1,
                DestinationAccountId = 2,
                Concept = TransactionConcept.Gambling,
                Amount = 1000m

            };

            AccountGetDto account = new AccountGetDto { Id = 2, ClientId = 1 , Balance = 1500m};

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.TransferAsync(transfer)).ReturnsAsync(false);
            mockService.Setup(service => service.GetAccountByIdAsync(1)).ReturnsAsync(account);

            //Mocking the httpContext
            var mockHttpContext = new Mock<HttpContext>();
            var mockUser = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
               new Claim("NameIdentifier", "1"),
            }));
            mockHttpContext.Setup(context => context.User).Returns(mockUser);
            mockHttpContext.Setup(context => context.Request.Headers["Authorization"]).Returns("xxxxxx");

            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            controller.ControllerContext.HttpContext = mockHttpContext.Object;


            //Act

            var result = await controller.TransferAsync(transfer);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiErrorResponse;
            var responseResult = response.Errors[0].Error as string;

            ///Assert

            Assert.AreEqual("There was a problem with the transfer! You can't buy Crypto with Pesos or Pesos with Crypto!", responseResult);

        }

        [TestMethod]
        public async Task TransferAsync_Valid_ReturnTransaction()
        {

            //Arrange

            TransferDto transfer = new TransferDto()
            {
                OriginAccountId = 1,
                DestinationAccountId = 2,
                Concept = TransactionConcept.Gambling,
                Amount = 1000m

            };

            AccountGetDto account = new AccountGetDto { Id = 2, ClientId = 2, Balance = 20000 };

            var mockService = new Mock<IAccountService>();
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockLogger = new Mock<ILogger<AccountsController>>();

            mockService.Setup(service => service.TransferAsync(transfer)).ReturnsAsync(true);
            mockService.Setup(service => service.GetAccountByIdAsync(1)).ReturnsAsync(account);

            //Mocking the httpContext
            var mockHttpContext = new Mock<HttpContext>();
            var mockUser = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
               new Claim("NameIdentifier", "2"),
            }));
            mockHttpContext.Setup(context => context.User).Returns(mockUser);
            mockHttpContext.Setup(context => context.Request.Headers["Authorization"]).Returns("xxxxxx");

            var controller = new AccountsController(mockService.Object, mockFactory.Object, mockLogger.Object);

            controller.ControllerContext.HttpContext = mockHttpContext.Object;


            //Act

            var result = await controller.TransferAsync(transfer);
            var objectResult = result as ObjectResult;
            var response = objectResult.Value as ApiSuccessResponse;
            var responseResult = response.StatusCode;

            ///Assert

            Assert.AreEqual(HttpStatusCode.OK, responseResult);

        }


    }
}
