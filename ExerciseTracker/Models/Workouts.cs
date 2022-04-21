namespace ExerciseTracker.Models
{
    public class Workouts
    {
        public int WorkoutsId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public long Duration { get; set; }
        public string Comments { get; set; }
    }
}
