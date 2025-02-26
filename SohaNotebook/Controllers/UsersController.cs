using Microsoft.AspNetCore.Mvc;
using SohaNotebook.Data;
using SohaNotebook.DbSet;
using SohaNotebook.DbSet.IConfiguration;
using SohaNotebook.Dtos.Incomming;
using System.Threading.Tasks;

namespace SohaNotebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        //private AppDbContext? _context;
        private IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            //var users = _context?.Users.Where(u => u.Status == 1).ToList();
            var users = await _unitOfWork.Users.GetAllAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto user)
        {
            var _user = new User();
            _user.FirstName = user.FirstName;
            _user.LastName = user.LastName;
            _user.DateOfBirth = DateTime.Parse(user.DateOfBirth);
            _user.Email = user.Email;
            _user.Phone = user.Phone;
            _user.Country = user.Country;
            _user.Status = 1;
            await _unitOfWork.Users.CreateAsync(_user);
            await _unitOfWork.CompleteAsync();
            return CreatedAtRoute("GetUser", new{id = _user.Id}, user);
        }

        [HttpGet("GetUser", Name = "GetUser")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _unitOfWork.Users.GetById(id);
            return Ok(user);
        }
    }
}
