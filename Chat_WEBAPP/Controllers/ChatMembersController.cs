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
    public class ChatMembersController : ControllerBase
    {
        private readonly ChatContext _context;

        public ChatMembersController(ChatContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatMembers>>> GetChatMembers()
        {
            return await _context.ChatMembers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChatMembers>> GetChatMembers(int id)
        {
            var chatMembers = await _context.ChatMembers.FindAsync(id);

            if (chatMembers == null)
            {
                return NotFound();
            }

            return chatMembers;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatMembers(int id, ChatMembers chatMembers)
        {
            if (id != chatMembers.ChatMemberID)
            {
                return BadRequest();
            }

            _context.Entry(chatMembers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatMembersExists(id))
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

        [HttpPost]
        public async Task<ActionResult<ChatMembers>> PostChatMembers(ChatMembers chatMembers)
        {
            _context.ChatMembers.Add(chatMembers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatMembers", new { id = chatMembers.ChatMemberID }, chatMembers);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatMembers(int id)
        {
            var chatMembers = await _context.ChatMembers.FindAsync(id);
            if (chatMembers == null)
            {
                return NotFound();
            }

            _context.ChatMembers.Remove(chatMembers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChatMembersExists(int id)
        {
            return _context.ChatMembers.Any(e => e.ChatMemberID == id);
        }
    }
}
