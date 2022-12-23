using Microsoft.AspNetCore.Mvc;
using OrderAPI.Models;
using System.Net;

namespace Order_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private readonly SignupContext _context;

        public SignupController(SignupContext context)
        {
            _context = context;
        }
        
        [HttpPost("Signup")]
        public async Task<ActionResult<Signup>> CreateUser(Signup user) 
        {
            var NewUser = await _context.Signups.FindAsync(user.Email);
            if (NewUser==null)
            {
                _context.Signups.Add(user);
                await _context.SaveChangesAsync();
                return Ok(new { Message = "User Registered Sucsessfully" });
            }
            else 
                return BadRequest(user);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<Signup>> Login(Signup userLogin)
        {
            var user = await _context.Signups.FindAsync(userLogin.Email);
            if(user==null)
                return NotFound(new {Message ="User Not Found"});
            else if(user.Password!=userLogin.Password)
                    return BadRequest(new { Message = "Incorrect Password" });
            else
                return Ok(new {Message = "Login Sucsessful"});
        }

    }
}
