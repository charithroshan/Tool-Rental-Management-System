using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolRentalManagement.Services.Dtos.ToolDtos
{
    public class UpdateToolDto
    {
        public string ItemCode { get; set; }
        public string ToolName { get; set; }
        public string ToolDescription { get; set; }
        public int TotalQuantity { get; set; }
        public int AvailableQuantity { get; set; }
        public int RentedQuantity { get; set; }
        public float ChargesPerDay { get; set; }
    }
}
