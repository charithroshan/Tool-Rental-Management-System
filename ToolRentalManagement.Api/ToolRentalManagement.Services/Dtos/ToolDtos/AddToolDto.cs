using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolRentalManagement.Services.Dtos.ToolDtos
{
    public class AddToolDto
    {
        public string ToolName { get; set; }
        public string ItemCode { get; set; }
        public string ToolDescription { get; set; }
        public int TotalQuantity { get; set; }
        public float ChargesPerDay { get; set; }
    }
}
