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
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(HotelManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Customer> GetCustomerDetails(int id)
        {
            var customer = await hotelManagementDbContext.Customers.Include(c => c.Room).ThenInclude(r => r.RoomType).Include(c => c.Room).ThenInclude(r => r.Services)
                .Where(c => c.Id == id).Select(c => new Customer
                {
                    Id = c.Id,
                    RoomNo = c.RoomNo,
                    CName = c.CName,
                    Address = c.Address,
                    Phone = c.Phone,
                    Email = c.Email,
                    CheckIn = c.CheckIn,
                    TotalPersons = c.TotalPersons,
                    BookingDays = c.BookingDays,
                    Advance = c.Room.RoomType.Rent * c.BookingDays + c.Room.Services.Sum(s => s.Amount),
                    Room = c.Room
                }).FirstOrDefaultAsync();
            return customer;
        }
    }
}
