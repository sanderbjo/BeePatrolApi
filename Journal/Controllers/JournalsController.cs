using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Journal.Models;

namespace Journal.Controllers
{
    [Route("journal/api/v1/[controller]")]
    [ApiController]
    public class JournalsController : ControllerBase
    {
        private readonly JournalContext _context;

        public JournalsController(JournalContext context)
        {
            _context = context;
        }

        // GET: api/Journals?
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Journal.Models.Journal>>> GetJournals(int userid, DateTime date)
        {
            var filteredJournals = await _context.Journals.Where(journal => journal.UserId == userid && journal.Date.Date == date.Date).ToListAsync();

            if (filteredJournals.Count == 0)
            {
                return NotFound(); // Return 404 if no journals found
            }

            return Ok(filteredJournals);
        }

        // GET: api/Journals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Journal.Models.Journal>> GetJournal(int id)
        {
            var journal = await _context.Journals.FindAsync(id);

            if (journal == null)
            {
                return NotFound();
            }

            return journal;
        }

        // PUT: api/Journals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJournal(int id, Journal.Models.Journal journal)
        {
            if (id != journal.JournalId)
            {
                return BadRequest();
            }

            _context.Entry(journal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JournalExists(id))
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

        // POST: api/Journals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Journal.Models.Journal>> PostJournal(Journal.Models.Journal journal)
        {
            _context.Journals.Add(journal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJournal", new { id = journal.JournalId }, journal);
        }

        // DELETE: api/Journals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJournal(int id)
        {
            var journal = await _context.Journals.FindAsync(id);
            if (journal == null)
            {
                return NotFound();
            }

            _context.Journals.Remove(journal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JournalExists(int id)
        {
            return _context.Journals.Any(e => e.JournalId == id);
        }
    }
}
