using Mastery.Models;
using Mastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

public class OrderRepository : IOrderRepository
{
    private string _date;
    private int _orderNumber;
    private Order _order;
    private int _ordernumber;
    private string _orderstring;
    private string _datapath;
    private string _header = "Date,OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total";
    private List<Order> _orders;

    public OrderRepository(string datapath)
    {
        _datapath = datapath;
    }

    public Order AddOrder(Order order)
    {
        _order = order;

        _ordernumber = 1;

        _date = _order.Date;

            if (!TestForFile(_date))
            {
                string newline = $"{_date},{_ordernumber},{_order.CustomerName},{_order.State},{ _order.TaxRate},{ _order.Product.ToString()},{ _order.Area},{ _order.CostPerSquareFoot},{ _order.LaborCostPerSquareFoot},{ _order.MaterialCost},{ _order.LaborCost},{ _order.Tax},{ _order.Total}";

                File.Create(_datapath + _date + ".txt").Close();

                File.AppendAllText(_datapath + _date + ".txt", _header + Environment.NewLine);

                File.AppendAllText(_datapath + _date + ".txt", newline + Environment.NewLine);
            
                return LoadOrder(_date,_ordernumber);
            }

            else
            {
                _ordernumber = OrderNumber(_date)+1;

                _orderstring = $"{_order.Date},{_ordernumber},{_order.CustomerName},{_order.State},{ _order.TaxRate},{ _order.Product.ToString()},{ _order.Area},{ _order.CostPerSquareFoot},{ _order.LaborCostPerSquareFoot},{ _order.MaterialCost},{ _order.LaborCost},{ _order.Tax},{ _order.Total}";

                File.AppendAllText(_datapath + _date + ".txt", _orderstring + Environment.NewLine);

                return LoadOrder(_date,_ordernumber);
        }
    }

    public Order DeleteOrder(string Date, int OrderNumber)
    {
        _date = Date;

        _ordernumber = OrderNumber;

        List<Order> _orders = LoadOrders(_date);

        File.Delete(_datapath + _date + ".txt");

        List<string> lines = new List<string>();

        lines.Add(_header);

        foreach (Order order in _orders)
        {

            lines.Add($"{order.Date},{order.OrderNumber},{order.CustomerName},{order.State},{ order.TaxRate},{ order.Product.ToString()},{ order.Area},{ order.CostPerSquareFoot},{ order.LaborCostPerSquareFoot},{ order.MaterialCost},{ order.LaborCost},{ order.Tax},{ order.Total}");

        }

        File.CreateText(_datapath + _date + ".txt").Close();

        using (StreamWriter sw = new StreamWriter(_datapath + _date + ".txt"))
        {
            foreach (string newline in lines)
            {
                string[] columns = newline.Split(',');

                if (columns[1] != _ordernumber.ToString())
                {
                    sw.WriteLine(newline);
                }
            }
        }

       return null;
    }
       
    public Order EditOrder(Order order)
    {
        Order _neworder = new Order();

        _neworder = order;

        _date = _neworder.Date;

        _ordernumber = _neworder.OrderNumber;

        List<Order> _oldorders = LoadOrders(_date);

        List<string> lines = new List<string>();

        lines.Add(_header);

        foreach (Order temp in _oldorders)
        {

            if(temp.OrderNumber == _ordernumber)
            {
                lines.Add($"{_date},{_ordernumber},{_neworder.CustomerName},{_neworder.State},{ _neworder.TaxRate},{ _neworder.Product.ToString()},{ _neworder.Area},{ _neworder.CostPerSquareFoot},{ _neworder.LaborCostPerSquareFoot},{ _neworder.MaterialCost},{ _neworder.LaborCost},{ _neworder.Tax},{ _neworder.Total}");
            }
            else
            {
                lines.Add($"{temp.Date},{temp.OrderNumber},{temp.CustomerName},{temp.State},{ temp.TaxRate},{ temp.Product.ToString()},{ temp.Area},{ temp.CostPerSquareFoot},{ temp.LaborCostPerSquareFoot},{ temp.MaterialCost},{ temp.LaborCost},{ temp.Tax},{ temp.Total}");
            }
        }

        File.Delete(_datapath + _date + ".txt");

        File.CreateText(_datapath + _date + ".txt").Close();

        using (StreamWriter sw = new StreamWriter(_datapath + _date + ".txt"))
        {
           
            foreach (string _newline in lines)
            {
                
               sw.WriteLine(_newline);

            }
                
        }

        return LoadOrder(_date, _ordernumber);
    }

    public Order LoadOrder(string Date, int OrderNumber)
    {
        _date = Date;
        _orderNumber = OrderNumber;

        List<Order> _orders = LoadOrders(_date);

        foreach (Order var in _orders)
        {
            if (var.OrderNumber == _orderNumber)
            {
                return var;
            }

        }

        return null;
    }

    public List<Order> LoadOrders(string Date)
    {

        _date = Date;

        try
        {

            using (StreamReader sr = new StreamReader(_datapath + _date + ".txt"))
            {
                sr.ReadLine();
                string line;

                _orders = new List<Order>();

                while ((line = sr.ReadLine()) != null)
                {

                    string[] columns = line.Split(',');

                    _orders.Add(new Order()
                    {
                        Date = columns[0],
                        OrderNumber = int.Parse(columns[1]),
                        CustomerName = columns[2],
                        State = columns[3],
                        TaxRate = decimal.Parse(columns[4]),
                        Product = (ProductType)Enum.Parse(typeof(ProductType), columns[5]),
                        Area = decimal.Parse(columns[6]),
                        CostPerSquareFoot = decimal.Parse(columns[7]),
                        LaborCostPerSquareFoot = decimal.Parse(columns[8]),
                    });

                }

                return _orders;

            }

        }

        catch
        {
            return null;
        }

    }

    public int OrderNumber(string Date)
    {
        _date = Date;

        List<Order> _orders = LoadOrders(_date);

        int x = 1;

        foreach(Order order in _orders)
        {
            if(x < order.OrderNumber)
            {
                x = order.OrderNumber;
            }
        }

        return x;

    }

    public bool TestForFile(string Date)
    {

        return File.Exists(_datapath + _date + ".txt");
     
    }
}