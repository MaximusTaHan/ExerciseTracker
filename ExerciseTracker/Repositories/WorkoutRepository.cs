using ExerciseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly WorkoutContext _context;
        public WorkoutRepository(WorkoutContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Workouts>> Get()
        {
            return await _context.Workouts.ToListAsync();
        }

        public async Task<Workouts> GetById(int id)
        {
            return await _context.Workouts.FindAsync(id);
        }

        public async Task<Workouts> Post(Workouts workouts)
        {
            _context.Workouts.Add(workouts);
            await _context.SaveChangesAsync();

            return workouts;
        }

        public async Task Delete(int id)
        {
            var deleteWorkout = await _context.Workouts.FindAsync(id);
            _context.Workouts.Remove(deleteWorkout);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Workouts workouts)
        {
            var updateWorkout = await _context.Workouts.FindAsync(workouts.WorkoutsId);

            _context.Entry(updateWorkout).CurrentValues.SetValues(workouts);
            await _context.SaveChangesAsync();
        }
    }
}
