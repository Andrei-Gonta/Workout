using Data_Base_Access.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data_Base_Access.Repositories.NewFolder.IGenericRepository
{
    public interface IGenericRepository <T>
    {

        Task<IEnumerable<T>> GetAll();
        Task<T> GetByIDAsync(int id);
       // public Users GetID(int id);

        Task AddAsync(T item);

        Task<T> UpdateAsync(T item);

        Task DeleteAsync(int id);

       Task<List<T>> GetAllWithInclude(params Expression<Func<T, object>>[] includeProperties);

        Task<IEnumerable<T>> GetWorkoutsByUserId(int userId);

        Task<IEnumerable<ExercisesLog>> GetExerciseLogsByWorkoutId(int workoutId);
        Task<ExercisesLog> GetExerciseLogByWorkoutAndExerciseId(int workoutId, int exerciseId);
        Task<IEnumerable<ExercisesLog>> GetExerciseLogByWorkoutAndExerciseId2(int workoutId, int exerciseId);
         Task DeleteAsync(int w_id, int e_id);



    }
}
