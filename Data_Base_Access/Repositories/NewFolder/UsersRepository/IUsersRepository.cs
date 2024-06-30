using Data_Base_Access.Entities;
using Microsoft.EntityFrameworkCore.Migrations;
using Data_Base_Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Base_Access.Repositories.UserRepository
{
    public interface IUserRepository : IDisposable
    {
        public Task<List<Users>> GetAllAsync();
        Task<Users> GetByIdAsync(int id);
        Task AddAsync(Users user);
        Task UpdateAsync(Users user);
        Task DeleteByIdAsync(int id);



    }
}
