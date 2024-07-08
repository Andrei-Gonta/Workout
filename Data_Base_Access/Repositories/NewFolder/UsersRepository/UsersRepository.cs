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
using System.Linq.Expressions;


namespace Data_Base_Access.Repositories.UsersRepository
{
    public class UserRepository : IGenericRepository<Users>
    {

        private WorkoutContext context;
        public UserRepository(WorkoutContext context)
        {
            this.context = context;
        }
       
        public async Task<IEnumerable<Users>> GetAll()
        {
            return await context.Users.ToListAsync();
        }


        public async Task<Users> GetByIDAsync(int id)
        {
            return await context.Users.FindAsync(id);
        }

     

        /*async Task<Users> IGenericRepository<Users>.UpdateAsync(Users entity)
        {
            context.Set<Users>().Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
        */
  
         async Task IGenericRepository<Users>.AddAsync(Users item)
        {
            await context.Users.AddAsync(item);
            await context.SaveChangesAsync();

        }

        async Task IGenericRepository<Users>.DeleteAsync(int id)
        {
            var aux = await context.Set<Users>().FindAsync(id);

                context.Set<Users>().Remove(aux);
                await context.SaveChangesAsync();
            
        }


        public virtual async Task<Users> UpdateAsync(Users item)
        {
            context.Set<Users>().Entry(item).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return item;
            
        }

        public Task<List<Users>> GetAllWithInclude(params Expression<Func<Users, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Users>> GetWorkoutsByUserId(int userId)
        {
            throw new NotImplementedException();
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
