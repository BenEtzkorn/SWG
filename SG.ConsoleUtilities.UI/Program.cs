using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.ConsoleUtilities.BLL;


namespace SG.ConsoleUtilities.UI
{
    class Program
    {
        static void Main(string[] args)
        {
           UserInput ui = new UserInput();
            {
                int age = UserInput.GetIntFromUser("Enter your age.");

                int num = UserInput.GetIntFromUser("Enter your favorite number.");

                Console.WriteLine("Your age is {0} and favoriter number is {1}.", age, num);

                {

                }
            }
        }
    }
}
