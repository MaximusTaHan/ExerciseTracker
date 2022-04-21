using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.Models
{
    public class WorkoutContext : DbContext
    {
        public WorkoutContext(DbContextOptions<WorkoutContext> options) : base (options)
        {
        }
        public DbSet<Workouts> Workouts { get; set; }
    }
}
