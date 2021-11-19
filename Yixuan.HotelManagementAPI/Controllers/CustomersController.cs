using ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yixuan.ApplicationCore.Models;

namespace Yixuan.HotelManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        protected readonly ICustomerService _customerService;
        protected readonly IRoomService _roomService;

        public CustomersController(ICustomerService customerService, IRoomService roomService)
        {
            _customerService = customerService;
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAllCustomers()
        {
            var customers = await _customerService.ListAllCustomers();
            if (!customers.Any())
            {
                return NotFound("No Customer Found");
            }
            return Ok(customers);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCustomerDetails(int id)
        {
            var customer = await _customerService.GetCustomerDetails(id);
            if(customer == null)
            {
                return NotFound($"Customer {id} Not Found");
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerCreateModel createModel)
        {
            var room = await _roomService.GetRoomDetails(createModel.RoomNo);
            if (!room.Status)
            {
                return BadRequest("The Room is Occupied");
            }
            var newCustomer = await _customerService.AddNewCustomer(createModel);
            if (newCustomer == null)
            {
                return BadRequest("Adding Customer Failed");
            }
            return Ok(newCustomer);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerRequestModel requestModel)
        {
            var updatedCustomer = await _customerService.UpdateCustomer(requestModel);
            if (updatedCustomer == null)
            {
                return BadRequest("Updating Customer Failed");
            }
            return Ok(updatedCustomer);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var deletedCustomer = await _customerService.DeleteCustomer(id);
            if (deletedCustomer == null)
            {
                return BadRequest("Deleting Customer Failed");
            }
            return Ok(deletedCustomer);
        }
    }
}
