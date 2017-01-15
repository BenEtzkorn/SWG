using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BattleShip.UI
{
    public class gameDisplay
    {

        public void displaySplashScreen()  //Launch the program welcome screen
        {

            Console.WriteLine("Welcome to Battleship!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine("");
        }

        public void displayBoard(Board bsBoard)
        {
            Console.WriteLine("    A    B    C    D    E    F    G    H    I    J");
                       
            for (int row = 1; row < 11; row++)
            {
                if(row==10) //Adjust for two character space for 10
                {
                    Console.Write(row);
                }
                else
                {
                    Console.Write($" {row}");
                }
                

                for (int col = 1; col <11; col++)
                {
                    Coordinate XY = new Coordinate(col, row);

                    if(bsBoard.ShotHistory.ContainsKey(XY))
                    {
                        ShotHistory outcome = bsBoard.ShotHistory[XY];
                        switch(outcome)
                        {
                            case ShotHistory.Hit:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("  H  ");
                                Console.ResetColor();
                                break;
                            case ShotHistory.Miss:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("  M  ");
                                Console.ResetColor();
                                break;   
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("  X  ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
        }

        public void displayShotHistory()
        {

        }
    }
}
