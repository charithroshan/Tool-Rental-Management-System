using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace ToolRentalManagement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Tool { get; set; }
        public int Quantity { get; set; }

        public int CustomerId { get; set; }
       

    }
}
