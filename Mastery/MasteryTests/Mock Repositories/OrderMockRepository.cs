using Mastery.Models;
using Mastery.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace MasteryTests
{
    public class OrderMockRepository: IOrderRepository
    {
        public Order AddOrder(Order order)
        {

            return order;

        }

        public Order DeleteOrder(string Date, int OrderNumber)
        {
            string _date = Date;

            int _orderNumber = OrderNumber;

            Order _order = new Order();

            try
            {
                _order = LoadOrder(_date, _orderNumber);

                return _order;

            }
            catch
            {
                return null;
            }               
            
        }

        public Order EditOrder(Order order)
        {
            string _date = order.Date;

            if (_date == "08012016")
            {
                return order;
            }
            else
            {
                return null;
            }
        }

        public Order LoadOrder(string Date, int OrderNumber)
        {
           
            string _date = Date;
            int _orderNumber = OrderNumber;

            List<Order> _orders = LoadOrders(_date);

            try
            {

                foreach (Order var in _orders)
                {
                    if (var.OrderNumber == _orderNumber)
                    {
                        return var;
                    }

                }
            }

            catch
            {
                return null;
            }

            return null;

        }

        public List<Order> LoadOrders(string Date)
        {

            string _date = Date;

            if (_date == "08012016" || _date == "08022016" || _date == "08032016")
            {

                List<Order> _orders = new List<Order>()
                {
                    new Order {
                    Date = "08012016",
                    OrderNumber = 1,
                    CustomerName = "Wise",
                    State = "OH",
                    TaxRate = 5.75M,
                    Product = ProductType.Wood,
                    Area = 100.00M,
                    CostPerSquareFoot = 5.15M,
                    LaborCostPerSquareFoot = 4.75M,

                    },

                    new Order {
                    Date = "08032016",
                    OrderNumber = 1,
                    CustomerName = "Ward",
                    State = "MN",
                    TaxRate = 6.88M,
                    Product = ProductType.Carpet,
                    Area = 200.00M,
                    CostPerSquareFoot = 2.25M,
                    LaborCostPerSquareFoot = 2.10M,

                    },

                    new Order {
                    Date = "08022016",
                    OrderNumber = 1,
                    CustomerName = "Clapper",
                    State = "DC",
                    TaxRate = 5.75M,
                    Product = ProductType.Laminate,
                    Area = 300.00M,
                    CostPerSquareFoot = 1.75M,
                    LaborCostPerSquareFoot = 2.10M,

                    },

                    new Order {
                    Date = "08032016",
                    OrderNumber = 2,
                    CustomerName = "Butler",
                    State = "OH",
                    TaxRate = 6.25M,
                    Product = ProductType.Tile,
                    Area = 400.00M,
                    CostPerSquareFoot = 3.50M,
                    LaborCostPerSquareFoot = 4.15M,

                    }

                };

                return _orders;

            }

            else
            {
                return null;
            }
            
        }
        
        public int OrderNumber(string Date)
        {
            string _date = Date;

            List<Order> _orders = LoadOrders(_date);

            int x = 1;

            foreach (Order order in _orders)
            {
                if (x < order.OrderNumber)
                {
                    x = order.OrderNumber;
                }
            }

            return x; 
        }
    }
}
