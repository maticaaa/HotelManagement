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
    public class ServicesController : ControllerBase
    {
        protected readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        [HttpGet]
        public async Task<IActionResult> ListAllServices()
        {
            var services = await _serviceService.ListAllServices();
            if (!services.Any())
            {
                return NotFound("No Service Found");
            }
            return Ok(services);
        }

        [HttpPost]
        public async Task<IActionResult> AddService([FromBody] ServiceCreateModel requestModel)
        {
            var newService = await _serviceService.AddNewService(requestModel);
            if (newService == null)
            {
                return BadRequest("Adding Service Failed");
            }
            return Ok(newService);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService([FromBody] ServiceRequestModel requestModel)
        {
            var updatedService = await _serviceService.UpdateService(requestModel);
            if (updatedService == null)
            {
                return BadRequest("Updating Service Failed");
            }
            return Ok(updatedService);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var deletedService = await _serviceService.DeleteService(id);
            if (deletedService == null)
            {
                return BadRequest("Deleting Service Failed");
            }
            return Ok(deletedService);
        }
    }
}
