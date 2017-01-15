using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {

        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();
            //Exercise1(); //done
            //Exercise2(); //done
            //Exercise3(); //done
            //Exercise4(); //done
            //Exercise5(); //done
            //Exercise6(); //done
            //Exercise7(); //done
            //Exercise8(); //done
            //Exercise9(); //done
            //Exercise10(); //done
            //Exercise11(); //done
            //Exercise12(); //done
            //Exercise13(); //done
            //Exercise14(); //done
            //Exercise15(); //done
            //Exercise16(); //done
            //Exercise17(); //done
            //Exercise18(); //done
            //Exercise19(); //done
            //Exercise20(); //done
            //Exercise21(); //done
            //Exercise22(); //done
            //Exercise23(); //done
            //Exercise24(); //done
            //Exercise25(); //done
            //Exercise26(); //done
            //Exercise27(); //done
            //Exercise28(); //done
            //Exercise29(); //done
            //Exercise30(); //done
            //Exercise31(); //done

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            List<Product> products = DataLoader.LoadProducts();

            var outofstock = products.Where(s => s.UnitsInStock == 0);

            Console.WriteLine("Products that are out of stock:");
            Console.WriteLine();
            string line = "{0,-5} {1,-35} {2,-15} {3,7:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in outofstock)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            List<Product> products = DataLoader.LoadProducts();

            var outofstock = products.Where(c => c.UnitPrice > 3);

            Console.WriteLine("Products in stiock that cost more than $3/unit:");
            Console.WriteLine();

            string line = "{0,-5} {1,-35} {2,-15} {3,7:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (Product product in outofstock)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {

            var customers = DataLoader.LoadCustomers();

            var wac = customers.Where(r => r.Region == "WA");

            foreach (Customer customer in wac.ToList())
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (Order order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            var products = DataLoader.LoadProducts();

            var wac = from product in products
                      orderby product.ProductName
                      select new
                      {
                          productName = product.ProductName
                      };
            foreach (var item in wac)
            {
                Console.WriteLine(item.productName);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            //This is much easier, but I'll build the anonymous type

            /* List<Product> products = DataLoader.LoadProducts();

             string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
             Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
             Console.WriteLine("==============================================================================");

             foreach (Product product in products)
             {
                 Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                     product.UnitPrice*1.25m, product.UnitsInStock);
             } */

            var products = DataLoader.LoadProducts();

            var unitUp = from product in products
                      select new
                      {
                          productID = product.ProductID,
                          productName = product.ProductName,
                          category = product.Category,
                          unitPrice = product.UnitPrice*1.25m,
                          unitsInStock = product.UnitsInStock
                      };

            string line = "{0,-5} {1,-35} {2,-15} {3,7:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var item in unitUp)
            {
                Console.WriteLine(line, item.productID, item.productName, item.category,
                    item.unitPrice, item.unitsInStock);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {

            var products = DataLoader.LoadProducts();

            var unitUp = from product in products

                         orderby product.ProductName

                         select new
                         {
                             productName = product.ProductName.ToUpper(),
                             category = product.Category.ToUpper(),
                         };

            string line = "{0,-35} {1,-15}";
            Console.WriteLine(line, "Product Name", "Category");
            Console.WriteLine("================================================================");

            foreach (var item in unitUp)
            {
                Console.WriteLine(line, item.productName, item.category);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            var products = DataLoader.LoadProducts();

            var unitUp = from product in products
                         select new
                         {
                             productID = product.ProductID,
                             productName = product.ProductName,
                             category = product.Category,
                             unitPrice = product.UnitPrice,
                             unitsInStock = product.UnitsInStock,
                             reOrder = ((product.UnitsInStock < 3) ? true : false)
                         };

            string line = "{0,-5} {1,-35} {2,-15} {3,7:c} {4,6} {5,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "ReOrder");
            Console.WriteLine("===================================================================================");

            foreach (var item in unitUp)
            {
                Console.WriteLine(line, item.productID, item.productName, item.category,
                    item.unitPrice, item.unitsInStock, item.reOrder);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            var products = DataLoader.LoadProducts();

            var unitUp = from product in products
                         select new
                         {
                             productID = product.ProductID,
                             productName = product.ProductName,
                             category = product.Category,
                             unitPrice = product.UnitPrice,
                             unitsInStock = product.UnitsInStock,
                             StockValue = string.Format("{0:C}", product.UnitsInStock * product.UnitPrice)
                         };

            string line = "{0,-5} {1,-35} {2,-15} {3,7:c} {4,6} {5,11}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "StockValue");
            Console.WriteLine("==========================================================================================");

            foreach (var item in unitUp)
            {
                Console.WriteLine(line, item.productID, item.productName, item.category,
                    item.unitPrice, item.unitsInStock, item.StockValue);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {

            var onlyEven = (from i in DataLoader.NumbersA
                            orderby i ascending
                            where i % 2 == 0
                            select i);

            Console.WriteLine("Only even numbers in A");
            Console.WriteLine();

            foreach (var x in onlyEven)
            {
                Console.WriteLine(x);
            }


            //Console.WriteLine(numbers);
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {

            var customers = DataLoader.LoadCustomers();

            var orders =
                from customer in customers
                orderby customer
                from order in customer.Orders
                where order.Total < 500.00M
                select new { customer.CustomerID, order.OrderID, order.Total };

            Console.WriteLine("Customers with total orders less than $500:");
            Console.WriteLine();

            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer.CompanyName);
                
            }
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var firstThreeOdd = (from i in DataLoader.NumbersC
                            where i % 2 == 1
                            select i).Take(3);

            Console.WriteLine("First three odd numbers form C:");
            Console.WriteLine();

            foreach (var x in firstThreeOdd)
            {
                Console.WriteLine(x);
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var firstThreeOdd = (from i in DataLoader.NumbersB
                                 select i).Skip(3);

            Console.WriteLine("Number from B except first three:");
            Console.WriteLine();

            foreach (var x in firstThreeOdd)
            {
                Console.WriteLine(x);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {

            var customers = DataLoader.LoadCustomers();

            var wac = customers.Where(r => r.Region == "WA");

            var lastOne =
                from product in wac
                orderby product.CompanyName descending
                select new { Name = product.CompanyName, lastOrder = product.Orders.OrderBy(o => o.OrderDate).Last() };

            string line = "{0,-25} {1,-15}";
            Console.WriteLine("=====================================================");
            Console.WriteLine(line, "Company Name", "Last Order");

            foreach (var product in lastOne )
            {

                Console.WriteLine(line, product.Name, product.lastOrder);

            }

        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var cSet = DataLoader.NumbersC;

            var upToSix = cSet.TakeWhile(n => n < 6);

            Console.WriteLine("Print all the numbers in NumbersC until a number is >= 6");
            Console.WriteLine();

            foreach (var x in upToSix)
            {
                Console.WriteLine(x);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            var cSet = DataLoader.NumbersC;

            var afterDivByThree = cSet.SkipWhile(n => n % 3 != 0);

            var skipFirstIfThree = afterDivByThree.SkipWhile(n => n == 3);

            Console.WriteLine("Print all the numbers in NumbersC that come after the first number divisible by 3");
            Console.WriteLine();

            foreach (var x in skipFirstIfThree)
            {
                Console.WriteLine(x);
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            var products = DataLoader.LoadProducts();

            var listOfProd =
                from product in products
                orderby product.ProductName
                select product.ProductName;

            Console.WriteLine("Products in alphabetical order:");
            Console.WriteLine();

            foreach (var x in listOfProd)
            {
                Console.WriteLine(x);
            }

        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {

            var products = DataLoader.LoadProducts();

            var prodSortByStock =
                from product in products
                orderby product.UnitsInStock descending
                select new { prodName=product.ProductName, prodUnit = product.UnitsInStock };

            string line = "{0,-35} {1,-6}";
            Console.WriteLine(line, "Product Name", "Stock");
            Console.WriteLine("=======================================================");

            foreach (var product in prodSortByStock)
            {
                Console.WriteLine("{0,-35}{1,-6}",product.prodName,product.prodUnit);
            }
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            var products = DataLoader.LoadProducts();

            var prodCat =
                from product in products
                orderby product.UnitPrice descending
                orderby product.Category ascending
                group product by product.Category;

            foreach (var category in prodCat)
            {
                Console.WriteLine(category.Key);

                foreach (var price in category)
                {
                    Console.WriteLine("Unit Price {0:c}", price.UnitPrice);
                }
            }
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            var reverseIt = (from i in DataLoader.NumbersB
                             select i).Reverse();

            Console.WriteLine("Print Numbers B in reverse order:");
            Console.WriteLine("");

            foreach (var x in reverseIt)
            {
                Console.WriteLine(x);
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            var products = DataLoader.LoadProducts();

            var prodCat =
                from product in products
                orderby product.Category ascending
                group product by product.Category;

            foreach (var category in prodCat)
            {
                Console.WriteLine(category.Key);

                foreach (var product in category)
                {
                    Console.WriteLine("{0}", product.ProductName);
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
            Console.WriteLine("All Customers and their Order by Year and Month - Using LINQ Methods:");

            foreach (Customer c in DataLoader.LoadCustomers())
            {
                Console.WriteLine();
                Console.WriteLine($"Customer: {c.CompanyName}");

                foreach (var ordersForYear in c.Orders.GroupBy(o => o.OrderDate.Year).OrderBy(g => g.Key))
                {
                    Console.WriteLine($"   Year:  {ordersForYear.Key}");

                    foreach (var ordersForMonthOfYear in ordersForYear.GroupBy(o => o.OrderDate.Month).OrderBy(g => g.Key))

                    {
                        Console.WriteLine($"   Month:  {ordersForMonthOfYear.First().OrderDate:MMMM}");
                        
                        foreach (var x in ordersForMonthOfYear)
                        {
                            
                            Console.WriteLine("       {0}",x.OrderID);
                        }
                    }
                }

            }
        }

        /// <summary>
    /// Print the unique list of product categories
    /// </summary>
        static void Exercise22()
        {
            var products = DataLoader.LoadProducts();

            var prodCat =
                from product in products
                orderby product.Category
                group product by product.Category;

            Console.WriteLine("Unique product categories:");
            Console.WriteLine();

            foreach (var category in prodCat)
            {
                Console.WriteLine(category.Key);
            }

        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            var products = DataLoader.LoadProducts();

            var prod789 = products.FirstOrDefault(p => p.ProductID == 789);

           if(prod789 != null)
            {
                Console.WriteLine("Product 789 exists");
            }
           else
            {
                Console.WriteLine("Product 789 does not exist");
            }
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {

            var products = DataLoader.LoadProducts();

            var soldOutProductCat =
                from prod in products
                where prod.UnitsInStock == 0
                group prod by prod.Category into categories
                orderby categories.Key
                select categories.Key;

            Console.WriteLine("Categories with a sold out product:");
            Console.WriteLine();

            foreach (var product in soldOutProductCat)
            {

                Console.WriteLine(product);
            }
        }


        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {

            var products = DataLoader.LoadProducts();

            var categoriesGroups =
                from product in products
                group product by product.Category into categoryGroup
                where categoryGroup.All(p => p.UnitsInStock > 0)
                orderby categoryGroup.Key descending
                //select new { cat = categoryGroup.Key };
                select categoryGroup.Key;

            foreach ( var categoryGroup in categoriesGroups)
                    {
                         Console.WriteLine("{0}",categoryGroup);
                     }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            int oddCount = DataLoader.NumbersA.Count(n => (n & 1) == 1);
            Console.WriteLine($"The number of odd numbers in Numbers A is: {oddCount}");
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            var customers = DataLoader.LoadCustomers();

            var orderCounts =
                from cust in customers
                select new { cust.CustomerID , amount=cust.Orders.Count() };

            string line = "{0,-25} {1,-6}";
            Console.WriteLine(line, "Customer ID", "# of Orders");
            Console.WriteLine("=====================================================");

            foreach (var customer in orderCounts)
                
            {
                
                Console.WriteLine(line, customer.CustomerID, customer.amount);
                
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {

            var products = DataLoader.LoadProducts();

            var prodCat =
            from prod in products
            orderby prod.Category ascending
            group prod by prod.Category into prodGroup
            select new { Category = prodGroup.Key, TotalUnitsInStock = prodGroup.Count()};


            string line = "{0,-35} {1,-5}";
            Console.WriteLine(line, "Category", "Units");
            Console.WriteLine("===================================================");

            foreach (var prodGroup in prodCat)

            {
                Console.WriteLine(line, prodGroup.Category, prodGroup.TotalUnitsInStock);
            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            var products = DataLoader.LoadProducts();

            var prodCat =
            from prod in products
            orderby prod.Category ascending
            group prod by prod.Category into prodGroup
            select new { Category = prodGroup.Key, TotalUnitsInStock = prodGroup.Sum(p => p.UnitsInStock) };


            string line = "{0,-35} {1,-5}";
            Console.WriteLine(line, "Category", "Units");
            Console.WriteLine("===================================================");

            foreach (var prodGroup in prodCat)

            {
                Console.WriteLine(line, prodGroup.Category, prodGroup.TotalUnitsInStock);
            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            var products = DataLoader.LoadProducts();

            var prodCat =
            from prod in products
            orderby prod.Category ascending
            group prod by prod.Category into prodGroup
            select new { Category = prodGroup.Key, TotalUnitsInStock = prodGroup.Min(p => p.UnitPrice) };
            
            string line = "{0,-35} {1,-5}";
            Console.WriteLine(line, "Category", "Units");
            Console.WriteLine("===================================================");

            foreach (var prodGroup in prodCat)
                
            {
                Console.WriteLine(line, prodGroup.Category, prodGroup.TotalUnitsInStock);
            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            var products = DataLoader.LoadProducts();

            var prodCat = 
            from prod in products
            orderby prod.ProductName ascending
            group prod by prod.ProductName into prodGroup
            orderby prodGroup.Key
            select new { Category = prodGroup.Key, avgUnitPrice = prodGroup.Average(p => p.UnitPrice) };

            var highThree = (
                from cat in prodCat
                orderby cat.avgUnitPrice
                select new {cat.Category,cat.avgUnitPrice}
                ).Take(3);


            string line = "{0,-35} {1,-5}";
            Console.WriteLine(line, "Category", "Avg Unit Price");
            Console.WriteLine("===================================================");

            foreach (var cat in highThree)

            {
                Console.WriteLine(line, cat.Category, cat.avgUnitPrice);
            }
        }        
    }
}
