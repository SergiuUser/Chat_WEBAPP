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
    public class ChatMessagesController : ControllerBase
    {
        private readonly ChatContext _context;

        public ChatMessagesController(ChatContext context)
        {
            _context = context;
        }

        // GET: api/ChatMessages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatMessages>>> GetChatMessages()
        {
            return await _context.ChatMessages.ToListAsync();
        }

        // GET: api/ChatMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatMessages>> GetChatMessages(int id)
        {
            var chatMessages = await _context.ChatMessages.FindAsync(id);

            if (chatMessages == null)
            {
                return NotFound();
            }

            return chatMessages;
        }

        // PUT: api/ChatMessages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatMessages(int id, ChatMessages chatMessages)
        {
            if (id != chatMessages.ChatMessageID)
            {
                return BadRequest();
            }

            _context.Entry(chatMessages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatMessagesExists(id))
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

        // POST: api/ChatMessages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChatMessages>> PostChatMessages(ChatMessages chatMessages)
        {
            _context.ChatMessages.Add(chatMessages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatMessages", new { id = chatMessages.ChatMessageID }, chatMessages);
        }

        // DELETE: api/ChatMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatMessages(int id)
        {
            var chatMessages = await _context.ChatMessages.FindAsync(id);
            if (chatMessages == null)
            {
                return NotFound();
            }

            _context.ChatMessages.Remove(chatMessages);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChatMessagesExists(int id)
        {
            return _context.ChatMessages.Any(e => e.ChatMessageID == id);
        }
    }
}
