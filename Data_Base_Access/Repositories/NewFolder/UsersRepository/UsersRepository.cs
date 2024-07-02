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



       



       async Task<Users> IGenericRepository<Users>.UpdateAsync(Users entity)
        {
            context.Set<Users>().Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public void Save()
        {
            context.SaveChanges();
        }


         async Task IGenericRepository<Users>.AddAsync(Users item)
        {
            await context.Users.AddAsync(item);
            context.SaveChangesAsync();

                
        }

        async Task IGenericRepository<Users>.DeleteAsync(int id)
        {
            var aux = await context.Set<Users>().FindAsync(id);

                context.Set<Users>().Remove(aux);
                await context.SaveChangesAsync();
            
        }
    }
}
