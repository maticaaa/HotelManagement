using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yixuan.ApplicationCore.Models;

namespace ApplicationCore.ServiceInterface
{
    public interface IRoomTypeService
    {
        Task<RoomTypeModel> AddNewRoomType(RoomTypeCreateModel createModel);
        Task<RoomTypeModel> UpdateRoomType(RoomTypeModel requestModel);
        Task<RoomTypeModel> DeleteRoomType(int id);
        Task<IEnumerable<RoomTypeModel>> ListAllRoomTypes();
        Task<IEnumerable<RoomTypeModel>> ListAllAvailableRoomTypes();

    }
}
