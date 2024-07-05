using Microsoft.EntityFrameworkCore;
using Data_Base_Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Base_Access.Repositories.UserRepository;
using Data_Base_Access.Repositories.NewFolder.IGenericRepository;
using Data_Base_Access;
using System.Collections;
using System.Linq.Expressions;

namespace Data_Base_Access.Repositories.WorkoutRepository
{
    public class WorkoutRepository : IGenericRepository<Workout>
    {
        private WorkoutContext context;

        public WorkoutRepository(WorkoutContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Workout item)
        {
            await context.Workouts.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Workout>> GetAll()
        {
            throw new NotImplementedException();
        }

        /*public async Task<IEnumerable<Workout>> GetInfo(int user_id)
        {
            return await context.Workouts
            .Where(w => w.CientID == user_id)
            .ToListAsync();

        }
        */


        public async Task<List<Workout>> GetAllWithInclude(params Expression<Func<Workout, object>>[] includeProperties)
        {

            IQueryable<Workout> query = context.Set<Workout>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();

        }

        public Task<Workout> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Users GetID(int id)
        {
            return context.Set<Users>().Find(id);
        }

        public Task<IEnumerable<Workout>> GetInfo(int user_id)
        {
            throw new NotImplementedException();
        }

        public Task<Workout> UpdateAsync(Workout item)
        {
            throw new NotImplementedException();
        }

       

    }
}
