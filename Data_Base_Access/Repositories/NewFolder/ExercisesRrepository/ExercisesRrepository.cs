using Data_Base_Access.Entities;
using Data_Base_Access.Repositories.NewFolder.IGenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data_Base_Access.Repositories.NewFolder.ExercisesRepository
{
    public class ExercisesRrepository : IGenericRepository<Exercises>
    {
        private WorkoutContext context;
        public ExercisesRrepository(WorkoutContext context)
        {
            this.context = context;
        }



        async Task IGenericRepository<Exercises>.AddAsync(Exercises item)
        {
            await context.Exercises.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var aux = await context.Set<Exercises>().FindAsync(id);

            context.Set<Exercises>().Remove(aux);
            await context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Exercises>> GetAll()
        {
            return await context.Exercises.ToListAsync();
        }

        public async Task<Exercises> GetByID(int id)
        {
            return await context.Exercises.FindAsync(id);
        }

       

        async Task<Exercises> IGenericRepository<Exercises>.UpdateAsync(Exercises entity)
        {
            context.Set<Exercises>().Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public Task<List<Exercises>> GetAllWithInclude(params Expression<Func<Exercises, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Users GetID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
