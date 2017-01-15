using Mastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mastery.Models;

namespace MasteryTests.Mock_Repositories
{
    public class ProductInfoMockRepository : IProductInfoRepository
    {
        public decimal GetCostPerSquareFoot(ProductType Material, string Type)
        {
            ProductType _material = Material;

            string _type = Type;

            if (_material == ProductType.Carpet && _type == "Cost")
            {
                return 2.00M;
            }

            else if (_material == ProductType.Laminate && _type == "Labor")
            {
                return 3.00M;
            }

            return 0M;
        }
    }
}
