using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ToolRentalManagement.DataAccess;
using ToolRentalManagement.Models.User;

namespace ToolRentalManagement.Services.Users
{
    public class UserService : IUserRepository
    {

        private readonly DataContext _context = new DataContext();

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public User GetUserByUserName(string UserName)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == UserName);
        }


        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public List<User> GetAllAuthors(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return _context.Users.ToList();
            }

            return _context.Users.Where(Users => Users.UserName.Contains(search) ||Users.FullName.Contains(search)).ToList();
        }

    }
}
