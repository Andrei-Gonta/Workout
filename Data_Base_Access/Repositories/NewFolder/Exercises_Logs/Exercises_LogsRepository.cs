using Data_Base_Access.Entities;
using Data_Base_Access.Repositories.NewFolder.IGenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data_Base_Access.Repositories.NewFolder.Exercises_Logs
{
    public class Exercises_LogsRepository : IGenericRepository<ExercisesLog>
    {
        private WorkoutContext context;
        public Exercises_LogsRepository(WorkoutContext context)
        {
            this.context = context;
        }



        async Task IGenericRepository<ExercisesLog>.AddAsync(ExercisesLog item)
        {
            await context.ExercisesLogs.AddAsync(item);
            await context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int w_id, int e_id)
        {
            var aux = await context.Set<ExercisesLog>().FindAsync(w_id, e_id);
            if (aux != null)
            {
                context.ExercisesLogs.Remove(aux);
                await context.SaveChangesAsync();
            }
        }

        public async void Delete(int w_id, int e_id)
        {
            var aux = await context.Set<ExercisesLog>().FindAsync(w_id, e_id);
            if (aux != null)
            {
                context.ExercisesLogs.Remove(aux);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ExercisesLog>> GetAll()
        {
            return await context.ExercisesLogs.ToListAsync();

        }

        public Task<List<ExercisesLog>> GetAllWithInclude(params Expression<Func<ExercisesLog, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<ExercisesLog> GetByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExercisesLog>> GetWorkoutsByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ExercisesLog> UpdateAsync(ExercisesLog item)
        {
            context.Set<ExercisesLog>().Entry(item).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return item;
        }


        public async Task<IEnumerable<ExercisesLog>> GetExerciseLogsByWorkoutId(int workoutId)
        {
            return await context.ExercisesLogs
                .Where(el => el.Id_Workout == workoutId)
                .Include(el => el.Exercise)
                .ToListAsync();
        }

        public async Task<ExercisesLog> GetExerciseLogByWorkoutAndExerciseId(int workoutId, int exerciseId)
        {
             return await context.ExercisesLogs.Include(e=>e.Workout).FirstOrDefaultAsync(el => el.Id_Workout == workoutId && el.Id_Exercice == exerciseId);
           // return await context.ExercisesLogs
           // .Where(el => el.Id_Workout == workoutId && el.Id_Exercice==exerciseId)
            //    .Include(el => el.Exercise)
            //    .ToListAsync();
        }

        public async Task<IEnumerable<ExercisesLog>> GetExerciseLogByWorkoutAndExerciseId2(int workoutId, int exerciseId)
        {
            return await context.ExercisesLogs
             .Where(el => el.Id_Workout == workoutId && el.Id_Exercice==exerciseId)
               .Include(el => el.Exercise)
               .ToListAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
