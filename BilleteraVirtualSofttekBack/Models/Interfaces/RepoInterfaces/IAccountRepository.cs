using BilleteraVirtualSofttekBack.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BilleteraVirtualSofttekBack.Models.Interfaces.RepoInterfaces
{
    public interface IAccountRepository
    {

        public Task<IEnumerable<BaseAccount>> GetAllAccountsByClient(int clientId);

    }
}
