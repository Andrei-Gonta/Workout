using Microsoft.EntityFrameworkCore;
using Data_Base_Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Base_Access.Repositories.UserRepository;
using Data_Base_Access;
using Data_Base_Access.Repositories.NewFolder.IGenericRepository;
using System.Collections;

namespace Data_Base_Access.Repositories.UsersRepository
{
    public class UserRepository : IGenericRepository<Users>, IDisposable
    {

        private WorkoutContext context;
        public UserRepository(WorkoutContext context)
        {
            this.context = context;
        }

        public  async Task Add(Users entity)
        {
            await context.Users.AddAsync(entity);
        }


        public async void Delete(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user != null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
        }


        public void Dispose()
        {
            return;
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            return await context.Users.ToListAsync();
        }


        public async Task<Users> GetByID(int id)
        {
            return await context.Users.FindAsync(id);
        }

        

        public async void Update(Users user)
        {
            context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        Task<Users> IGenericRepository<Users>.Add(Users entity)
        {
            throw new NotImplementedException();
        }

        Task<Users> IGenericRepository<Users>.Update(Users entity)
        {
            throw new NotImplementedException();
        }
    }
}
