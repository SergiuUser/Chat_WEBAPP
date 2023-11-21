using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Chat_WEBAPP.Context;
using Chat_WEBAPP.Models;

namespace Chat_WEBAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionTypesController : ControllerBase
    {
        private readonly ChatContext _context;

        public ReactionTypesController(ChatContext context)
        {
            _context = context;
        }

        // GET: api/ReactionTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReactionType>>> GetreactionTypes()
        {
            return await _context.reactionTypes.ToListAsync();
        }

        // GET: api/ReactionTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReactionType>> GetReactionType(int id)
        {
            var reactionType = await _context.reactionTypes.FindAsync(id);

            if (reactionType == null)
            {
                return NotFound();
            }

            return reactionType;
        }

        // PUT: api/ReactionTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReactionType(int id, ReactionType reactionType)
        {
            if (id != reactionType.ReactionTypeID)
            {
                return BadRequest();
            }

            _context.Entry(reactionType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReactionTypeExists(id))
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

        // POST: api/ReactionTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReactionType>> PostReactionType(ReactionType reactionType)
        {
            _context.reactionTypes.Add(reactionType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReactionType", new { id = reactionType.ReactionTypeID }, reactionType);
        }

        // DELETE: api/ReactionTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReactionType(int id)
        {
            var reactionType = await _context.reactionTypes.FindAsync(id);
            if (reactionType == null)
            {
                return NotFound();
            }

            _context.reactionTypes.Remove(reactionType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReactionTypeExists(int id)
        {
            return _context.reactionTypes.Any(e => e.ReactionTypeID == id);
        }
    }
}
