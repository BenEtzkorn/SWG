using Mastery.UI.WorkFlows;
using System;

namespace Mastery.UI
{
    public static class Menu
    {
        public static void Start()//This is the main start menu
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("******************************************************************************************");
                Console.WriteLine("");
                Console.WriteLine("* Flooring Program *");
                Console.WriteLine("");
                Console.WriteLine(" D - Display Orders");
                Console.WriteLine("");
                Console.WriteLine(" A - Add an Order");
                Console.WriteLine("");
                Console.WriteLine(" E - Edit an Order");
                Console.WriteLine("");
                Console.WriteLine(" R - Remove an Order");
                Console.WriteLine("");
                Console.WriteLine(" Q - Quit");
                Console.WriteLine("");
                Console.WriteLine("******************************************************************************************");
                Console.WriteLine("");
                Console.Write(" Enter D, A, E, R or Q: ");

                string userinput = Console.ReadLine().ToUpper();

                switch (userinput)
                {
                    case "D":
                        LookupOrdersWorkflow LookupWorkflow = new LookupOrdersWorkflow();
                        LookupWorkflow.Execute();
                        break;
                    case "A":
                        AddWorkflow AddWorkflow = new AddWorkflow();
                        AddWorkflow.Execute();
                        break;
                    case "E":
                        EditWorkflow EditWorkflow = new EditWorkflow();
                        EditWorkflow.Execute();
                        break;
                    case "R":
                        RemoveWorkflow RemoveWorkflow = new RemoveWorkflow();
                        RemoveWorkflow.Execute();
                        break;
                    case "Q":
                        return;
                }

            }
        }
    }
}

