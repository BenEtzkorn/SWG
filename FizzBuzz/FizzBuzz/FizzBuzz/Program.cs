using System;

namespace FizzBuzz
{
    /*
    In the PrintNumbers() Method below:
    Write a loop that outputs the numbers from 1 to 100 to the console
    If the number is a multiple of 3, print the word “Fizz” next to the number
    If the number is a multiple of 5, print the word “Buzz” next to the number
    If it is both, print “FizzBuzz” next to the number
    */

    class Program
    {
        static void Main(string[] args)
        {
            PrintNumbers();
            Console.ReadLine();
        }

        static void PrintNumbers()
        {
            for (int x = 1; x <= 100; x++)
           {
                if (x % 3 == 0 && x % 5 == 0) Console.WriteLine(x + " FizzBuzz");

                else if (x % 3 == 0) Console.WriteLine(x + " Fizz");

                else if (x % 5 == 0) Console.WriteLine(x + " Buzz");

                else Console.WriteLine(x);
            }
        }
    }
}
