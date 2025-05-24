using InventorySystem_Application.AppInterfaces;
using InventorySystem_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem_InfraStructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem_InfraStructure.Repositories
{
    public class CustomersRepository : ICustomers
    {
        private ApplicationDbContext _context;
        public CustomersRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CustomersModel>> GetAll()
        {
            List<CustomersModel> liCus = new List<CustomersModel>();
            liCus = await _context.Tbl_Customers.ToListAsync();

            return liCus;
        }

        public async Task<CustomersModel> GetByID(int CustomerID)
        {
            var model = await _context.Tbl_Customers.Where(x => x.CustomerID == CustomerID).FirstOrDefaultAsync();
            if(model==null)
            {
                //
            }
            
            return model;
        }

        public async Task<int> SaveNewCustomer(CustomersModel model)
        {
            int RetStatus = 0;
            if(model!=null)
            {
                await _context.Tbl_Customers.AddAsync(model);
                RetStatus = await _context.SaveChangesAsync();
            }
            return RetStatus;
        }
    }
}
