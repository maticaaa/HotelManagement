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
    public class RoomTypesController : ControllerBase
    {
        protected readonly IRoomTypeService _roomTypeService;

        public RoomTypesController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAllRoomtypes()
        {
            var roomTypes = await _roomTypeService.ListAllRoomTypes();
            if (!roomTypes.Any())
            {
                return NotFound("No RoomType Found");
            }
            return Ok(roomTypes);
        }

        [HttpGet]
        [Route("Available")]
        public async Task<IActionResult> ListAllAvailableRoomType()
        {
            var availableRoomTypes = await _roomTypeService.ListAllAvailableRoomTypes();
            if (!availableRoomTypes.Any())
            {
                return NotFound("No Available RoomType");
            }
            return Ok(availableRoomTypes);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoomtype([FromBody] RoomTypeCreateModel requestModel)
        {
            var newRoomType = await _roomTypeService.AddNewRoomType(requestModel);
            if (newRoomType == null)
            {
                return BadRequest("Adding RoomType Failed");
            }
            return Ok(newRoomType);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoomtype([FromBody] RoomTypeModel requestModel)
        {
            var updatedRoomType = await _roomTypeService.UpdateRoomType(requestModel);
            if (updatedRoomType == null)
            {
                return BadRequest("Updating RoomType Failed");
            }
            return Ok(updatedRoomType);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteRoomtype(int id)
        {
            var deletedRoomType = await _roomTypeService.DeleteRoomType(id);
            if (deletedRoomType == null)
            {
                return BadRequest("Deleting Room Failed");
            }
            return Ok(deletedRoomType);
        }
    }
}
