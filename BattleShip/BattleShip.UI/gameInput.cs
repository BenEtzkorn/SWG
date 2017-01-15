using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;

namespace BattleShip.UI
{
    public class gameInput

    {
        public string Player;

        public string promptPlayerNames(string Player)
        {

            string tempName;

            do
            {

                Console.Write("{0} - Please enter your name: ", Player);
                tempName = Console.ReadLine();
                Console.WriteLine("");

                if (!string.IsNullOrEmpty(tempName)) //if name is enterd then return string
                {
                    return tempName;
                }

                else  //if nothing is entered then ask for real name
                {
                    Console.WriteLine("Please enter a real player name...Press any key to continue: ");
                    Console.WriteLine("");
                }

            } while (true);

        }

        public Coordinate queryPlayerForCoordinate(string playerName)
        {

            //using dictionary object to convert string iut to an int.
            Dictionary<string, int> xValue = new Dictionary<string, int>() { { "A", 1 }, { "B", 2 }, { "C", 3 }, { "D", 4 }, { "E", 5 }, { "F", 6 }, { "G", 7 }, { "H", 8 }, { "I", 9 }, { "J", 10 } };

            while(true)
            {
                Console.WriteLine($"{playerName}, enter your X Coordinate, letters A through J (left to right): ");
                string temp = (Console.ReadLine().ToUpper());

                if(temp=="A"||temp=="B"||temp=="C"||temp=="D"||temp=="E"||temp=="F"||temp=="G"||temp=="H"||temp=="I"||temp=="J")  //Makes sure input is a viable letter.
                {

                int x = xValue[temp];  //Converts my string input to an integer.

                    while (true)
                    {
                        Console.WriteLine("Enter your Y Coordinate, numbers 1 through 10 (top to bottom): ");
                        int y = int.Parse(Console.ReadLine());

                        if (y > 0 && y < 11)
                        {
                            return new Coordinate(x, y);
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You did not enter a number between 1 and 10, please try again:");
                            Console.WriteLine("");
                        }
                    }
                
                }

                else
                {

                Console.WriteLine("You did not enter a charater between the letter \"A\" and \"J\", please try again:");
                 
                }
            }

        }


        public void promptforShipPlacement()
        {
            throw new NotImplementedException();
        }

        public ShipDirection queryPlayerForShipDirection(string playerName)
        {
            while(true)
            {
                Console.WriteLine("{0}, please choose the direction of your ship.  Enter either U, D, L or R)",playerName);

                switch(Console.ReadLine().ToUpper())
                {
                    case "U":
                        return ShipDirection.Up;

                    case "D":
                        return ShipDirection.Down;

                    case "L":
                        return ShipDirection.Left;

                    case "R":
                        return ShipDirection.Right;

                    default:
                        Console.WriteLine("{0}, that was not a valid input, please try again.  Press any key to contiunue.",playerName);
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
            
       

