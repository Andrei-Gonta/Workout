using Data_Base_Access.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Base_Access.Repositories.NewFolder.IGenericRepository
{
    public interface IGenericRepository <T>
    {

        Task<IEnumerable<T>> GetAll();
        
        Task<T> GetByID(int id);

        Task AddAsync(T item);

        Task<T> UpdateAsync(T item);

        Task DeleteAsync(int id);

        public void Save();



    }
}
