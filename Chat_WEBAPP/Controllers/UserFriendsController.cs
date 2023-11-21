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
    public class UserFriendsController : ControllerBase
    {
        private readonly ChatContext _context;

        public UserFriendsController(ChatContext context)
        {
            _context = context;
        }

        // GET: api/UserFriends
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserFriends>>> GetUserFriends()
        {
            return await _context.UserFriends.ToListAsync();
        }

        // GET: api/UserFriends/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserFriends>> GetUserFriends(int id)
        {
            var userFriends = await _context.UserFriends.FindAsync(id);

            if (userFriends == null)
            {
                return NotFound();
            }

            return userFriends;
        }

        // PUT: api/UserFriends/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserFriends(int id, UserFriends userFriends)
        {
            if (id != userFriends.FrindID)
            {
                return BadRequest();
            }

            _context.Entry(userFriends).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserFriendsExists(id))
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

        // POST: api/UserFriends
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserFriends>> PostUserFriends(UserFriends userFriends)
        {
            _context.UserFriends.Add(userFriends);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserFriends", new { id = userFriends.FrindID }, userFriends);
        }

        // DELETE: api/UserFriends/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserFriends(int id)
        {
            var userFriends = await _context.UserFriends.FindAsync(id);
            if (userFriends == null)
            {
                return NotFound();
            }

            _context.UserFriends.Remove(userFriends);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserFriendsExists(int id)
        {
            return _context.UserFriends.Any(e => e.FrindID == id);
        }
    }
}
