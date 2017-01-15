using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        const ConsoleColor Victory_Color = ConsoleColor.Green;
        const ConsoleColor Error_Color = ConsoleColor.Red;
        const ConsoleColor Normal_Color = ConsoleColor.White;
        const ConsoleColor BigWin_Color = ConsoleColor.Magenta;

        private int playerGuess;
        private string playerInput;
        private int theAnswer;
        private int playCount = 1;
        private string playerName;
        private string gameLevel;
        private int ceiling;

        //creates new game object 

        static void Main(string[] args)
        {
            

            Program p = new Program();

            p.run();
        }

        //series of game subroutines to be executed in this order

        public void run()
        {

            GetPlayerName();
            GameDifficulty();
            SetCeiling();
            WinningAnswer();
            GetChoice ();
           
        }

        private void GetPlayerName()
        {
            OutputMessage(Normal_Color, "Welcome to the Guessing Game, please enter your name? ");
            playerName = Console.ReadLine();
        }

        //this prompts user for the difficulty level they wish to play, and loop if bad input!

        private void GameDifficulty()
        {

            gameLevel = "";

            Console.WriteLine("");

            string output1 = string.Format("What Game Mode would you like to play, {0} ?", playerName);

            OutputMessageLine(Normal_Color, output1);

            OutputMessageLine(Normal_Color, "(E)asy:    Guess Numbers between 1 and 5");
            OutputMessageLine(Normal_Color, "(N)asy:    Guess Numbers between 1 and 20");
            OutputMessageLine(Normal_Color, "(H)asy:    Guess Numbers between 1 and 50");

            Console.WriteLine("");

            OutputMessage(Normal_Color, "Enter your choice (E, N, or H): ");

            gameLevel = Console.ReadKey().KeyChar.ToString().ToUpper();

            if (gameLevel != "E" && gameLevel != "N" && gameLevel != "H")

            {
                Console.WriteLine("");

                Console.WriteLine("");

                string output2 = string.Format("Please choose again {0} from the options provided below:", playerName);

                OutputMessageLine(Error_Color, output2);

                GameDifficulty();
            }

        }

        //this converts the input GameLevel string to a numeric ceiling

        private void SetCeiling()
        {
          
            switch (gameLevel)
            {
                case "E":
                    ceiling = 5;
                    break;
                case "N":
                    ceiling = 20;
                    break;
                case "H":
                    ceiling = 50;
                    break;
                default:
                    break;
            }

        }

        //note that this assigns the winning answer which is randomly generated

        private void WinningAnswer()
        {
            
            theAnswer = new Random().Next(1, ceiling + 1);

        }

        //get the player's input, determine if it is a win or not, and process next steps

        private void GetChoice()

        {
            bool quitGame = false;

            bool guessInvalid = true;

            do 

            { 
                Console.WriteLine("");

                Console.WriteLine("");

                string output3 = string.Format("{0}, please enter your guess between 1 and {1}, or 'Q' to exit the game. ", playerName, ceiling);

                OutputMessage(Normal_Color, output3);

                playerInput = Console.ReadLine().ToString().ToUpper();

                if (playerInput=="Q")
                {
                    quitGame = true;
                }

                else if (int.TryParse(playerInput, out playerGuess))
                {

                    guessInvalid = false; 
                   
                }

                else
                {

                    Console.WriteLine("");

                    Console.WriteLine("");

                    string output4 = string.Format("{0}, that was not a valid entry, please try again.", playerName);

                    OutputMessageLine(Error_Color, output4);

                } 

            } while (quitGame == false && guessInvalid == true) ;

            if (quitGame == true)
            {
                EndGame();
            }

            else if (playerGuess == theAnswer && playCount == 1)
            {
                ProcessBigWin();
            }

            else if (playerGuess == theAnswer)
            {
                ProcessWin();
            }

            else
            {
                ProcessMiss();
            }
        }

        //If a missed guess, process this subroutine

        private void ProcessMiss()
        {

            Console.WriteLine("");

            Console.WriteLine("");

            if (playerGuess < 1 || playerGuess > ceiling)
            {
                string output5 = string.Format("{0}, your number must be between 1 and {1}.", playerName, ceiling);

                OutputMessageLine(Error_Color,output5);
            }

            else if (playerGuess > theAnswer)
            {

                string output6 = string.Format("{0}, your number is too high, please guess again.", playerName);

                OutputMessageLine(Error_Color, output6);

                playCount++;
            }

            else
            {

                string output7 = string.Format("{0}, your number is too low, please guess again.", playerName);

                OutputMessageLine(Error_Color, output7);

                playCount++;
            }

            GetChoice();

        }

        //for special case where player wins on first try, we rock with Prince Purple!
        //give player the option to quit or to play again.

        private void ProcessBigWin()

        {

            Console.WriteLine("");

            Console.WriteLine("");

            string output8 = string.Format("{0}, like Prince you Rock with a win on your first try!", playerName);

            OutputMessageLine(BigWin_Color, output8);

            Console.WriteLine("");

            string output9 = string.Format("Press \"P\" to play again or any other key to exit. ");

            OutputMessageLine(BigWin_Color, output9);

            if (Console.ReadKey().KeyChar.ToString().ToUpper() == "P")
            {
            
                ResetGame();

            }

        }

        //for a normal win, process this subroutine.  Give player option to quit or play again.

        private void ProcessWin()
        {

            Console.WriteLine("");

            Console.WriteLine("");

            string output9 = string.Format("{0}, you win!  And it took you {1} attempts. ", playerName,playCount);

            OutputMessageLine(Victory_Color, output9);

            Console.WriteLine("");

            string output11 = string.Format("Press \"P\" to play again or any other key to exit. ");

            OutputMessageLine(Victory_Color, output11);
            
            if (Console.ReadKey().KeyChar.ToString().ToUpper() == "P")
            {

                ResetGame();

            }

            else EndGame();

        }

        //if player chooses to play again, run this subroutine

        private void ResetGame()
        {

            Console.Clear();
            playCount = 1;
            GameDifficulty();
            SetCeiling();
            WinningAnswer();
            GetChoice();

        }

        private void EndGame()
        {
            
        }

        private void OutputMessage(ConsoleColor fgColor, string formatString, params object[] writeparameters)
        {

            Console.ForegroundColor = fgColor;
            Console.Write(formatString);
            Console.ResetColor();

        }

        private void OutputMessageLine(ConsoleColor fgColor, string formatString, params object[] writeparameters)
        {

            Console.ForegroundColor = fgColor;
            Console.WriteLine(formatString);
            Console.ResetColor();

        }

    }

}
