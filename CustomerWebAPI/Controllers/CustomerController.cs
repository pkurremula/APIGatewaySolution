using CustomerWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CustomerController : Controller
    {

        private readonly CustomerDBContext _customerdBContext;
        public CustomerController(CustomerDBContext customerdBContext)
        {
            _customerdBContext = customerdBContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers() {

            return _customerdBContext.Cusotmers;
        }

        [HttpGet("{customerId:int}")]
        public async Task<ActionResult<Customer>> getCustomerById(int customerId)
        {
            var customer = await _customerdBContext.Cusotmers.FindAsync(customerId);

            if(customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Customer customer)
        {
            await _customerdBContext.Cusotmers.AddAsync(customer);
            await _customerdBContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Customer customer)
        {
            _customerdBContext.Cusotmers.Update(customer);
            await _customerdBContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{customerId:int}")]
        public async Task<ActionResult> Delete(int customerId)
        {
            var customer = await _customerdBContext.Cusotmers.FindAsync(customerId);
            if(customer == null)
            {
                return NotFound();
            }
            _customerdBContext.Cusotmers.Remove(customer);
            await _customerdBContext.SaveChangesAsync();
            return Ok();
        }


    }
}
