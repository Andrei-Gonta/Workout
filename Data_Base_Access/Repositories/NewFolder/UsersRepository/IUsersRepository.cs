﻿using Data_Base_Access.Entities;
using Data_Base_Access.Repositories.NewFolder.IGenericRepository;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Base_Access.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<Users>
    {
        public Task<List<Users>> GetAllAsync();
        Task<Users> GetByIdAsync(int id);
        Task AddAsync(Users user);
        Task UpdateAsync(Users user);
        Task DeleteByIdAsync(int id);



    }
}
