using InventorySystem_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem_Application.AppInterfaces
{
    public interface ICustomers
    {
        Task<List<CustomersModel>> GetAll();
        Task<CustomersModel> GetByID(int CustomerID);

    }
}
