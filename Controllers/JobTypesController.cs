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
    public class JobTypesController : ControllerBase
    {
        private readonly ApiContext _context;

        public JobTypesController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/JobTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobType>>> GetjobTypes()
        {
            return await _context.jobTypes.ToListAsync();
        }

        // GET: api/JobTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobType>> GetJobType(int id)
        {
            var jobType = await _context.jobTypes.FindAsync(id);

            if (jobType == null)
            {
                return NotFound();
            }

            return jobType;
        }

        // PUT: api/JobTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobType(int id, JobType jobType)
        {
            if (id != jobType.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTypeExists(id))
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

        // POST: api/JobTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobType>> PostJobType(JobType jobType)
        {
            _context.jobTypes.Add(jobType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobType", new { id = jobType.Id }, jobType);
        }

        // DELETE: api/JobTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobType(int id)
        {
            var jobType = await _context.jobTypes.FindAsync(id);
            if (jobType == null)
            {
                return NotFound();
            }

            _context.jobTypes.Remove(jobType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobTypeExists(int id)
        {
            return _context.jobTypes.Any(e => e.Id == id);
        }
    }
}
