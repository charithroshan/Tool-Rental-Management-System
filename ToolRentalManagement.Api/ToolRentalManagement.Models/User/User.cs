using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ToolRentalManagement.Models.User
{
    public class User
    {
        public readonly ClaimsIdentity? Username;

        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string FullName { get; set; }
        [Required, MaxLength(150)]
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
