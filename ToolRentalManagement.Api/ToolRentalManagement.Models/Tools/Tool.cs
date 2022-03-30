using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolRentalManagement.Models.Tools
{
    public class Tool
    {
        public int Id { get; set; }
        public string ItemCode { get; set; }
        [Required, MaxLength(100)]
        public string ToolName { get; set; }
        [MaxLength(500)]
        public string ToolDescription { get; set; }
        [Required]
        public int TotalQuantity { get; set; }
        public int AvailableQuantity { get; set; }
        public int RentedQuantity { get; set; }
        [Required]
        public float ChargesPerDay { get; set; }


    }
}
