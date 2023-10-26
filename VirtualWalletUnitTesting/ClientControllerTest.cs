using BilleteraVirtualSofttekBack.Controllers;
using BilleteraVirtualSofttekBack.Models.DTOs.Account;
using BilleteraVirtualSofttekBack.Models.DTOs.Client;
using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Enums;
using IntegradorSofttekImanol.Infrastructure;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace VirtualWalletUnitTesting
{
    [TestClass]
    public class ClientControllerTest
    {

        [TestMethod]
        public async Task GetAllClients_Valid_ReturnsTotal()
        {

            //Arrange

            var clients = new List<ClientGetDto>
            {
                new ClientGetDto { Name = "Client 1", Email = "client1@example.com", Id = 1 },
                new ClientGetDto { Name = "Client 2", Email = "client2@example.com", Id = 2 },
                new ClientGetDto { Name = "Client 3", Email = "client3@example.com",  Id = 3 },
                new ClientGetDto { Name = "Client 4", Email = "client4@example.com",  Id = 4 }
            };

            var mockService = new Mock<IClientService>();
            var mockLogger = new Mock<ILogger<ClientsController>>();
            mockService.Setup(service => service.GetAllClientsAsync(1, 4)).ReturnsAsync(clients);
            var controller = new ClientsController(mockService.Object, mockLogger.Object);

            //Act

            var result = await controller.GetAllClients(1, 4);
            var objectResult = result as ObjectResult;
            var apiResponse = objectResult.Value as ApiSuccessResponse;
            var list = apiResponse.Data as List<ClientGetDto>;

            //Assert

            CollectionAssert.AreEqual(clients, list);

        }

        [TestMethod]
        public async Task GetAllClients_InvalidPagination_ReturnsText()
        {

            //Arrange

            var clients = new List<ClientGetDto>
            {
                new ClientGetDto { Name = "Client 1", Email = "client1@example.com",  Id = 1 },
                new ClientGetDto { Name = "Client 2", Email = "client2@example.com",  Id = 2 },
                new ClientGetDto { Name = "Client 3", Email = "client3@example.com",  Id = 3 },
                new ClientGetDto { Name = "Client 4", Email = "client4@example.com",  Id = 4 }
            };

            var mockService = new Mock<IClientService>();
            var mockLogger = new Mock<ILogger<ClientsController>>();
            mockService.Setup(service => service.GetAllClientsAsync(0, 0)).ReturnsAsync(clients);
            var controller = new ClientsController(mockService.Object, mockLogger.Object);

            //Act

            var result = await controller.GetAllClients(0, 0);
            var objectResult = result as ObjectResult;
            var apiResponse = objectResult.Value as ApiErrorResponse;
            var text = apiResponse.Errors[0].Error as string;

            //Assert

            Assert.AreEqual("There was an error in the pagination!", text );

        }

        [TestMethod]
        public async Task GetClient_InvalidId_ReturnsText()
        {

            //Arrange

            var client = new ClientGetDto()
            {
                Name = "Client 1",
                Email = "client1@example.com",
               
                Id = 1
            };

            var mockService = new Mock<IClientService>();
            var mockLogger = new Mock<ILogger<ClientsController>>();
            mockService.Setup(service => service.GetClientByIdAsync(0)).ReturnsAsync(client);
            var controller = new ClientsController(mockService.Object, mockLogger.Object);

            //Act

            var result = await controller.GetClient(0);
            var objectResult = result as ObjectResult;
            var apiResponse = objectResult.Value as ApiErrorResponse;
            var text = apiResponse.Errors[0].Error as string;

            //Assert

            Assert.AreEqual("The client id is invalid!", text);

        }

        [TestMethod]
        public async Task GetClient_NotFound_ReturnsText()
        {

            //Arrange

            ClientGetDto client = null;

            var mockService = new Mock<IClientService>();
            var mockLogger = new Mock<ILogger<ClientsController>>();
            mockService.Setup(service => service.GetClientByIdAsync(2)).ReturnsAsync(client);
            var controller = new ClientsController(mockService.Object, mockLogger.Object);

            //Act

            var result = await controller.GetClient(2);
            var objectResult = result as ObjectResult;
            var apiResponse = objectResult.Value as ApiErrorResponse;
            var text = apiResponse.Errors[0].Error as string;

            //Assert

            Assert.AreEqual("The client was not found!", text);

        }

        [TestMethod]
        public async Task GetClient_Valid_ReturnsClient()
        {

            //Arrange

            var client = new ClientGetDto()
            {
                Name = "Client 1",
                Email = "client1@example.com",
               
                Id = 1
            };

            var mockService = new Mock<IClientService>();
            var mockLogger = new Mock<ILogger<ClientsController>>();
            mockService.Setup(service => service.GetClientByIdAsync(1)).ReturnsAsync(client);
            var controller = new ClientsController(mockService.Object, mockLogger.Object);

            //Act

            var result = await controller.GetClient(1);
            var objectResult = result as ObjectResult;
            var apiResponse = objectResult.Value as ApiSuccessResponse;
            var clientResult = apiResponse.Data as ClientGetDto;

            //Assert

            Assert.AreEqual(client, clientResult);

        }

        [TestMethod]
        public async Task CreateClient_InvalidEmail_ReturnsError()
        {

            //Arrange

            var client = new ClientCreateDto()
            {
                Name = "Client 1",
                Email = "",
                Password = "password1",
                Role = ClientRole.Base
            };

            var mockService = new Mock<IClientService>();
            var mockLogger = new Mock<ILogger<ClientsController>>();
            mockService.Setup(service => service.CreateClientAsync(client)).ReturnsAsync(false);
            var controller = new ClientsController(mockService.Object, mockLogger.Object);

            //Act

            var result = await controller.CreateClient(client);
            var objectResult = result as ObjectResult;
            var apiResponse = objectResult.Value as ApiErrorResponse;
            var errorResult = apiResponse.Errors[0].Error as string;

            //Assert

            Assert.AreEqual("The email entered is invalid!", errorResult);

        }

        [TestMethod]
        public async Task CreateClient_InvalidName_ReturnsError()
        {

            //Arrange

            var client = new ClientCreateDto()
            {
                Name = "",
                Email = "client@example.com",
                Password = "password1",
                Role = ClientRole.Base
            };

            var mockService = new Mock<IClientService>();
            var mockLogger = new Mock<ILogger<ClientsController>>();
            mockService.Setup(service => service.CreateClientAsync(client)).ReturnsAsync(false);
            var controller = new ClientsController(mockService.Object, mockLogger.Object);

            //Act

            var result = await controller.CreateClient(client);
            var objectResult = result as ObjectResult;
            var apiResponse = objectResult.Value as ApiErrorResponse;
            var errorResult = apiResponse.Errors[0].Error as string;

            //Assert

            Assert.AreEqual("The name entered is invalid!", errorResult);

        }

        [TestMethod]
        public async Task CreateClient_InvalidPassword_ReturnsError()
        {

            //Arrange

            var client = new ClientCreateDto()
            {
                Name = "Client 1",
                Email = "client@example.com",
                Password = "",
                Role = ClientRole.Base
            };

            var mockService = new Mock<IClientService>();
            var mockLogger = new Mock<ILogger<ClientsController>>();
            mockService.Setup(service => service.CreateClientAsync(client)).ReturnsAsync(false);
            var controller = new ClientsController(mockService.Object, mockLogger.Object);

            //Act

            var result = await controller.CreateClient(client);
            var objectResult = result as ObjectResult;
            var apiResponse = objectResult.Value as ApiErrorResponse;
            var errorResult = apiResponse.Errors[0].Error as string;

            //Assert

            Assert.AreEqual("The entered password is invalid!", errorResult);

        }

        public async Task CreateClient_InvalidRole_ReturnsError()
        {

            //Arrange

            var client = new ClientCreateDto()
            {
                Name = "Client 1",
                Email = "client@example.com",
                Password = "password1",
                Role = (ClientRole)99
            };

            var mockService = new Mock<IClientService>();
            var mockLogger = new Mock<ILogger<ClientsController>>();
            mockService.Setup(service => service.CreateClientAsync(client)).ReturnsAsync(false);
            var controller = new ClientsController(mockService.Object, mockLogger.Object);

            //Act

            var result = await controller.CreateClient(client);
            var objectResult = result as ObjectResult;
            var apiResponse = objectResult.Value as ApiErrorResponse;
            var errorResult = apiResponse.Errors[0].Error as string;

            //Assert

            Assert.AreEqual("The client role entered is invalid!", errorResult);

        }

        [TestMethod]
        public async Task CreateClient_EmailExisted_ReturnsError()
        {

            //Arrange

            var client = new ClientCreateDto()
            {
                Name = "Client 1",
                Email = "client@example.com",
                Password = "password1",
                Role = ClientRole.Base
            };

            var mockService = new Mock<IClientService>();
            var mockLogger = new Mock<ILogger<ClientsController>>();
            mockService.Setup(service => service.CreateClientAsync(client)).ReturnsAsync(false);
            var controller = new ClientsController(mockService.Object, mockLogger.Object);

            //Act

            var result = await controller.CreateClient(client);
            var objectResult = result as ObjectResult;
            var apiResponse = objectResult.Value as ApiErrorResponse;
            var errorResult = apiResponse.Errors[0].Error as string;

            //Assert

            Assert.AreEqual("There was a problem, the client wasnt created! Email is in use.", errorResult);

        }

        [TestMethod]
        public async Task CreateClient_Valid_ReturnsAccount()
        {

            //Arrange

            var client = new ClientCreateDto()
            {
                Name = "Client 1",
                Email = "client@example.com",
                Password = "password1",
                Role = ClientRole.Admin
            };

            var mockService = new Mock<IClientService>();
            var mockLogger = new Mock<ILogger<ClientsController>>();
            mockService.Setup(service => service.CreateClientAsync(client)).ReturnsAsync(true);
            var controller = new ClientsController(mockService.Object, mockLogger.Object);

            //Act

            var result = await controller.CreateClient(client);
            var objectResult = result as ObjectResult;
            var apiResponse = objectResult.Value as ApiSuccessResponse;
            var clientResult = apiResponse.Data as string;

            //Assert

            Assert.AreEqual("The client was created!", clientResult);

        }

        [TestMethod]
        public async Task UpdateClient_InvalidRole_ReturnsError()
        {

            //Arrange

            var client = new ClientUpdateDto()
            {
                Name = "",
                Password = "password1",
                Id = 1
            };

            var mockService = new Mock<IClientService>();
            var mockLogger = new Mock<ILogger<ClientsController>>();
            mockService.Setup(service => service.UpdateClient(client)).ReturnsAsync(false);
            var controller = new ClientsController(mockService.Object, mockLogger.Object);

            //Act

            var result = await controller.UpdateClient(client.Id, client);
            var objectResult = result as ObjectResult;
            var apiResponse = objectResult.Value as ApiErrorResponse;
            var errorResult = apiResponse.Errors[0].Error as string;

            //Assert

            Assert.AreEqual("The client role entered is invalid!", errorResult);

        }

        [TestMethod]
        public async Task UpdateClient_InvalidName_ReturnsError()
        {

            //Arrange

            var client = new ClientUpdateDto()
            {
                Name = "",
                Password = "password1",
                Id = 1,
                Role = ClientRole.Admin
            };

            var mockService = new Mock<IClientService>();
            var mockLogger = new Mock<ILogger<ClientsController>>();
            mockService.Setup(service => service.UpdateClient(client)).ReturnsAsync(false);
            var controller = new ClientsController(mockService.Object, mockLogger.Object);

            //Act

            var result = await controller.UpdateClient(client.Id, client);
            var objectResult = result as ObjectResult;
            var apiResponse = objectResult.Value as ApiErrorResponse;
            var errorResult = apiResponse.Errors[0].Error as string;

            //Assert

            Assert.AreEqual("The entered name is invalid!", errorResult);

        }

        [TestMethod]
        public async Task UpdateClient_InvalidPassword_ReturnsError()
        {

            //Arrange

            var client = new ClientUpdateDto()
            {
                Name = "Client 1",
                Password = "",
                Id = 1,
                Role = ClientRole.Admin
            };

            var mockService = new Mock<IClientService>();
            var mockLogger = new Mock<ILogger<ClientsController>>();
            mockService.Setup(service => service.UpdateClient(client)).ReturnsAsync(false);
            var controller = new ClientsController(mockService.Object, mockLogger.Object);

            //Act

            var result = await controller.UpdateClient(client.Id, client);
            var objectResult = result as ObjectResult;
            var apiResponse = objectResult.Value as ApiErrorResponse;
            var errorResult = apiResponse.Errors[0].Error as string;

            //Assert

            Assert.AreEqual("The entered password is invalid!", errorResult);

        }

        [TestMethod]
        public async Task UpdateClient_EmailExisted_ReturnsError()
        {

            //Arrange

            var client = new ClientUpdateDto()
            {
                Name = "Client 1",
                Password = "password1",
                Id = 1,
                Role = ClientRole.Admin
            };

            var mockService = new Mock<IClientService>();
            var mockLogger = new Mock<ILogger<ClientsController>>();
            mockService.Setup(service => service.UpdateClient(client)).ReturnsAsync(false);
            var controller = new ClientsController(mockService.Object, mockLogger.Object);

            //Act

            var result = await controller.UpdateClient(client.Id, client);
            var objectResult = result as ObjectResult;
            var apiResponse = objectResult.Value as ApiErrorResponse;
            var errorResult = apiResponse.Errors[0].Error as string;

            //Assert

            Assert.AreEqual("There was a problem, the client wasnt updated!", errorResult);

        }

        [TestMethod]
        public async Task UpdateClient_Valid_ReturnsAccount()
        {

            //Arrange

            var client = new ClientUpdateDto()
            {
                Name = "Client 1",
                Password = "password1",
                Id = 1,
                Role = ClientRole.Admin
            };

            var mockService = new Mock<IClientService>();
            var mockLogger = new Mock<ILogger<ClientsController>>();
            mockService.Setup(service => service.UpdateClient(client)).ReturnsAsync(true);
            var controller = new ClientsController(mockService.Object, mockLogger.Object);

            //Act

            var result = await controller.UpdateClient(client.Id, client);
            var objectResult = result as ObjectResult;
            var apiResponse = objectResult.Value as ApiSuccessResponse;
            var clientResult = apiResponse.Data as string;

            //Assert

            Assert.AreEqual("Client was properly updated!", clientResult);

        }

        [TestMethod]
        public async Task DeleteClient_Valid_ReturnsAccount()
        {

            //Arrange

            var mockService = new Mock<IClientService>();
            var mockLogger = new Mock<ILogger<ClientsController>>();
            mockService.Setup(service => service.DeleteClientAsync(1)).ReturnsAsync(true);
            var controller = new ClientsController(mockService.Object, mockLogger.Object);

            //Act

            var result = await controller.DeleteClient(1);
            var objectResult = result as ObjectResult;
            var apiResponse = objectResult.Value as ApiSuccessResponse;
            var clientResult = apiResponse.Data as string;

            //Assert

            Assert.AreEqual("The client was deleted!", clientResult);

        }

        [TestMethod]
        public async Task DeleteClient_InvalidId_ReturnsError()
        {

            //Arrange

            var mockService = new Mock<IClientService>();
            var mockLogger = new Mock<ILogger<ClientsController>>();
            mockService.Setup(service => service.DeleteClientAsync(0)).ReturnsAsync(false);
            var controller = new ClientsController(mockService.Object, mockLogger.Object);

            //Act

            var result = await controller.DeleteClient(0);
            var objectResult = result as ObjectResult;
            var apiResponse = objectResult.Value as ApiErrorResponse;
            var clientResult = apiResponse.Errors[0].Error as string;

            //Assert

            Assert.AreEqual("The client id is invalid!", clientResult);

        }
    }
}