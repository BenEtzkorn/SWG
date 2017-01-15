using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastery.Models.Interfaces
{
    public interface IProductInfoRepository
    {

        decimal GetCostPerSquareFoot(ProductType material, string type);

    }
}
