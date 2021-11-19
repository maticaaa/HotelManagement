using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IAsyncRepository<T> where T : class 
    {
        Task<T> GetById(int id);
        Task<ICollection<T>> GetAll();
        Task<ICollection<T>> Get(Expression<Func<T, bool>> expression);
        Task<int> GetCount(Expression<Func<T, bool>> expression);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T eneity);
    }
}
