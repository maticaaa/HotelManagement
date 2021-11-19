using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yixuan.ApplicationCore.Models;

namespace ApplicationCore.ServiceInterface
{
    public interface IRoomService
    {
        Task<RoomDetailsModel> GetRoomDetails(int id);
        Task<RoomResponseModel> AddNewRoom(RoomCreateModel createModel);
        Task<RoomResponseModel> UpdateRoom(RoomRequestModel requestModel);
        Task<RoomResponseModel> DeleteRoom(int id);
        Task<IEnumerable<RoomResponseModel>> ListAllRooms();
        Task<IEnumerable<RoomResponseModel>> ListAllAvailableRooms();
        Task<bool> GetRoomStatus(int id);
    }
}
