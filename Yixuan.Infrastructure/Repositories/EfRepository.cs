using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly HotelManagementDbContext hotelManagementDbContext;
        public EfRepository(HotelManagementDbContext dbContext)
        {
            hotelManagementDbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            await hotelManagementDbContext.Set<T>().AddAsync(entity);
            await hotelManagementDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(T eneity)
        {
            hotelManagementDbContext.Set<T>().Remove(eneity);
            await hotelManagementDbContext.SaveChangesAsync();
            return eneity;
        }

        public async Task<ICollection<T>> Get(Expression<Func<T, bool>> expression)
        {
            return await hotelManagementDbContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await hotelManagementDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await hotelManagementDbContext.Set<T>().FindAsync(id);
        }

        public async Task<int> GetCount(Expression<Func<T, bool>> expression)
        {
            return await hotelManagementDbContext.Set<T>().Where(expression).CountAsync();
        }

        public async Task<T> Update(T entity)
        {
            hotelManagementDbContext.Entry(entity).State = EntityState.Modified;
            await hotelManagementDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
