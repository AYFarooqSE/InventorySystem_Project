using InventorySystem_API.DTOs;
using InventorySystem_Application.AppInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventorySystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomers _repo;
        public CustomersController(ICustomers repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<CustomerDto> modelCustomer = new List<CustomerDto>();
            var model=await _repo.GetAll();

            foreach (var item in model)
            {
                modelCustomer.Add(new CustomerDto()
                {
                    CustomerID = item.CustomerID,
                    AddressLine1 = item.AddressLine1,
                    AddressLine2 = item.AddressLine2,
                    City = item.City,
                    CNIC = item.CNIC,
                    CustomerPendings=item.CustomerPendings,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    ImageUrl=""
                });
            }

            return Ok(modelCustomer);
        }
    }
}
