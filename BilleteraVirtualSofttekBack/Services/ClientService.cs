using AutoMapper;
using BilleteraVirtualSofttekBack.Helpers;
using BilleteraVirtualSofttekBack.Models.DTOs.Client;
using BilleteraVirtualSofttekBack.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces;
using IntegradorSofttekImanol.Models.Interfaces.ServiceInterfaces;

namespace IntegradorSofttekImanol.Services
{
    /// <summary>
    /// The implementation of the service for defining and using ClientDtos and its logic.
    /// </summary>
    public class ClientService : IClientService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes an instance of ClientService using dependency injection with its parameters.
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork with DI.</param>
        /// <param name="mapper">IMapper with DI.</param>
        public ClientService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;

        }

        /// <inheritdoc/>
        public async Task<bool> CreateClientAsync(ClientCreateDto clientDto)
        {
            try
            {
                var client = _mapper.Map<Client>(clientDto);

                if(await _unitOfWork.ClientRepository.ClientExists(clientDto) == true)
                {
                    return false;
                }

                if(await _unitOfWork.ClientRepository.VerifyExistingEmail(clientDto.Email))
                {
                    return false;
                }

                client.Password = EncrypterHelper.Encrypter(client.Password, _configuration["EncryptKey"] );

                await _unitOfWork.ClientRepository.AddAsync(client);

                client.CreatedDate = DateTime.Now;
                

                await _unitOfWork.Complete();

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + " - Error");
            }

            return false;

        }

        /// <inheritdoc/>
        public async Task<bool> DeleteClientAsync(int id)
        {

            var flag = await _unitOfWork.ClientRepository.Delete(id);

            await _unitOfWork.Complete();

            return flag;

        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ClientGetDto>> GetAllClientsAsync(int page, int units)
        {

            var clients = await _unitOfWork.ClientRepository.GetAllAsync(page, units); 
            
            var clientsDto = _mapper.Map<List<ClientGetDto>>(clients);
            
            return clientsDto;
                   
        }

        /// <inheritdoc/>
        public async Task<ClientGetDto> GetClientByIdAsync(int id)
        {
            
            var client = await _unitOfWork.ClientRepository.GetByIdAsync(id);

            if (client == null || client.DeletedDate != null)
            {
                return null;
            }

            return _mapper.Map<ClientGetDto>(client);
            
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateClient(ClientUpdateDto clientDto)
        {
            var client = await _unitOfWork.ClientRepository.GetByIdAsync(clientDto.Id);

            try
            {

                client.Name = clientDto.Name;
                client.Password = EncrypterHelper.Encrypter(clientDto.Password, _configuration["EncryptKey"]);
                client.ModifiedDate = DateTime.Now;

                _unitOfWork.ClientRepository.Update(client);

                await _unitOfWork.Complete();

                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
