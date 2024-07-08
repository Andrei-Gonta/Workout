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
            await context.Set<Workout>().AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var aux = await context.Set<Workout>().FindAsync(id);

            context.Set<Workout>().Remove(aux);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Workout>> GetAll()
        {
            return await context.Workouts.Include(u => u.User).Include(el => el.ExercisesLog).ThenInclude(e => e.Exercise).ToListAsync();
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

        public async Task<Workout> GetByIDAsync(int id)
        {
            return await context.Workouts.FindAsync(id);
        }

      

        public Task<Workout> UpdateAsync(Workout item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Workout>>GetWorkoutsByUserId(int userId)
        {
            return await context.Workouts
                           .Where(w => w.CientID == userId)
                           .Include(w => w.ExercisesLog)
                               .ThenInclude(el => el.Exercise)
                           .ToListAsync();
        }

        public Task<IEnumerable<ExercisesLog>> GetExerciseLogsByWorkoutId(int workoutId)
        {
            throw new NotImplementedException();
        }

        public Task<ExercisesLog> GetExerciseLogByWorkoutAndExerciseId(int workoutId, int exerciseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExercisesLog>> GetExerciseLogByWorkoutAndExerciseId2(int workoutId, int exerciseId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int w_id, int e_id)
        {
            throw new NotImplementedException();
        }
    }
}
