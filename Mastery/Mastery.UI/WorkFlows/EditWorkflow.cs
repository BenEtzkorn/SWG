using Mastery.BLL;
using Mastery.Data;
using Mastery.Models;
using Mastery.Models.Responses;
using System;

namespace Mastery.UI.WorkFlows
{
    public class EditWorkflow
    {
        private string _date;
        private int _OrderNumber;
        private string _CustomerName;
        private string _CustomerName2;
        private string _State;
        private string _State2;
        private decimal _TaxRate;
        private ProductType _material;
        private ProductType _material2;
        private decimal _Area;
        private decimal _Area2;
        private decimal _CostPerSqFt;
        private decimal _LaborCostPerSqFt;
          private Order _order;

        public void Execute()
        {

            Console.Clear();

            OrderManager manager = OrderManagerFactory.Create();
            
            ConsoleIO CIO = new ConsoleIO();
            _date = CIO.GetDate();
            _OrderNumber = CIO.GetOrderNumber();
   
            OrderLookupResponse response = manager.LookUpOrder(_date, _OrderNumber);

            if (response.Success)
            {

                _order = response.Order;

                CIO.VerifyOrder(_order);

                _Area = _order.Area;
                _material = _order.Product;
                _CustomerName = _order.CustomerName;
                _State = _order.State;

                Console.Clear();

                _Area2 = CIO.EditArea(_Area);
                _material2 = CIO.EditProductType(_material);
                _CustomerName2 = CIO.EditCustomerName(_CustomerName);
                _State2 = CIO.EditState(_State);

                TaxFileRepository repo = new TaxFileRepository();
                _TaxRate = repo.GetTaxRate(_State2);

                ProductFileRepository Uni = new ProductFileRepository();
                _CostPerSqFt = Uni.GetCostPerSquareFoot(_material2,"Cost");
                _LaborCostPerSqFt = Uni.GetCostPerSquareFoot(_material2,"Labor");

                Order order2 = new Order()
                {
                    Date = _date,
                    OrderNumber = _OrderNumber,
                    CustomerName = _CustomerName2,
                    State = _State2,
                    TaxRate = _TaxRate,
                    Product = _material2,
                    Area = _Area2,
                    CostPerSquareFoot = _CostPerSqFt,
                    LaborCostPerSquareFoot = _LaborCostPerSqFt,
                };

                CIO.VerifyOrder(order2);

                OrderEditResponse response2 = manager.EditOrder(order2);

                if (response2.Success)
                { 

                }
                else
                {
                    Console.WriteLine("An error occurred: ");
                    Console.WriteLine(response2.Message);
                }

            }
            else
            {
                Console.WriteLine("An error occured: ");
                Console.WriteLine(response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            }

            
        }
    }
}
