using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeBelieveIT.Task.Tracker.Models;

namespace WeBelieveIT.Task.Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressesController : ControllerBase
    {
        private readonly ApiContext _context;

        public ProgressesController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Progresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Progress>>> GetProgress()
        {
            return await _context.Progress.ToListAsync();
        }

        // GET: api/Progresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Progress>> GetProgress(int id)
        {
            var progress = await _context.Progress.FindAsync(id);

            if (progress == null)
            {
                return NotFound();
            }

            return progress;
        }

        // PUT: api/Progresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgress(int id, Progress progress)
        {
            if (id != progress.Id)
            {
                return BadRequest();
            }

            _context.Entry(progress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgressExists(id))
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

        // POST: api/Progresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Progress>> PostProgress(Progress progress)
        {
            _context.Progress.Add(progress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgress", new { id = progress.Id }, progress);
        }

        // DELETE: api/Progresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgress(int id)
        {
            var progress = await _context.Progress.FindAsync(id);
            if (progress == null)
            {
                return NotFound();
            }

            _context.Progress.Remove(progress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgressExists(int id)
        {
            return _context.Progress.Any(e => e.Id == id);
        }
    }
}
