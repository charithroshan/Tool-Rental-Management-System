using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolRentalManagement.Models.User;

namespace ToolRentalManagement.Services.Users
{
    public interface IUserRepository
    {
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        public User GetUserByUserName(string UserName);
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        public List<User> GetAllAuthors(string search);


    }
}
