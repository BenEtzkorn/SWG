using Mastery.BLL;
using Mastery.Models.Responses;
using System;

namespace Mastery.UI.WorkFlows
{
    public class LookupOrdersWorkflow //This launches and checks the order lookup
    {
        private string _date;

        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Lookup all orders on a given date");
            Console.WriteLine("*********************************");

            Console.WriteLine("");

            ConsoleIO Date = new ConsoleIO();

            _date = Date.GetDate();

            OrdersLookupResponse response = manager.LookUpOrders(_date);

            if(response.Success)
            {
                ConsoleIO.DisplayOrderDetails(response.Orders);
            }
            else
            {
                Console.WriteLine("An error occured:  ");
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}
