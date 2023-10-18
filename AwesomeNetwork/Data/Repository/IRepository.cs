using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeNetwork.Data.Repository
{
    public interface IRepository<T> where T : class
    {
       Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task  CreateAsync(T item);
        Task Update(T item);
        Task DeleteAsync(T item);
    }
}
