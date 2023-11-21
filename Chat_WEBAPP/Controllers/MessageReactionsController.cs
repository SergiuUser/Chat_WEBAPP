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
    public class MessageReactionsController : ControllerBase
    {
        private readonly ChatContext _context;

        public MessageReactionsController(ChatContext context)
        {
            _context = context;
        }

        // GET: api/MessageReactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageReactions>>> GetMessageReactions()
        {
            return await _context.MessageReactions.ToListAsync();
        }

        // GET: api/MessageReactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageReactions>> GetMessageReactions(int id)
        {
            var messageReactions = await _context.MessageReactions.FindAsync(id);

            if (messageReactions == null)
            {
                return NotFound();
            }

            return messageReactions;
        }

        // PUT: api/MessageReactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessageReactions(int id, MessageReactions messageReactions)
        {
            if (id != messageReactions.MessageReactionID)
            {
                return BadRequest();
            }

            _context.Entry(messageReactions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageReactionsExists(id))
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

        // POST: api/MessageReactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MessageReactions>> PostMessageReactions(MessageReactions messageReactions)
        {
            _context.MessageReactions.Add(messageReactions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessageReactions", new { id = messageReactions.MessageReactionID }, messageReactions);
        }

        // DELETE: api/MessageReactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessageReactions(int id)
        {
            var messageReactions = await _context.MessageReactions.FindAsync(id);
            if (messageReactions == null)
            {
                return NotFound();
            }

            _context.MessageReactions.Remove(messageReactions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageReactionsExists(int id)
        {
            return _context.MessageReactions.Any(e => e.MessageReactionID == id);
        }
    }
}
