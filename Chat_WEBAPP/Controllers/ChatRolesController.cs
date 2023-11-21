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
    public class ChatRolesController : ControllerBase
    {
        private readonly ChatContext _context;

        public ChatRolesController(ChatContext context)
        {
            _context = context;
        }

        // GET: api/ChatRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatRoles>>> GetChatRoles()
        {
            return await _context.ChatRoles.ToListAsync();
        }

        // GET: api/ChatRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatRoles>> GetChatRoles(int id)
        {
            var chatRoles = await _context.ChatRoles.FindAsync(id);

            if (chatRoles == null)
            {
                return NotFound();
            }

            return chatRoles;
        }

        // PUT: api/ChatRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatRoles(int id, ChatRoles chatRoles)
        {
            if (id != chatRoles.ChatRoleID)
            {
                return BadRequest();
            }

            _context.Entry(chatRoles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatRolesExists(id))
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

        // POST: api/ChatRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChatRoles>> PostChatRoles(ChatRoles chatRoles)
        {
            _context.ChatRoles.Add(chatRoles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatRoles", new { id = chatRoles.ChatRoleID }, chatRoles);
        }

        // DELETE: api/ChatRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatRoles(int id)
        {
            var chatRoles = await _context.ChatRoles.FindAsync(id);
            if (chatRoles == null)
            {
                return NotFound();
            }

            _context.ChatRoles.Remove(chatRoles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChatRolesExists(int id)
        {
            return _context.ChatRoles.Any(e => e.ChatRoleID == id);
        }
    }
}
