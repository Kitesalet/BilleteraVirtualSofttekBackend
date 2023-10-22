using BilleteraVirtualSofttekBack.Controllers;
using BilleteraVirtualSofttekBack.Models.DTOs.Client;
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
        private readonly ILogger<ClientsController> _logger;

        public ClientControllerTest(ILogger<ClientsController> logger)
        {

            _logger = logger;

        }

        public ClientControllerTest() 
        { 

        }


        [TestMethod]
        public async Task Get_GetAllClients()
        {

            //Arrange

            var clients = new List<ClientGetDto>
            {
                new ClientGetDto { Name = "Client 1", Email = "client1@example.com", Password = "password1", Id = 1 },
                new ClientGetDto { Name = "Client 2", Email = "client2@example.com", Password = "password2", Id = 2 },
                new ClientGetDto { Name = "Client 3", Email = "client3@example.com", Password = "password3", Id = 3 },
                new ClientGetDto { Name = "Client 4", Email = "client4@example.com", Password = "password4", Id = 4 }
            };

            var mockRepository = new Mock<IClientService>();
            var mockLogger = new Mock<ILogger<ClientsController>>();
            mockRepository.Setup(service => service.GetAllClientsAsync(1, 4)).ReturnsAsync(clients);
            var controller = new ClientsController(mockRepository.Object, mockLogger.Object);

            //Act

            var result = await controller.GetAllClients(1, 4);
            var objectResult = result as ObjectResult;
            var apiResponse = objectResult.Value as ApiSuccessResponse;
            var list = apiResponse.Data as List<ClientGetDto>;

            //Assert

            Assert.AreEqual(clients, list);

        }
    }
}