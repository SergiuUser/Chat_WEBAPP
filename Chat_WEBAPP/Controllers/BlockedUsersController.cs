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
    public class BlockedUsersController : ControllerBase
    {
        private readonly ChatContext _context;

        public BlockedUsersController(ChatContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlockedUsers>>> GetBlockedUsers()
        {
            return await _context.BlockedUsers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlockedUsers>> GetBlockedUsers(int id)
        {
            var blockedUsers = await _context.BlockedUsers.FindAsync(id);

            if (blockedUsers == null)
            {
                return NotFound();
            }

            return blockedUsers;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlockedUsers(int id, BlockedUsers blockedUsers)
        {
            if (id != blockedUsers.BlockedUserID)
            {
                return BadRequest();
            }

            _context.Entry(blockedUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlockedUsersExists(id))
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
        public async Task<ActionResult<BlockedUsers>> PostBlockedUsers(BlockedUsers blockedUsers)
        {
            _context.BlockedUsers.Add(blockedUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlockedUsers", new { id = blockedUsers.BlockedUserID }, blockedUsers);
        }
 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlockedUsers(int id)
        {
            var blockedUsers = await _context.BlockedUsers.FindAsync(id);
            if (blockedUsers == null)
            {
                return NotFound();
            }

            _context.BlockedUsers.Remove(blockedUsers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlockedUsersExists(int id)
        {
            return _context.BlockedUsers.Any(e => e.BlockedUserID == id);
        }
    }
}
