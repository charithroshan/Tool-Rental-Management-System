using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ToolRentalManagement.DataAccess;
using ToolRentalManagement.Models.User;
using ToolRentalManagement.Services.Dtos.UserDtos;
using ToolRentalManagement.Services.Users;

namespace ToolRentalManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public User user = new User();
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly DataContext _context = new DataContext();
        public UsersController(IUserRepository userRepository, IConfiguration configuration, IMapper mapper)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(RegisterUserDto request)
        {
            //IQueryable<User> users = _context.Users.Where(u => u.UserName == request.UserName);
            //if (users.Any())
            User users = _userRepository.GetUserByUserName(request.UserName);
            if (users != null)
            {
                return BadRequest("User Name is Already exist. Try another one.");
            }

            else
            {
                _userRepository.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
                user.FullName = request.FullName;
                user.UserName = request.UserName;
                user.IsAdmin = request.IsAdmin;
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

               return Ok();
            }
            //return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginUserDto request)
        {
            //IQueryable<User> users = _context.Users.Where(u => u.UserName == request.UserName);
           User users = _userRepository.GetUserByUserName(request.UserName);
            //if (!users.Any())
            if(users == null)
            {
                return BadRequest("User Not Found");
            }

            if (!_userRepository.VerifyPasswordHash(request.Password, users.PasswordHash, users.PasswordSalt))
            {
                return BadRequest("Wrong Password");
            }

            string token = CreateToken(users);
            return Ok(token);

        }


        [HttpGet]
        public ActionResult<ICollection<GetUserDto>> GetUsers(string? search)
        {
            var users = _userRepository.GetAllAuthors(search);
            var mappedUsers = _mapper.Map<ICollection<GetUserDto>>(users);
            return Ok(mappedUsers);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTodoItem(string? userName, string? password, RegisterUserDto request)
        {
            if(userName.IsNullOrEmpty())
            {
                return BadRequest("Username Required");
            }

            User user = _userRepository.GetUserByUserName(userName);
            if (user == null)
            {
                return NotFound("Wrong User Name");
            }

            if(password.IsNullOrEmpty())
            {
                return BadRequest("Password is Required");
            }

            if (!_userRepository.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong Password");
            }

            _userRepository.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.FullName = request.FullName;
            user.UserName = request.UserName;
            user.IsAdmin = request.IsAdmin;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTodoItem(string userName)
        {
            //var todoItem = await _context.TodoItems.FindAsync(id);
            User user = _userRepository.GetUserByUserName(userName);

            if (user == null)
            {
                return NotFound("Wrong User Name");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
