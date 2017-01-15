using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastery.Models.Responses
{
    public class OrdersLookupResponse: Response  //inherits the status and message
    {

        public List<Order> Orders { get; set; } //returns the order object

    }
}