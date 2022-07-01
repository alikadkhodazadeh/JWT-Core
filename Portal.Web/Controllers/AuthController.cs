using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Portal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IContext _db;
        private readonly IAuthenticateService _authenticate;

        public AuthController(IContext db, IAuthenticateService authenticate)
        {
            _db = db;
            _authenticate = authenticate;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellation)
        {
            var user = _db.Users
                .AsNoTracking()
                .FirstOrDefault(u => u.FirstName.Equals("Jack"));

            var token = await _authenticate.Authenticate(user, cancellation);

            return Ok(token);
        }
    }
}
