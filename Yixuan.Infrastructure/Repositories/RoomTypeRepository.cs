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
    public class RoomTypeRepository : EfRepository<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(HotelManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<RoomType>> GetAllAvailableRoomTypes()
        {
            var allRoomTypes = await hotelManagementDbContext.Rooms.Include(r => r.RoomType)
                .Select(r => new RoomType
                {
                    Id = r.RoomType.Id,
                    Rent = r.RoomType.Rent,
                    RTDesc = r.RoomType.RTDesc
                }
                ).ToListAsync();
            var occupiedRoomTypes = await hotelManagementDbContext.Customers.Include(c => c.Room)
                .ThenInclude(r => r.RoomType)
                .Select(c => new RoomType
                {
                    Id = c.Room.RoomType.Id,
                    Rent = c.Room.RoomType.Rent,
                    RTDesc = c.Room.RoomType.RTDesc
                })
                .Distinct().ToListAsync();
            var availableRoomTypes = allRoomTypes.Except(occupiedRoomTypes).ToList();

            return availableRoomTypes;
        }
    }
}