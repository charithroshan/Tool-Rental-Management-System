using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolRentalManagement.Models.User;
using ToolRentalManagement.Services.Dtos.UserDtos;

namespace ToolRentalManagement.Services.Profiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User,GetUserDto>();
        }
    }
}
