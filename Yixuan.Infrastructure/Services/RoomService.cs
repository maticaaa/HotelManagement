using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yixuan.ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class RoomService : IRoomService
    {
        protected readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        // TODO: Status column should show if a room is available or not.
        // If a room is already occupied, then it should not be booked again if it is occupied.

        public async Task<RoomResponseModel> AddNewRoom(RoomCreateModel createModel)
        {
            var room = new Room
            {
                RTCode = createModel.RTCode,
                //Status = true
            };
            var newRoom = await _roomRepository.Add(room);
            var roomResponseModel = new RoomResponseModel
            {
                Id = newRoom.Id,
                RTCode = newRoom.RTCode.GetValueOrDefault(),
                Status = true //await _roomRepository.GetRoomStatus(room.Id)
            };
            return roomResponseModel;
        }

        public async Task<RoomResponseModel> DeleteRoom(int id)
        {
            var room = await _roomRepository.GetById(id);
            if (room == null) return null;
            var deletedRoom = await _roomRepository.Delete(room);
            var roomResponseModel = new RoomResponseModel
            {
                Id = deletedRoom.Id,
                RTCode = deletedRoom.RTCode.GetValueOrDefault(),
                Status = await _roomRepository.GetRoomStatus(room.Id)
            };
            return roomResponseModel;
        }

        public async Task<RoomDetailsModel> GetRoomDetails(int id)
        {
            var room = await _roomRepository.GetRoomDetails(id);
            if (room == null) return null;
            var roomDetailsModel = new RoomDetailsModel
            {
                Id = room.Id,
                RTCode = room.RTCode.GetValueOrDefault(),
                Status = await _roomRepository.GetRoomStatus(room.Id)
            };
            foreach (var service in room.Services)
            {
                roomDetailsModel.Services.Add(new ServiceResponseModel
                {
                    Id = service.Id,
                    RoomNo = service.RoomNo.GetValueOrDefault(),
                    Amount = service.Amount.GetValueOrDefault(),
                    SDesc = service.SDesc,
                    ServiceDate = service.ServiceDate.GetValueOrDefault()
                });
            }
            return roomDetailsModel;
        }

        public async Task<bool> GetRoomStatus(int id)
        {
            var status = await _roomRepository.GetRoomStatus(id);
            return status;
        }

        public async Task<IEnumerable<RoomResponseModel>> ListAllAvailableRooms()
        {
            var availableRooms = await _roomRepository.Get(r => r.Status.GetValueOrDefault(false));
            var roomModels = new List<RoomResponseModel>();
            foreach (var room in availableRooms)
            {
                roomModels.Add(new RoomResponseModel
                {
                    Id = room.Id,
                    RTCode = room.RTCode.GetValueOrDefault(),
                    Status = await _roomRepository.GetRoomStatus(room.Id)
                });
            }
            return roomModels;
        }

        public async Task<IEnumerable<RoomResponseModel>> ListAllRooms()
        {
            var rooms = await _roomRepository.GetAll();
            var roomResponseModels = new List<RoomResponseModel>();
            foreach (var room in rooms)
            {
                roomResponseModels.Add(new RoomResponseModel
                {
                    Id = room.Id,
                    RTCode = room.RTCode.GetValueOrDefault(),
                    Status = await _roomRepository.GetRoomStatus(room.Id)
                });
            }
            return roomResponseModels;
        }

        public async Task<RoomResponseModel> UpdateRoom(RoomRequestModel requestModel)
        {
            var room = new Room
            {
                Id = requestModel.Id,
                RTCode = requestModel.RTCode
                //Status = false
            };
            var updatedRoom = await _roomRepository.Update(room);
            var roomResponseModel = new RoomResponseModel
            {
                Id = updatedRoom.Id,
                RTCode = updatedRoom.RTCode.GetValueOrDefault(),
                //Status = false
                Status = await _roomRepository.GetRoomStatus(room.Id)
            };
            return roomResponseModel;
        }
    }
}
