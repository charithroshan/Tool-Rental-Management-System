using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToolRentalManagement.DataAccess;
using ToolRentalManagement.Models;
using ToolRentalManagement.Services.Dtos.CustomerAndOrderDto;

namespace ToolRentalManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DataContext _context = new DataContext();

        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer(CustomerDto request)
        { 
            int i = request.orders.Count;
            Order[] orders = request.orders.ToArray();
            
            var customer = _context.Customers.FirstOrDefault(c => c.NIC == request.NIC);

            if (customer == null)
            { 
                Customer customerNew = new Customer();
                //customer.Id = request.Id;
                customerNew.FullName = request.FullName;
                customerNew.NIC = request.NIC;
                customerNew.Contact = request.Contact;
                customerNew.Address = request.Address;

                _context.Customers.Add(customerNew);
                await _context.SaveChangesAsync();

                for (int j = 0; j < i; j++)
                {
                    orders[j].CustomerId = customerNew.Id;
                    _context.Orders.Add(orders[j]);
                }
            }
            else
            {
                for (int j = 0; j < i; j++)
                {
                    orders[j].CustomerId = customer.Id;
                    _context.Orders.Add(orders[j]);
                }
            }

            
            await _context.SaveChangesAsync();
            return Ok(request);
        }
    }
}
