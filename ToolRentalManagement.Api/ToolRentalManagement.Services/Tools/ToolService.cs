using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolRentalManagement.DataAccess;
using ToolRentalManagement.Models;

namespace ToolRentalManagement.Services.Tools
{
    public class ToolService : IToolRepository
    {
        private DataContext _context = new DataContext();
        public List<Tool> GetTools(String search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return _context.Tools.ToList();
            }

            return _context.Tools.Where(t => t.ToolName.Contains(search) || t.ItemCode.Contains(search)).ToList();
        }

        public Tool GetToolByItemCode(string itemCode)
        {
             return _context.Tools.FirstOrDefault(t => t.ItemCode == itemCode);
            
        }
    }
}
