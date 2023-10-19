using BilleteraVirtualSofttekBack.Models.DTOs.Client;
using BilleteraVirtualSofttekBack.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilleteraVirtualSofttekBack.Models.Interfaces.RepoInterfaces
{
    /// <summary>
    /// This interface defines extra repository operations related to the Transaction entity.
    /// </summary>
    public interface ITransactionRepository : IRepository<Transaction>
    {
        


    }
}