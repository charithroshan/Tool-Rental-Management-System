using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolRentalManagement.Models.Business
{
    public class Business
    {
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string BusinessName { get; set; }
        [Required, MaxLength(20)]
        public string Contact { get; set; }
        [Required, MaxLength(500)]
        public string Address { get; set; }
        [Required, MaxLength(255)]
        public string OwnerName { get; set; }
        [Required, MaxLength(20)]
        public string OwnerNIC { get; set; }
    }
}
