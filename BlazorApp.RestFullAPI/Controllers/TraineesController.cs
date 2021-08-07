using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Models;
using BlazorApp.Models.Data;

namespace BlazorApp.RestFullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineesController : ControllerBase
    {
        private readonly BlazorAppContext _context;

        public TraineesController(BlazorAppContext context)
        {
            _context = context;
        }

        // GET: api/Trainees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trainee>>> GetTrainees()
        {
            return await _context.Trainees.Include(t=> t.Track).AsNoTracking().ToListAsync();
        }

        // GET: api/Trainees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trainee>> GetTrainee(int id)
        {
            //var trainee = await _context.Trainees.FindAsync(id);
            var trainee = await _context.Trainees.Include(t=> t.Track).AsNoTracking()
                .FirstOrDefaultAsync(t=> t.ID == id);

            if (trainee == null)
            {
                return NotFound();
            }

            return trainee;
        }

        // PUT: api/Trainees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainee(int id, Trainee trainee)
        {
            if (id != trainee.ID)
            {
                return BadRequest();
            }

            _context.Entry(trainee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraineeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Trainees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trainee>> PostTrainee(Trainee trainee)
        {
            Trainee entity = new Trainee();
            entity.Name = trainee.Name;
            entity.MobileNo = trainee.MobileNo;
            entity.IsGraduated = trainee.IsGraduated;
            entity.TrackId = trainee.Track.ID;
            //entity.Track = trainee.Track;
            entity.email = trainee.email;
            entity.Birthdate = trainee.Birthdate;

            _context.Trainees.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainee", new { id = trainee.ID }, trainee);
        }

        // DELETE: api/Trainees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainee(int id)
        {
            var trainee = await _context.Trainees.FindAsync(id);
            if (trainee == null)
            {
                return NotFound();
            }

            _context.Trainees.Remove(trainee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraineeExists(int id)
        {
            return _context.Trainees.Any(e => e.ID == id);
        }
    }
}
