using ExerciseTracker.Models;

namespace ExerciseTracker.Repositories
{
    public interface IWorkoutRepository
    {
        Task<IEnumerable<Workouts>> Get();
        Task<Workouts> GetById(int id);
        Task<Workouts> Post(Workouts workout);
        Task Update (Workouts workout);
        Task Delete (int id);
    }
}
