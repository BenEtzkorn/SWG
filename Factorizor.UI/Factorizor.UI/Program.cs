using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            bool isInValid = true;
            string input;
            int toti;

            do
            {
                Console.Write("What number would you like to factor? ");
                input = Console.ReadLine();

                if (int.TryParse(input, out number))
                {

                    Console.Write("The factors of "+number+" are: ");

                    toti = 0;

                    for (int i=1; i <= number; i++)
                    {
                        if (number % i == 0)
                        {
                            Console.Write(i+" ");
                            toti = toti + i;
                        }                
                    }

                    if (toti-number==number)
                    {
                        Console.WriteLine("\n"+number+" is a perfect number.");
                        Console.WriteLine(number + " is not a prime number.");
                    }
                    else if (toti == number + 1)
                    {
                        Console.WriteLine("\n" + number + " is not a perfect number.");
                        Console.WriteLine(number+" is a prime number.");
                    }
                    else
                    {
                        Console.WriteLine("\n" + number + " is not a perfect number.");
                        Console.WriteLine(number + " is not a prime number.");
                    }

                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("That is not a valid whole number!");
                }
            } while (isInValid);
        }
    }
}
