using Mastery.Models;
using Mastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastery.Data
{
    public class ProductFileRepository : IProductInfoRepository
    {

        private ProductType _material;
        private decimal _Labor;
        private decimal _Cost;
        private string _type;

        public decimal GetCostPerSquareFoot(ProductType Material, string Type) //This gets the material costs and labor costs from the product file for a specific product type
        {

            _material = Material;

            _type = Type;

            using (StreamReader sr = new StreamReader(Settings.ProductFilePath))
            {
                sr.ReadLine();

                string line;

                while ((line = sr.ReadLine()) != null)
                {

                    string[] columns = line.Split(',');

                    string temp = columns[0];

                    if (temp == "Carpet" && _material == ProductType.Carpet)
                    {
                        _Cost = decimal.Parse(columns[1]);
                        _Labor = decimal.Parse(columns[2]);

                        if (_type == "Cost")
                        {
                            return _Cost;
                        }
                        else
                        {
                            return _Labor;
                        }

                    }

                    else if (temp == "Laminate" && _material == ProductType.Laminate)
                    {
                        _Cost = decimal.Parse(columns[1]);
                        _Labor = decimal.Parse(columns[2]);

                        if (_type == "Cost")
                        {
                            return _Cost;
                        }
                        else
                        {
                            return _Labor;
                        }

                    }

                    else if (temp == "Tile" && _material == ProductType.Tile)
                    {
                        _Cost = decimal.Parse(columns[1]);
                        _Labor = decimal.Parse(columns[2]);

                        if (_type == "Cost")
                        {
                            return _Cost;
                        }
                        else
                        {
                            return _Labor;
                        }
                    }

                    else if (temp == "Wood" && _material == ProductType.Wood)
                    {
                        _Cost = decimal.Parse(columns[1]);
                        _Labor = decimal.Parse(columns[2]);

                        if (_type == "Cost")
                        {
                            return _Cost;
                        }
                        else
                        {
                            return _Labor;
                        }
                    }

                }

                return GetCostPerSquareFoot(_material,_type);

            }
        }   

    }

}

