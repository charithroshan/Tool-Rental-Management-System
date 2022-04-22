using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolRentalManagement.Models;
using ToolRentalManagement.Services.Dtos.ToolDtos;

namespace ToolRentalManagement.Services.Profiles
{
    public class ToolProfile : Profile
    {
        public ToolProfile()
        {
            CreateMap<Tool, UpdateToolDto>();
        }
    }
}
