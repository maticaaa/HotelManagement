using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RoomRepository : EfRepository<Room>, IRoomRepository
    {
        public RoomRepository(HotelManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Room> GetRoomDetails(int id)
        {
            var room = await hotelManagementDbContext.Rooms.Where(r => r.Id == id).Include(r => r.RoomType).Include(r => r.Services).FirstOrDefaultAsync();
            return room;
        }

        public async Task<bool> GetRoomStatus(int id)
        {
            var status = await hotelManagementDbContext.Customers.Include(c => c.Room).Where(c => c.RoomNo == id).FirstOrDefaultAsync();
            return status == null;
        }
    }
}
