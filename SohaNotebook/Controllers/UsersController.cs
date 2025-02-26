using Microsoft.AspNetCore.Mvc;
using SohaNotebook.Data;
using SohaNotebook.DbSet;
using SohaNotebook.Dtos.Incomming;

namespace SohaNotebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private AppDbContext? _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context?.Users.Where(u => u.Status == 1).ToList();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult CreateUser(UserDto user)
        {
            var _user = new User();
            _user.FirstName = user.FirstName;
            _user.LastName = user.LastName;
            _user.DateOfBirth = DateTime.Parse(user.DateOfBirth);
            _user.Email = user.Email;
            _user.Phone = user.Phone;
            _user.Country = user.Country;
            _user.Status = 1;
            _context?.Users.Add(_user);
            _context?.SaveChanges();
            return Ok(user);
        }
    }
}
