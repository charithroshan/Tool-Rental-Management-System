using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolRentalManagement.Models;

namespace ToolRentalManagement.Services.Tools
{
    public interface IToolRepository
    {
        public List<Tool> GetTools(string search);
        public Tool GetToolByItemCode(string name);
    }
}
