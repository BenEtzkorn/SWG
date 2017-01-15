using Mastery.Data;
using Mastery.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Mastery.UI
{
    public class ConsoleIO
    {

        private decimal _Area;
        private string _State;
        private string _StateList;
        private string _CustomerName;
        private string _TempDate;
        private string _input;
        private string _date;
        private int _OrderNumber;
        private ProductType _material;

        public static void DisplayOrderDetails(List<Order> Orders)
        {

            foreach (var order in Orders)
            {

                DisplayOrder(order);

            }
        }

        public static void DisplayOrder(Order order) //This is the order display structure
        {

            Console.WriteLine("");
            Console.WriteLine("******************************************************************************************");
            Console.WriteLine("");
            Console.WriteLine($"Order Number: {order.OrderNumber}\t\t\t\t Date: {order.Date}");
            Console.WriteLine($"Customer Name: {order.CustomerName}\t\t\t State: {order.State}");
            Console.WriteLine($"Product Type: {order.Product}");
            Console.WriteLine($"MaterialCost: {order.MaterialCost.ToString("c")}");
            Console.WriteLine($"LaborCost: {order.LaborCost.ToString("c")}");
            Console.WriteLine($"Tax: {order.Tax.ToString("c")}");
            Console.WriteLine($"Total: {order.Total.ToString("c")}");
            Console.WriteLine("");
            Console.WriteLine("******************************************************************************************");
        }

        public string GetDate() //The purpose of this is to initiate the get date Console
        {
            Console.Clear();
            Console.WriteLine("");
            Console.Write("Enter an order date mm/dd/yyyy or press return for today's date: ");
            string input = Console.ReadLine().ToString();

            _TempDate = GetDateUni(input);

            return _TempDate;
        }

        public decimal EditArea(decimal Area)
        {
            _Area = Area;

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("The area for this order is currently " + _Area + " SqFt.");
            Console.WriteLine("");
            Console.WriteLine("Press return to keep this area, or E to change this area.");
            string userinput = Console.ReadLine().ToUpper();

            switch (userinput)
            {
                case "E":
                    return GetArea();

                case "":
                    return _Area;

                default:
                    Console.WriteLine("");
                    Console.WriteLine("You entered an incorrect letter, please try again.");
                    Console.WriteLine("Press return to continue...");
                    Console.ReadLine();
                    return EditArea(_Area);
            }
        }

        public ProductType EditProductType(ProductType Material)
        {
            _material = Material;

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("The product type for this order is currently listed as " + _material.ToString());
            Console.WriteLine("");
            Console.WriteLine("Press return to keep this product type, or E to change the product type.");
            string userinput = Console.ReadLine().ToUpper();

            switch (userinput)
            {
                case "E":
                    return GetProductType();

                case "":
                    return _material;

                default:
                    Console.WriteLine("");
                    Console.WriteLine("You entered an incorrect letter, please try again.");
                    Console.WriteLine("Press return to continue...");
                    Console.ReadLine();
                    return EditProductType(_material);
            }
        }

        public string EditState(string State)
        {
            _State = State;

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("The state for this order is currently listed as " + _State);
            Console.WriteLine("");
            Console.WriteLine("Press return to keep this state, or E to change the state.");
            string userinput = Console.ReadLine().ToUpper();

            switch (userinput)
            {
                case "E":
                    return GetState();

                case "":
                    return _State;

                default:
                    Console.WriteLine("");
                    Console.WriteLine("You entered an incorrect letter, please try again.");
                    Console.WriteLine("Press return to continue...");
                    Console.ReadLine();
                    return EditState(_State);
            }
        }

        public string EditCustomerName(string CustomerName)
        {
            _CustomerName = CustomerName;

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("The customer's name for this order is currently listed as " + _CustomerName);
            Console.WriteLine("");
            Console.WriteLine("Press return to keep this customer name, or E to change the customer name.");
            string userinput = Console.ReadLine().ToUpper();

            switch (userinput)
            {
                case "E":
                    return GetCustomerName();

                case "":
                    return _CustomerName;

                default:
                    Console.WriteLine("");
                    Console.WriteLine("You entered an incorrect letter, please try again.");
                    Console.WriteLine("Press return to continue...");
                    Console.ReadLine();
                    return EditState(_CustomerName);
            }
        }

        public ProductType GetProductType() //this gets the material type (ProductType) from the customer
                                            //product prices are updated in the list
        {

            ProductFileRepository Prices = new ProductFileRepository();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("******************************************************************************************");
                Console.WriteLine("");
                Console.WriteLine(" C - Carpet, at $" + Prices.GetCostPerSquareFoot(ProductType.Carpet,"Cost").ToString() + " per sqft");
                Console.WriteLine("");
                Console.WriteLine(" L- Laminate, at $" + Prices.GetCostPerSquareFoot(ProductType.Laminate,"Cost").ToString() + " per sqft");
                Console.WriteLine("");
                Console.WriteLine(" T - Tile, at $" + Prices.GetCostPerSquareFoot(ProductType.Tile,"Cost").ToString() + " per sqft");
                Console.WriteLine("");
                Console.WriteLine(" W - Wood, at $" + Prices.GetCostPerSquareFoot(ProductType.Wood,"Cost").ToString() + " per sqft");
                Console.WriteLine("");
                Console.WriteLine("******************************************************************************************");
                Console.WriteLine("");
                Console.Write("Please select the Material Type for the order.  Choose C, L, T, or W: ");

                string userinput = Console.ReadLine().ToUpper();

                switch (userinput)
                {
                    case "C":
                        return ProductType.Carpet;
                    case "L":
                        return ProductType.Laminate;
                    case "T":
                        return ProductType.Tile;
                    case "W":
                        return ProductType.Wood;
                    default:
                        Console.WriteLine("");
                        Console.WriteLine("You entered an incorrect letter, please try again.");
                        Console.WriteLine("Press return to continue...");
                        Console.ReadLine();
                        return GetProductType();
                }
            }
        }

        public string GetState() //This code gets the user state, and checks against tax file via CheckState
        {
            TaxFileRepository StateList = new TaxFileRepository();

            _StateList = StateList.GetStateList();

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Please enter the customer's State as a two charater abbreviation.");
            Console.WriteLine("Choose form the list below:");
            Console.WriteLine(_StateList);

            _State = Console.ReadLine().ToUpper();

            TaxFileRepository Check = new TaxFileRepository();

            if (Check.CheckState(_State))
            {
                return _State;
            }
            else
            {

                Console.WriteLine("");
                Console.WriteLine("This state is not approved for sales.");
                return GetState();
            }
        }

        public decimal GetArea() //This code gets the area input
        {
            Console.Clear();
            Console.WriteLine("");
            Console.Write("Please enter the square surface area (100 sqft minimum) that was ordered:");

            string userinput = Console.ReadLine();

            bool result = decimal.TryParse(userinput, out _Area);

            if (true == result && _Area >= 100)
            {

                return _Area;

            }

            else
            {

                Console.WriteLine("");
                Console.WriteLine("You did not enter a valid number, please try again...");
                return GetArea();
            }

        }

        public string GetCustomerName() //This code gets the customer name, and checks using regex
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Please enter your company name, only entering alphanumeric characters, commas, and periods:");

            _CustomerName = Console.ReadLine();

            if (_CustomerName == "")
            {
                Console.WriteLine("");
                Console.WriteLine("You did not enter a valid company name, please try again...");
                Console.WriteLine("");
                return GetCustomerName();
            }

            Regex rg = new Regex("[^a-zA-Z0-9.,] ");

            if (rg.IsMatch(_CustomerName))
            {
                Console.WriteLine("");
                Console.WriteLine("You entered some invalid charaters, please try again...");
                Console.WriteLine("");
                return GetCustomerName();
            }

            else
            {
                return _CustomerName;
            }
        }

        public string GetDateUni(string input) //The purpose of this is to get the date to either add, edit, delete, or display
        {

            _input = input;

            if (_input == "")
            {
                _date = DateTime.Now.ToString("MMddyyyy");

                return _date;
            }

            else
            {
                DateTime date;

                if (DateTime.TryParse(input, out date))
                {
                    _date = date.ToString("MMddyyyy");

                    return _date;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("You did not enter a correct date, please try again...");
                    Console.WriteLine("");
                    Console.Write("Enter an order date mm/dd/yyyy or press return for today's date: ");
                    string second = Console.ReadLine().ToString();
                    return GetDateUni(second);
                }

            }

        }

        public string GetFutureDate(string Date) //Adding orders must be today or in the future, this enforces futrure date
        {

            _date = Date.Substring(0, 2) + "/" + Date.Substring(2, 2) + "/" + Date.Substring(4, 4);

            DateTime d1 = DateTime.Parse(_date);
            DateTime d2 = DateTime.Parse(DateTime.Now.ToString());

            if (d1.Year >= d2.Year && d1.Month >= d2.Month && d1.Day >= d2.Day)
            {
                return _date;
            }

            else
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("Please enter either today's date or a future date when adding an order.");
                Console.WriteLine("Please try again, enter in MM/DD/YYYY format:");
                string second = Console.ReadLine().ToString();
                return GetFutureDate(second);
            }

        }

        public int GetOrderNumber() //This code gets the Order Number to be deleted or edited.
        {
            Console.Clear();
            Console.WriteLine("");
            Console.Write("Please enter the order number:");

            string userinput = Console.ReadLine();

            bool result = int.TryParse(userinput, out _OrderNumber);

            if (true == result)
            {

                return _OrderNumber;

            }

            else
            {

                Console.WriteLine("");
                Console.WriteLine("You did not enter a valid number, please try again...");
                return GetOrderNumber();
            }

        }

        public void VerifyOrder(Order order)
        {
            Console.Clear();
            
            DisplayOrder(order);

            Console.WriteLine("");
            Console.WriteLine("Please confirm that you want proceed with this order (Y/N):");

            string userinput = Console.ReadLine().ToUpper();

            switch (userinput)
            {
                case "Y":
                    return;
                case "N":
                    Menu.Start();
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("You did not enter Y or N, please try again...");
                    VerifyOrder(order);
                    break;
            }

        }

        public void ConfirmDelete(Order order)
        {
            Console.Clear();

            DisplayOrder(order);

            Console.WriteLine("Please confirm that you want to delete this order (Y/N):");

            string userinput = Console.ReadLine().ToUpper();

            switch (userinput)
            {
                case "Y":
                    return;
                case "N":
                    Menu.Start();
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("You did not enter Y or N, please try again...");
                    VerifyOrder(order);
                    break;
            }
        }
    }

}  
    

