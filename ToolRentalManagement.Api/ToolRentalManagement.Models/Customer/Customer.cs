using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace ToolRentalManagement.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string FullName { get; set; }
        [Required, MaxLength(20)]
        public string NIC { get; set; }
        [Required, MaxLength(15)]
        public string Contact { get; set; }
        [Required, MaxLength(500)]
        public string Address { get; set; }

        public List<Order> Orders { get; set; }
    }
}
