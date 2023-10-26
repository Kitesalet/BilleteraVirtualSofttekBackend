using BilleteraVirtualSofttekBack.Controllers;
using BilleteraVirtualSofttekBack.Models.DTOs.Account;
using BilleteraVirtualSofttekBack.Models.DTOs.Client;
using BilleteraVirtualSofttekBack.Models.DTOs.Transactions;
using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Enums;
using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWalletUnitTesting
{
    [TestClass]
    public class TransactionControllerTest
    {

        [TestMethod]
        public async Task GetAllTransactions_InvalidPagination_ReturnError()
        {

            //Arrange

            var transactions = new List<TransactionGetMinDto>
            {
                new TransactionGetMinDto { Amount = 100.50m, Type = "Deposit", Concept = TransactionConcept.Deposit.ToString(), SourceAccountId = 1, DestinationAccountId = 1, CreatedDate = DateTime.Now },
                new TransactionGetMinDto { Amount = 300.25m, Type = "Extraction", Concept = TransactionConcept.Deposit.ToString(), SourceAccountId = 2, DestinationAccountId = 2, CreatedDate = DateTime.Now.AddMinutes(15) },
                new TransactionGetMinDto { Amount = 50.00m, Type = "Transfer", Concept = TransactionConcept.Deposit.ToString(), SourceAccountId = 3, DestinationAccountId = 3, CreatedDate = DateTime.Now.AddMinutes(30) },
                new TransactionGetMinDto { Amount = 200.75m, Type = "Deposit", Concept = TransactionConcept.Deposit.ToString(), SourceAccountId = 4, DestinationAccountId = 4, CreatedDate = DateTime.Now.AddMinutes(45) },
                new TransactionGetMinDto { Amount = 70.20m, Type = "Transfer", Concept = TransactionConcept.Deposit.ToString(), SourceAccountId = 5, DestinationAccountId = 5, CreatedDate = DateTime.Now.AddMinutes(60) }
            };

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.GetAllTransactionsAsync(0, 0)).ReturnsAsync(transactions);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);
            

            //Act

            var result = await controller.GetAllTransactions(0,0);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiErrorResponse;
            var finalResult = value.Errors[0].Error;


            //Assert

            Assert.AreEqual("There was an error in the pagination!", finalResult);

        }

        [TestMethod]
        public async Task GetAllTransactions_Valid_ReturnTransactions()
        {

            //Arrange

            var transactions = new List<TransactionGetMinDto>
            {
                new TransactionGetMinDto { Amount = 100.50m, Type = "Deposit", Concept = TransactionConcept.Deposit.ToString(), SourceAccountId = 1, DestinationAccountId = 1, CreatedDate = DateTime.Now },
                new TransactionGetMinDto { Amount = 300.25m, Type = "Extraction", Concept = TransactionConcept.Deposit.ToString(), SourceAccountId = 2, DestinationAccountId = 2, CreatedDate = DateTime.Now.AddMinutes(15) },
                new TransactionGetMinDto { Amount = 50.00m, Type = "Transfer", Concept = TransactionConcept.Deposit.ToString(), SourceAccountId = 3, DestinationAccountId = 3, CreatedDate = DateTime.Now.AddMinutes(30) },
                new TransactionGetMinDto { Amount = 200.75m, Type = "Deposit", Concept = TransactionConcept.Deposit.ToString(), SourceAccountId = 4, DestinationAccountId = 4, CreatedDate = DateTime.Now.AddMinutes(45) },
                new TransactionGetMinDto { Amount = 70.20m, Type = "Transfer", Concept = TransactionConcept.Deposit.ToString(), SourceAccountId = 5, DestinationAccountId = 5, CreatedDate = DateTime.Now.AddMinutes(60) }
            };

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.GetAllTransactionsAsync(1, 10)).ReturnsAsync(transactions);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.GetAllTransactions(1, 10);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiSuccessResponse;
            var finalResult = value.Data as List<TransactionGetDto>;


            //Assert

            CollectionAssert.Equals(transactions, finalResult);

        }

        [TestMethod]
        public async Task GetAllTransactionsByAccount_InvalidAccountId_ReturnError()
        {

            //Arrange

            var transactions = new List<TransactionGetDto>
            {
                new TransactionGetDto { Amount = 100.50m, Type = "Deposit", Concept = TransactionConcept.Deposit.ToString(), SourceAccount = new AccountGetDto { Id = 1, UUID = "12345", AccountNumber = 1, CBU = 9876, Alias = "Account1", Balance = 2500.00m, Type = "Peso", ClientId = 1 }, DestinationAccount = new AccountGetDto { Id = 2, UUID = "54321", AccountNumber = 202, CBU = 5678, Alias = "Account2", Balance = 4500.00m, Type = "Dollar", ClientId = 2 }, CreatedDate = DateTime.Now },
                new TransactionGetDto { Amount = 300.25m, Type = "Extraction", Concept = TransactionConcept.Deposit.ToString(), SourceAccount = new AccountGetDto { Id = 2, UUID = "54321", AccountNumber = 1, CBU = 5678, Alias = "Account2", Balance = 4200.00m, Type = "Dollar", ClientId = 2 }, DestinationAccount = new AccountGetDto { Id = 1, UUID = "12345", AccountNumber = 101, CBU = 9876, Alias = "Account1", Balance = 2700.00m, Type = "Peso", ClientId = 1 }, CreatedDate = DateTime.Now.AddMinutes(15) },
                new TransactionGetDto { Amount = 50.00m, Type = "Transfer", Concept = TransactionConcept.Deposit.ToString(), SourceAccount = new AccountGetDto { Id = 1, UUID = "12345", AccountNumber = 101, CBU = 1, Alias = "Account1", Balance = 2650.00m, Type = "Peso", ClientId = 1 }, DestinationAccount = new AccountGetDto { Id = 3, UUID = "67890", AccountNumber = 303, CBU = 1234, Alias = "Account3", Balance = 3500.00m, Type = "Crypto", ClientId = 3 }, CreatedDate = DateTime.Now.AddMinutes(30) },
                new TransactionGetDto { Amount = 200.75m, Type = "Deposit", Concept = TransactionConcept.Deposit.ToString(), SourceAccount = new AccountGetDto { Id = 4, UUID = "98765", AccountNumber = 1, CBU = 4321, Alias = "Account4", Balance = 3200.00m, Type = "Peso", ClientId = 4 }, DestinationAccount = new AccountGetDto { Id = 5, UUID = "24680", AccountNumber = 505, CBU = 7890, Alias = "Account5", Balance = 5600.00m, Type = "Dollar", ClientId = 5 }, CreatedDate = DateTime.Now.AddMinutes(45) },
                new TransactionGetDto { Amount = 70.20m, Type = "Transfer", Concept = TransactionConcept.Deposit.ToString(), SourceAccount = new AccountGetDto { Id = 3, UUID = "67890", AccountNumber = 1, CBU = 1234, Alias = "Account3", Balance = 3450.00m, Type = "Crypto", ClientId = 3 }, DestinationAccount = new AccountGetDto { Id = 2, UUID = "54321", AccountNumber = 202, CBU = 5678, Alias = "Account2", Balance = 4400.00m, Type = "Dollar", ClientId = 2 }, CreatedDate = DateTime.Now.AddMinutes(60) }
            };

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.GetTransactionsByClient(1,1,99)).ReturnsAsync(transactions);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.GetAllTransactionsByAccount(0);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiErrorResponse;
            var finalResult = value.Errors[0].Error;


            //Assert

            Assert.AreEqual("The account id is invalid!", finalResult);

        }

        [TestMethod]
        public async Task GetAllTransactionsByClient_ClientNotdFound_ReturnError()
        {

            //Arrange

            List<TransactionGetDto> transactions = null;

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.GetTransactionsByClient(1,1,99)).ReturnsAsync(transactions);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.GetAllTransactionsByClient(1);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiErrorResponse;
            var finalResult = value.Errors[0].Error;


            //Assert

            Assert.AreEqual("The client was not found!", finalResult);

        }

        [TestMethod]
        public async Task GetAllTransactionsByClient_InvalidId_ReturnError()
        {

            //Arrange

            List<TransactionGetDto> transactions = null;

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.GetTransactionsByClient(1,1,99)).ReturnsAsync(transactions);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.GetAllTransactionsByClient(0);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiErrorResponse;
            var finalResult = value.Errors[0].Error;


            //Assert

            Assert.AreEqual("The client id is invalid!", finalResult);

        }

        [TestMethod]
        public async Task GetAllTransactionsByClient_Valid_ReturnTransactions()
        {

            //Arrange

            var transactions = new List<TransactionGetDto>
            {
                new TransactionGetDto { Amount = 100.50m, Type = "Deposit", Concept = TransactionConcept.Deposit.ToString(), SourceAccount = new AccountGetDto { Id = 1, UUID = "12345", AccountNumber = 1, CBU = 9876, Alias = "Account1", Balance = 2500.00m, Type = "Peso", ClientId = 1 }, DestinationAccount = new AccountGetDto { Id = 2, UUID = "54321", AccountNumber = 202, CBU = 5678, Alias = "Account2", Balance = 4500.00m, Type = "Dollar", ClientId = 3 }, CreatedDate = DateTime.Now },
                new TransactionGetDto { Amount = 300.25m, Type = "Extraction", Concept = TransactionConcept.Deposit.ToString(), SourceAccount = new AccountGetDto { Id = 2, UUID = "54321", AccountNumber = 1, CBU = 5678, Alias = "Account2", Balance = 4200.00m, Type = "Dollar", ClientId = 2 }, DestinationAccount = new AccountGetDto { Id = 1, UUID = "12345", AccountNumber = 101, CBU = 9876, Alias = "Account1", Balance = 2700.00m, Type = "Peso", ClientId = 3 }, CreatedDate = DateTime.Now.AddMinutes(15) },
                new TransactionGetDto { Amount = 50.00m, Type = "Transfer", Concept = TransactionConcept.Deposit.ToString(), SourceAccount = new AccountGetDto { Id = 1, UUID = "12345", AccountNumber = 101, CBU = 1, Alias = "Account1", Balance = 2650.00m, Type = "Peso", ClientId = 1 }, DestinationAccount = new AccountGetDto { Id = 3, UUID = "67890", AccountNumber = 303, CBU = 1234, Alias = "Account3", Balance = 3500.00m, Type = "Crypto", ClientId = 3 }, CreatedDate = DateTime.Now.AddMinutes(30) },
                new TransactionGetDto { Amount = 200.75m, Type = "Deposit", Concept = TransactionConcept.Deposit.ToString(), SourceAccount = new AccountGetDto { Id = 4, UUID = "98765", AccountNumber = 1, CBU = 4321, Alias = "Account4", Balance = 3200.00m, Type = "Peso", ClientId = 4 }, DestinationAccount = new AccountGetDto { Id = 5, UUID = "24680", AccountNumber = 505, CBU = 7890, Alias = "Account5", Balance = 5600.00m, Type = "Dollar", ClientId = 3 }, CreatedDate = DateTime.Now.AddMinutes(45) },
                new TransactionGetDto { Amount = 70.20m, Type = "Transfer", Concept = TransactionConcept.Deposit.ToString(), SourceAccount = new AccountGetDto { Id = 3, UUID = "67890", AccountNumber = 1, CBU = 1234, Alias = "Account3", Balance = 3450.00m, Type = "Crypto", ClientId = 3 }, DestinationAccount = new AccountGetDto { Id = 2, UUID = "54321", AccountNumber = 202, CBU = 5678, Alias = "Account2", Balance = 4400.00m, Type = "Dollar", ClientId = 3 }, CreatedDate = DateTime.Now.AddMinutes(60) }
            };

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.GetTransactionsByClient(20, 20, 20)).ReturnsAsync(transactions);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.GetAllTransactionsByClient(20,20,20);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiSuccessResponse;
            var finalResult = value.Data;


            //Assert

            CollectionAssert.Equals(transactions, finalResult);

        }

        [TestMethod]
        public async Task GetAllTransactionsByAccount_AccountNotdFound_ReturnError()
        {

            //Arrange

            List<TransactionGetDto> transactions = null;

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.GetTransactionsByClient(1,1,99)).ReturnsAsync(transactions);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.GetAllTransactionsByAccount(1);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiErrorResponse;
            var finalResult = value.Errors[0].Error;


            //Assert

            Assert.AreEqual("The account was not found!", finalResult);

        }

        [TestMethod]
        public async Task GetAllTransactionsByAccount_Valid_ReturnTransactions()
        {

            //Arrange

            var transactions = new List<TransactionGetDto>
            {
                new TransactionGetDto { Amount = 100.50m, Type = "Deposit", Concept = TransactionConcept.Deposit.ToString(), SourceAccount = new AccountGetDto { Id = 1, UUID = "12345", AccountNumber = 1, CBU = 9876, Alias = "Account1", Balance = 2500.00m, Type = "Peso", ClientId = 1 }, DestinationAccount = new AccountGetDto { Id = 2, UUID = "54321", AccountNumber = 202, CBU = 5678, Alias = "Account2", Balance = 4500.00m, Type = "Dollar", ClientId = 2 }, CreatedDate = DateTime.Now },
                new TransactionGetDto { Amount = 300.25m, Type = "Extraction", Concept = TransactionConcept.Deposit.ToString(), SourceAccount = new AccountGetDto { Id = 2, UUID = "54321", AccountNumber = 1, CBU = 5678, Alias = "Account2", Balance = 4200.00m, Type = "Dollar", ClientId = 2 }, DestinationAccount = new AccountGetDto { Id = 1, UUID = "12345", AccountNumber = 101, CBU = 9876, Alias = "Account1", Balance = 2700.00m, Type = "Peso", ClientId = 1 }, CreatedDate = DateTime.Now.AddMinutes(15) },
                new TransactionGetDto { Amount = 50.00m, Type = "Transfer", Concept = TransactionConcept.Deposit.ToString(), SourceAccount = new AccountGetDto { Id = 1, UUID = "12345", AccountNumber = 101, CBU = 1, Alias = "Account1", Balance = 2650.00m, Type = "Peso", ClientId = 1 }, DestinationAccount = new AccountGetDto { Id = 3, UUID = "67890", AccountNumber = 303, CBU = 1234, Alias = "Account3", Balance = 3500.00m, Type = "Crypto", ClientId = 3 }, CreatedDate = DateTime.Now.AddMinutes(30) },
                new TransactionGetDto { Amount = 200.75m, Type = "Deposit", Concept = TransactionConcept.Deposit.ToString(), SourceAccount = new AccountGetDto { Id = 4, UUID = "98765", AccountNumber = 1, CBU = 4321, Alias = "Account4", Balance = 3200.00m, Type = "Peso", ClientId = 4 }, DestinationAccount = new AccountGetDto { Id = 5, UUID = "24680", AccountNumber = 505, CBU = 7890, Alias = "Account5", Balance = 5600.00m, Type = "Dollar", ClientId = 5 }, CreatedDate = DateTime.Now.AddMinutes(45) },
                new TransactionGetDto { Amount = 70.20m, Type = "Transfer", Concept = TransactionConcept.Deposit.ToString(), SourceAccount = new AccountGetDto { Id = 3, UUID = "67890", AccountNumber = 1, CBU = 1234, Alias = "Account3", Balance = 3450.00m, Type = "Crypto", ClientId = 3 }, DestinationAccount = new AccountGetDto { Id = 2, UUID = "54321", AccountNumber = 202, CBU = 5678, Alias = "Account2", Balance = 4400.00m, Type = "Dollar", ClientId = 2 }, CreatedDate = DateTime.Now.AddMinutes(60) }
            };

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.GetTransactionsByAccount(20, 20, 20)).ReturnsAsync(transactions);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.GetAllTransactionsByAccount(20,20,20);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiSuccessResponse;
            var finalResult = value.Data;


            //Assert

            CollectionAssert.Equals(transactions, finalResult);

        }

        [TestMethod]
        public async Task GetTransactionById_AccountNotdFound_ReturnError()
        {

            //Arrange

            TransactionGetDto transactions = new TransactionGetDto { Amount = 100.50m, Type = "Deposit", Concept = TransactionConcept.Deposit.ToString(), 
                SourceAccount = new AccountGetDto { Id = 1, UUID = "12345", AccountNumber = 1, CBU = 9876, Alias = "Account1", Balance = 2500.00m, Type = "Peso", ClientId = 1 }, 
                DestinationAccount = new AccountGetDto { Id = 2, UUID = "54321", AccountNumber = 202, CBU = 5678, Alias = "Account2", Balance = 4500.00m, Type = "Dollar", ClientId = 2 },
                CreatedDate = DateTime.Now 
            };
;

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.GetTransactionByIdAsync(1)).ReturnsAsync(transactions);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.GetTransaction(0);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiErrorResponse;
            var finalResult = value.Errors[0].Error;


            //Assert

            Assert.AreEqual("The transaction id is invalid!", finalResult);

        }

        [TestMethod]
        public async Task GetTransactionById_TransactionNotFound_ReturnError()
        {

            //Arrange

            TransactionGetDto transactions = null;

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.GetTransactionByIdAsync(1)).ReturnsAsync(transactions);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.GetTransaction(1);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiErrorResponse;
            var finalResult = value.Errors[0].Error;


            //Assert

            Assert.AreEqual("The transaction was not found!", finalResult);

        }

        [TestMethod]
        public async Task GetTransactionById_Valid_ReturnTransaction()
        {

            //Arrange

            TransactionGetDto transaction = new TransactionGetDto
            {
                Amount = 100.50m,
                Type = "Deposit",
                Concept = TransactionConcept.Deposit.ToString(),
                SourceAccount = new AccountGetDto { Id = 1, UUID = "12345", AccountNumber = 1, CBU = 9876, Alias = "Account1", Balance = 2500.00m, Type = "Peso", ClientId = 1 },
                DestinationAccount = new AccountGetDto { Id = 2, UUID = "54321", AccountNumber = 202, CBU = 5678, Alias = "Account2", Balance = 4500.00m, Type = "Dollar", ClientId = 2 },
                CreatedDate = DateTime.Now
            };

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.GetTransactionByIdAsync(1)).ReturnsAsync(transaction);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.GetTransaction(1);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiSuccessResponse;
            var finalResult = value.Data;


            //Assert

            Assert.AreEqual(transaction, finalResult);

        }

        [TestMethod]
        public async Task CreateTransaction_InvalidAmount_ReturnError()
        {

            //Arrange

            TransactionCreateDto transaction = new TransactionCreateDto
            {
                Amount = 0,
                Concept = TransactionConcept.Deposit,
                DestinationAccountId = 2,
                SourceAccountId = 1,
                ClientId = 1,
                Type = TransactionType.Deposit
            };

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.CreateTransactionAsync(transaction)).ReturnsAsync(true);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.CreateTransaction(transaction);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiErrorResponse;
            var finalResult = value.Errors[0].Error;


            //Assert

            Assert.AreEqual("Amount must be greater than 1", finalResult);

        }

        [TestMethod]
        public async Task CreateTransaction_InvalidType_ReturnError()
        {

            //Arrange

            TransactionCreateDto transaction = new TransactionCreateDto
            {
                Amount = 100m,
                Concept = TransactionConcept.Deposit,
                DestinationAccountId = 2,
                SourceAccountId = 1,
                ClientId = 1
            };

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.CreateTransactionAsync(transaction)).ReturnsAsync(true);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.CreateTransaction(transaction);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiErrorResponse;
            var finalResult = value.Errors[0].Error;


            //Assert

            Assert.AreEqual("The transaction type entered is invalid!", finalResult);

        }

        [TestMethod]
        public async Task CreateTransaction_SameAccountTransfer_ReturnError()
        {

            //Arrange

            TransactionCreateDto transaction = new TransactionCreateDto
            {
                Amount = 100m,
                Concept = TransactionConcept.Deposit,
                DestinationAccountId = 1,
                SourceAccountId = 1,
                ClientId = 1, 
                Type = TransactionType.Transfer
            };

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.CreateTransactionAsync(transaction)).ReturnsAsync(true);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.CreateTransaction(transaction);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiErrorResponse;
            var finalResult = value.Errors[0].Error;


            //Assert

            Assert.AreEqual("The transfer accounts cant be the same!", finalResult);

        }

        [TestMethod]
        public async Task CreateTransaction_DifferentAccountDeposit_ReturnError()
        {

            //Arrange

            TransactionCreateDto transaction = new TransactionCreateDto
            {
                Amount = 100m,
                Concept = TransactionConcept.Deposit,
                DestinationAccountId = 2,
                SourceAccountId = 1,
                ClientId = 1,
                Type = TransactionType.Deposit
            };

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.CreateTransactionAsync(transaction)).ReturnsAsync(true);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.CreateTransaction(transaction);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiErrorResponse;
            var finalResult = value.Errors[0].Error;


            //Assert

            Assert.AreEqual("The extraction and deposit accounts must be the same!", finalResult);

        }

        [TestMethod]
        public async Task CreateTransaction_InvalidGeneral_ReturnError()
        {

            //Arrange

            TransactionCreateDto transaction = new TransactionCreateDto
            {
                Amount = 100m,
                Concept = TransactionConcept.Deposit,
                DestinationAccountId = 2,
                SourceAccountId = 1,
                ClientId = 1,
                Type = TransactionType.Transfer
            };

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.CreateTransactionAsync(transaction)).ReturnsAsync(false);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.CreateTransaction(transaction);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiErrorResponse;
            var finalResult = value.Errors[0].Error;


            //Assert

            Assert.AreEqual("There is a problem with the transaction creation, check if the client and the accounts were valid!", finalResult);

        }

        [TestMethod]
        public async Task CreateTransaction_Valid_ReturnTransaction()
        {

            //Arrange

            TransactionCreateDto transaction = new TransactionCreateDto
            {
                Amount = 100m,
                Concept = TransactionConcept.Deposit,
                DestinationAccountId = 2,
                SourceAccountId = 1,
                ClientId = 1,
                Type = TransactionType.Transfer
            };

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.CreateTransactionAsync(transaction)).ReturnsAsync(true);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.CreateTransaction(transaction);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiSuccessResponse;
            var finalResult = value.Data as string;


            //Assert

            Assert.AreEqual("The Transaction was created!", finalResult);

        }

        [TestMethod]
        public async Task InsertTransaction_InvalidAmount_ReturnError()
        {

            //Arrange

            TransactionUpdateDto transaction = new TransactionUpdateDto
            {   
                Id = 1,
                Amount = 0,
                Concept = TransactionConcept.Deposit,
                DestinationAccountId = 2,
                SourceAccountId = 1,
                ClientId = 1,
                Type = TransactionType.Deposit
            };

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.UpdateTransaction(transaction)).ReturnsAsync(true);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.UpdateTransaction(1,transaction);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiErrorResponse;
            var finalResult = value.Errors[0].Error;


            //Assert

            Assert.AreEqual("Amount must be greater than 1", finalResult);

        }

        [TestMethod]
        public async Task UpdateTransaction_InvalidType_ReturnError()
        {

            //Arrange

            TransactionUpdateDto transaction = new TransactionUpdateDto
            {
                Id = 1,
                Amount = 1000,
                Concept = TransactionConcept.Deposit,
                DestinationAccountId = 2,
                SourceAccountId = 1,
                ClientId = 1
            };

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.UpdateTransaction(transaction)).ReturnsAsync(true);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.UpdateTransaction(1, transaction);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiErrorResponse;
            var finalResult = value.Errors[0].Error;


            //Assert

            Assert.AreEqual("The transaction type entered is invalid!", finalResult);

        }

        [TestMethod]
        public async Task UpdateTransaction_MatchingTransferAccountIds_ReturnError()
        {

            //Arrange

            TransactionUpdateDto transaction = new TransactionUpdateDto
            {
                Id = 1,
                Amount = 1000,
                Concept = TransactionConcept.Deposit,
                DestinationAccountId = 1,
                SourceAccountId = 1,
                ClientId = 1,
                Type = TransactionType.Transfer
            };

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.UpdateTransaction(transaction)).ReturnsAsync(true);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.UpdateTransaction(1, transaction);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiErrorResponse;
            var finalResult = value.Errors[0].Error;


            //Assert

            Assert.AreEqual("The transfer accounts cant be the same!", finalResult);

        }

        [TestMethod]
        public async Task UpdateTransaction_NotMatchingDepositAccounts_ReturnError()
        {

            //Arrange

            TransactionUpdateDto transaction = new TransactionUpdateDto
            {
                Id = 1,
                Amount = 1000,
                Concept = TransactionConcept.Deposit,
                DestinationAccountId = 1,
                SourceAccountId = 2,
                ClientId = 1,
                Type = TransactionType.Deposit
            };

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.UpdateTransaction(transaction)).ReturnsAsync(true);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.UpdateTransaction(1, transaction);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiErrorResponse;
            var finalResult = value.Errors[0].Error;


            //Assert

            Assert.AreEqual("The extraction and deposit accounts must be the same!", finalResult);

        }

        [TestMethod]
        public async Task UpdateTransaction_InvalidGeneral_ReturnError()
        {

            //Arrange

            TransactionUpdateDto transaction = new TransactionUpdateDto
            {
                Id = 1,
                Amount = 100m,
                Concept = TransactionConcept.Deposit,
                DestinationAccountId = 2,
                SourceAccountId = 1,
                ClientId = 1,
                Type = TransactionType.Transfer
            };

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.UpdateTransaction(transaction)).ReturnsAsync(false);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.UpdateTransaction(1,transaction);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiErrorResponse;
            var finalResult = value.Errors[0].Error;


            //Assert

            Assert.AreEqual("There is a problem with the transaction update, check if the client and the accounts were valid!", finalResult);

        }

        [TestMethod]
        public async Task UpdateTransaction_Valid_ReturnTransaction()
        {

            //Arrange

            TransactionUpdateDto transaction = new TransactionUpdateDto
            {
                Id = 1,
                Amount = 100m,
                Concept = TransactionConcept.Deposit,
                DestinationAccountId = 2,
                SourceAccountId = 1,
                ClientId = 1,
                Type = TransactionType.Transfer
            };

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.UpdateTransaction(transaction)).ReturnsAsync(true);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.UpdateTransaction(1,transaction);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiSuccessResponse;
            var finalResult = value.Data;


            //Assert

            Assert.AreEqual("Transaction was properly updated!", finalResult);

        }

        [TestMethod]
        public async Task DeleteTransaction_InvalidId_ReturnError()
        {

            //Arrange

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.DeleteTransactionAsync(1)).ReturnsAsync(false);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.DeleteTransaction(0);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiErrorResponse;
            var finalResult = value.Errors[0].Error;


            //Assert

            Assert.AreEqual("The transaction id is invalid!", finalResult);

        }

        [TestMethod]
        public async Task DeleteTransaction_TransactionNotFound_ReturnError()
        {

            //Arrange

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.DeleteTransactionAsync(1)).ReturnsAsync(false);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.DeleteTransaction(1);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiErrorResponse;
            var finalResult = value.Errors[0].Error;


            //Assert

            Assert.AreEqual("The transaction was not found!", finalResult);

        }

        [TestMethod]
        public async Task DeleteTransaction_Valid_ReturnError()
        {

            //Arrange

            var mockService = new Mock<ITransactionService>();
            var mockLogger = new Mock<ILogger<TransactionsController>>();
            mockService.Setup(service => service.DeleteTransactionAsync(1)).ReturnsAsync(true);
            var controller = new TransactionsController(mockService.Object, mockLogger.Object);


            //Act

            var result = await controller.DeleteTransaction(1);
            var objectResult = result as ObjectResult;
            var value = objectResult.Value as ApiSuccessResponse;
            var finalResult = value.Data as string;


            //Assert

            Assert.AreEqual("The Transaction was deleted!", finalResult);

        }
    }
}
