using ASP_Projekat_API.Jwt;
using ASP_Projekat_Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Projekat_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtManager _manager;

        public AuthController(JwtManager manager)
        {
            _manager = manager;
        }

        // POST api/<AuthController>
        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest request,
                         [FromServices] BlogContext context)
        {
            //var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            //Hash nije implementiran jer je napravlje pocetni kontroler za sifre koje nisu hesovane
            var user = context.Users.Include(x => x.Role).FirstOrDefault(x => x.Email == request.Email && x.Password == request.Password);
            if (user == null)
            {
                return StatusCode(401,new {message="Invalid credentials"});
            }
            string token = _manager.MakeToken(request.Email, request.Password);

            return Ok(new { token });
        }

        [HttpDelete]
        [Authorize]
        public IActionResult InvalidateToken([FromServices] ITokenStorage storage)
        {
            var header = HttpContext.Request.Headers["Authorization"];

            var token = header.ToString().Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            string jti = tokenObj.Claims.FirstOrDefault(x => x.Type == "jti").Value;

            storage.InvalidateToken(jti);

            return NoContent();
        }
    }
}
