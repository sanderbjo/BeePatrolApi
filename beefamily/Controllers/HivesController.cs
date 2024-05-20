using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using beefamily.Models;

namespace beefamily.Controllers
{
    [Route("beefamily/api/v1/[controller]")]
    [ApiController]
    public class HivesController : ControllerBase
    {
        private readonly HiveContext _context;

        public HivesController(HiveContext context)
        {
            _context = context;
        }

        // GET: api/Hives?userid
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hive>>> GetHivesByUser(string userid)
        {
            var usersHives = await _context.Hives.Where(hives => hives.UserId == userid).ToListAsync();

            if (usersHives.Count == 0)
            {
                return NotFound(); // Return 404 if no journals found
            }

            return Ok(usersHives);
        }

        // GET: api/Hives/{hiveId}
        [HttpGet("{id}")]
        public async Task<ActionResult<Hive>> GetHive(string id)
        {
            var hive = await _context.Hives.FindAsync(id);

            if (hive == null)
            {
                return NotFound();
            }

            return hive;
        }

        // PUT: api/Hives/{hiveId}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHive(string id, Hive hive)
        {
            if (id != hive.HiveId)
            {
                return BadRequest();
            }

            _context.Entry(hive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HiveExists(id))
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

        // POST: api/Hives
        [HttpPost]
        public async Task<ActionResult<Hive>> PostHive(Hive hive)
        {
            _context.Hives.Add(hive);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HiveExists(hive.HiveId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction(nameof(GetHive), new { id = hive.HiveId }, hive);

        }


        // DELETE: api/Hives/{hiveId}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHive(string id)
        {
            var hive = await _context.Hives.FindAsync(id);
            if (hive == null)
            {
                return NotFound();
            }

            _context.Hives.Remove(hive);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HiveExists(string id)
        {
            return _context.Hives.Any(e => e.HiveId == id);
        }
    }
}
