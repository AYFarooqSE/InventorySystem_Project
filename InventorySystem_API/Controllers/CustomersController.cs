using AutoMapper;
using InventorySystem_API.DTOs;
using InventorySystem_Application.AppInterfaces;
using InventorySystem_Domain.Models;
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
        private IMapper _mapper;
        public CustomersController(ICustomers repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<CustomerDto> modelCustomer = new List<CustomerDto>();
            var model=await _repo.GetAll();

            var modeltoReturn=_mapper.Map<List<CustomerDto>>(model);

            #region MappingUsingLoop
            /*foreach (var item in model)
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
            */
            #endregion
            return Ok(modeltoReturn);
        }

        [HttpGet("{ID}")]
        public async Task<IActionResult> GetByID(int ID)
        {
            var model=await _repo.GetByID(ID);
            var ModelReturn= _mapper.Map<CustomerDto>(model);

            return Ok(ModelReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNew(CustomerDto model)
        {
            if(model!=null)
            {
                var modeltocreate = _mapper.Map<CustomersModel>(model);
                var SaveStatus = await _repo.SaveNewCustomer(modeltocreate);
                if(SaveStatus>0)
                {
                    return Ok(modeltocreate);
                }
            }
            return Ok();
        }
    }
}
