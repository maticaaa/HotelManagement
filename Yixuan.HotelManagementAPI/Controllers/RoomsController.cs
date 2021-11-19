using ApplicationCore.Entities;
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
    public class RoomsController : ControllerBase
    {
        public readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAllRooms()
        {
            var rooms = await _roomService.ListAllRooms();
            if (!rooms.Any())
            {
                return NotFound("No Room Found");
            }
            return Ok(rooms);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetRoomDetails(int id)
        {
            var room = await _roomService.GetRoomDetails(id);
            if(room == null)
            {
                return NotFound("No Room Found");
            }
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom([FromBody] RoomCreateModel requestModel)
        {
            var newRoom = await _roomService.AddNewRoom(requestModel);
            if (newRoom == null)
            {
                return BadRequest("Adding Room Failed");
            }
            return Ok(newRoom);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoom([FromBody] RoomRequestModel requestModel)
        {
            var status = await _roomService.GetRoomStatus(requestModel.Id);
            if (!status)
            {
                return BadRequest("The Room is Occupied");
            }
            var updatedRoom = await _roomService.UpdateRoom(requestModel);
            if (updatedRoom == null)
            {
                return BadRequest("Updating Room Failed");
            }
            return Ok(updatedRoom);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var status = await _roomService.GetRoomStatus(id);
            if (!status)
            {
                return BadRequest("The Room is Occupied");
            }
            var deletedRoom = await _roomService.DeleteRoom(id);
            if (deletedRoom == null)
            {
                return BadRequest("Deleting Room Failed");
            }
            return Ok(deletedRoom);
        }
    }
}
