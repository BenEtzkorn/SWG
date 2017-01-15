using Mastery.BLL;
using Mastery.Models.Responses;
using System;

namespace Mastery.UI.WorkFlows
{
    public class RemoveWorkflow
    {
        private string _date;
       
        private int _OrderNumber;

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
                CIO.ConfirmDelete(response.Order);

                OrderDeleteResponse response2 = manager.DeleteOrder(_date, _OrderNumber);

                if (response2.Success)
                {

                }
                else
                {

                    Console.WriteLine("An error occurred: ");
                    Console.WriteLine(response2.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

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
