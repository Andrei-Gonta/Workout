using Microsoft.EntityFrameworkCore;
using Data_Base_Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Base_Access.Repositories.UserRepository;
using Data_Base_Access;

namespace Data_Base_Access.Repositories.UsersRepository
{
    public class UserRepository : IUserRepository, IDisposable
    {

        private WorkoutContext context;
        public UserRepository(WorkoutContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Users user)
        {
            await context.Users.AddAsync(user);
        }


        public async Task DeleteByIdAsync(int id)
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
            throw new NotImplementedException();
        }

        public async Task<List<Users>> GetAllAsync()
        {
            return await context.Users.ToListAsync();
        }
        public async Task<Users> GetByIdAsync(int id)
        {
            return await context.Users.FindAsync(id);

        }

        public void update(Users user)
        {
            context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public async Task UpdateAsync(Users user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }
    }
}
