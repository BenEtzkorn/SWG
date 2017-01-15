using Mastery.BLL;
using Mastery.Data;
using Mastery.Models;
using Mastery.Models.Responses;
using System;

namespace Mastery.UI.WorkFlows
{
    public class AddWorkflow
    {
        private string _date;
        private string _fdate;
        private string _CustomerName;
        private string _State;
        private decimal _TaxRate;
        private ProductType _material;
        private decimal _Area;
        private decimal _CostPerSqFt;
        private decimal _LaborCostPerSqFt;
               
        public void Execute()
        {
            Console.Clear();

            OrderManager manager = OrderManagerFactory.Create();
       
            ConsoleIO CIO = new ConsoleIO();
            _date = CIO.GetDate();
            _fdate = CIO.GetFutureDate(_date);   
            _CustomerName = CIO.GetCustomerName();
            _State = CIO.GetState();
            _material = CIO.GetProductType();
            _Area = CIO.GetArea();

            OrderAddResponse response = manager.GetTaxRate(_State);

            if (response.Success)
            {
                TaxFileRepository tax = new TaxFileRepository();
                _TaxRate = tax.GetTaxRate(_State);

                ProductFileRepository product = new ProductFileRepository();
                _CostPerSqFt = product.GetCostPerSquareFoot(_material,"Cost");
                _LaborCostPerSqFt = product.GetCostPerSquareFoot(_material,"Labor");

                Order order = new Order()
                {
                    Date = _date,
                    CustomerName = _CustomerName,
                    State = _State,
                    TaxRate = _TaxRate,
                    Product = _material,
                    Area = _Area,
                    CostPerSquareFoot = _CostPerSqFt,
                    LaborCostPerSquareFoot = _LaborCostPerSqFt,
                                
                };

                CIO.VerifyOrder(order);

                OrderAddResponse response2 = manager.AddOrder(order);

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
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
     
        }

    }
}
