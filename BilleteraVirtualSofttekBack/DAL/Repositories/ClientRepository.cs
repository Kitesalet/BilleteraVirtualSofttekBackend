using BilleteraVirtualSofttekBack.Helpers;
using BilleteraVirtualSofttekBack.Models.DTOs.Client;
using BilleteraVirtualSofttekBack.Models.Entities;
using IntegradorSofttekImanol.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace BilleteraVirtualSofttekBack.DAL.Repositories
{
    /// <summary>
    /// The implemmentation that defines extra repository operations related to the User entity.
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
                                                             && e.Email.ToString() == dto.Email
                                                             && e.Password == EncrypterHelper.Encrypter(dto.Password, _configuration["EncryptKey"])); ;

        }

        /// <inheritdoc/>
        public async Task<bool> ClientExists(ClientAuthenticateDto dto)
        {


            return await _context.Clients.AnyAsync(e => e.Email.ToString() == dto.Email.ToString());

        }

    }
}
