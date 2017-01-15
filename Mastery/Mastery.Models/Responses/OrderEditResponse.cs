using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastery.Models.Responses
{
    public class OrderEditResponse: Response
    {

        public Order Order { get; set; } //returns the order object

    }
}
