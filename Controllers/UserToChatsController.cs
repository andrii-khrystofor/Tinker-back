using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tinker_Back;

namespace Tinker_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserToChatsController : ControllerBase
    {
        private readonly TinkerDbContext _context;

        public UserToChatsController(TinkerDbContext context)
        {
            _context = context;
        }

        // GET: api/UserToChats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserToChat>>> GetUserToChats()
        {
          if (_context.UserToChats == null)
          {
              return NotFound();
          }
            return await _context.UserToChats.ToListAsync();
        }

        // GET: api/UserToChats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserToChat>> GetUserToChat(int id)
        {
          if (_context.UserToChats == null)
          {
              return NotFound();
          }
            var userToChat = await _context.UserToChats.FindAsync(id);

            if (userToChat == null)
            {
                return NotFound();
            }

            return userToChat;
        }

        // PUT: api/UserToChats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserToChat(int id, UserToChat userToChat)
        {
            if (id != userToChat.Id)
            {
                return BadRequest();
            }

            _context.Entry(userToChat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserToChatExists(id))
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

        // POST: api/UserToChats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserToChat>> PostUserToChat(UserToChat userToChat)
        {
          if (_context.UserToChats == null)
          {
              return Problem("Entity set 'TinkerDbContext.UserToChats'  is null.");
          }
            _context.UserToChats.Add(userToChat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserToChat", new { id = userToChat.Id }, userToChat);
        }

        // DELETE: api/UserToChats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserToChat(int id)
        {
            if (_context.UserToChats == null)
            {
                return NotFound();
            }
            var userToChat = await _context.UserToChats.FindAsync(id);
            if (userToChat == null)
            {
                return NotFound();
            }

            _context.UserToChats.Remove(userToChat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserToChatExists(int id)
        {
            return (_context.UserToChats?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
