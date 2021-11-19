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
    public class RoomTypeService : IRoomTypeService
    {
        protected readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeService(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<RoomTypeModel> AddNewRoomType(RoomTypeCreateModel createModel)
        {
            var roomtype = new RoomType
            {
                Rent = createModel.Rent,
                RTDesc = createModel.RTDesc
            };
            var newRoomType = await _roomTypeRepository.Add(roomtype);
            var roomtypeModel = new RoomTypeModel
            {
                Id = newRoomType.Id,
                RTDesc = newRoomType.RTDesc,
                Rent = newRoomType.Rent.GetValueOrDefault()
            };
            return roomtypeModel;
        }

        public async Task<RoomTypeModel> DeleteRoomType(int id)
        {
            var roomtype = await _roomTypeRepository.GetById(id);
            if (roomtype == null) return null;
            var deletedRoomType = await _roomTypeRepository.Delete(roomtype);
            var roomtypeModel = new RoomTypeModel
            {
                Id = deletedRoomType.Id,
                RTDesc = deletedRoomType.RTDesc,
                Rent = deletedRoomType.Rent.GetValueOrDefault()
            };
            return roomtypeModel;
        }

        public async Task<IEnumerable<RoomTypeModel>> ListAllAvailableRoomTypes()
        {
            var availableRoomTypes = await _roomTypeRepository.GetAllAvailableRoomTypes();
            var roomTypeModels = new List<RoomTypeModel>();
            foreach (var roomType in availableRoomTypes)
            {
                roomTypeModels.Add(new RoomTypeModel
                {
                    Id = roomType.Id,
                    RTDesc = roomType.RTDesc,
                    Rent = roomType.Rent.GetValueOrDefault()
                });
            }
            return roomTypeModels;
        }

        public async Task<IEnumerable<RoomTypeModel>> ListAllRoomTypes()
        {
            var roomTypes = await _roomTypeRepository.GetAll();
            var roomTypeModels = new List<RoomTypeModel>();
            foreach (var roomType in roomTypes)
            {
                roomTypeModels.Add(new RoomTypeModel
                {
                    Id = roomType.Id,
                    RTDesc = roomType.RTDesc,
                    Rent = roomType.Rent.GetValueOrDefault()
                });
            }
            return roomTypeModels;
        }

        public async Task<RoomTypeModel> UpdateRoomType(RoomTypeModel requestModel)
        {
            var roomtype = new RoomType
            {
                Id = requestModel.Id,
                Rent = requestModel.Rent,
                RTDesc = requestModel.RTDesc
            };
            var updatedRoomType = await _roomTypeRepository.Update(roomtype);
            var roomtypeModel = new RoomTypeModel
            {
                Id = updatedRoomType.Id,
                RTDesc = updatedRoomType.RTDesc,
                Rent = updatedRoomType.Rent.GetValueOrDefault()
            };
            return roomtypeModel;
        }
    }
}
