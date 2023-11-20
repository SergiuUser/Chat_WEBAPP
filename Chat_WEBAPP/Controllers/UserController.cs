using Chat_WEBAPP.Context;
using Chat_WEBAPP.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chat_WEBAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private ChatContext _chatContext;

        public UserController(ChatContext chatContext)
        {
            _chatContext = chatContext;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _chatContext.Users;
        }


        [HttpGet("{id}")]
        public User Get(string username)
        {
            return _chatContext.Users.FirstOrDefault(s => s.Username == username);
        }

        [HttpPost]
        public void Post([FromBody] User entity)
        {
            _chatContext.Users.Add(entity);
            _chatContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(string username, [FromBody] User entity)
        {
            var user = _chatContext.Users.FirstOrDefault(s => s.Username == username);
            if (user != null)
            {
                _chatContext.Entry<User>(user).CurrentValues.SetValues(entity);
                _chatContext.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(string username)
        {
            var User = _chatContext.Users.FirstOrDefault(s => s.Username == username);
            if (User != null)
            {
                _chatContext.Users.Remove(User);
                _chatContext.SaveChanges();
            }
        }
    }
}
