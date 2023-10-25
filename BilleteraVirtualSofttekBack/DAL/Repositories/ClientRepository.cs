using BilleteraVirtualSofttekBack.Helpers;
using BilleteraVirtualSofttekBack.Models.DTOs.Client;
using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Interfaces.RepoInterfaces;
using IntegradorSofttekImanol.DAL.Context;
using IntegradorSofttekImanol.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BilleteraVirtualSofttekBack.DAL.Repositories
{

    /// <summary>
    /// The interface implementation to access to client data.
    /// </summary>
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes an instance of UsuarioRepository using dependency injection with its parameters.
        /// </summary>
        /// <param name="context">An AppDbContext with DI.</param>
        public ClientRepository(AppDbContext context, IConfiguration configuration) : base(context)
        {

            _context = context;
            _configuration = configuration;

        }

        /// <inheritdoc/>
        public async Task<Client?> AuthenticateCredentials(ClientAuthenticateDto dto)
        {

            return await _context.Clients
                                      .SingleOrDefaultAsync(e => e.DeletedDate == null
                                                             && e.Email == dto.Email
                                                             && e.Password == EncrypterHelper.Encrypter(dto.Password, _configuration["EncryptKey"])); ;

        }

        /// <inheritdoc/>
        public async Task<bool> ClientExists(ClientCreateDto dto)
        {

            var flag = await _context.Clients.AnyAsync(c => c.Email == dto.Email || c.DeletedDate != null);

            return flag;
        }

        /// <inheritdoc/>
        public async Task<bool> VerifyExistingEmail(string email)
        {
            var flag = await _context.Clients.AnyAsync(e => e.Email == email);

            return flag;
        }
    }
}
