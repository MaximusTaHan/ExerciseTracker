#nullable disable
using Microsoft.AspNetCore.Mvc;
using ExerciseTracker.Models;
using ExerciseTracker.Repositories;

namespace ExerciseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        //private readonly WorkoutContext _context;
        private readonly IWorkoutRepository _workoutRepository;
        public WorkoutsController(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        // GET: api/Workouts
        [HttpGet]
        public async Task<IEnumerable<Workouts>> GetWorkouts()
        {
            return await _workoutRepository.Get();
        }

        // GET: api/Workouts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workouts>> GetWorkouts(int id)
        {
            var workout = await _workoutRepository.GetById(id);

            if (workout == null)
            {
                return NotFound();
            }

            return workout;
        }

        // PUT: api/Workouts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkouts(int id, [FromBody]Workouts workout)
        {
            workout.WorkoutsId = id;
            var updateWorkout = await _workoutRepository.GetById(id);

            if (updateWorkout == null)
            {
                return BadRequest();
            }

            updateWorkout = workout;

            await _workoutRepository.Update(updateWorkout);
            return NoContent();
        }

        // POST: api/Workouts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Workouts>> PostWorkouts(Workouts workouts)
        {
            var newWorkout = await _workoutRepository.Post(workouts);

            return CreatedAtAction(nameof(GetWorkouts), new { id = newWorkout.WorkoutsId }, newWorkout);
        }

        // DELETE: api/Workouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkouts(int id)
        {
            var workouts = await _workoutRepository.GetById(id);
            if (workouts == null)
            {
                return NotFound();
            }


            await _workoutRepository.Delete(workouts.WorkoutsId);

            return NoContent();
        }
    }
}
