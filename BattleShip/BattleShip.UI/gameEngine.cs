using System;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public class gameEngine
    {
        private gameDisplay _bsDisplay = new gameDisplay();
        private gameInput _bsInput = new gameInput();
        private Board _bsBoard1;
        private Board _bsBoard2;
        private string[] _playerNames = new string[2];
        private bool _gameOver;
        private bool _player1Continue;
    
        public gameEngine()
        {
            
        }

        public void gameStart() //Start the game
        {
            _gameOver = false;
            _player1Continue = true;
        
            displaySplashScreen();  //Intro screen to launch game

            promptPlayerNames();

            buildBoard();

            createShips(); //Creates ships, then places them

            gameCycle();

        }

        private void displaySplashScreen()
        {
            _bsDisplay.displaySplashScreen();
        }


        private void promptPlayerNames() //  Goes to gameInput to get player names, passes Player 1 and 2 and returns their names which are stored in array.
        {
            _playerNames[0] = _bsInput.promptPlayerNames("Player 1");
            _playerNames[1] = _bsInput.promptPlayerNames("Player 2");
        }


        private void buildBoard()  //Instantiates the boards
        {
            _bsBoard1 = new Board();
            _bsBoard2 = new Board();
        }


        private void createShips() //Loop to place ships on boards
        {
            
            for (int j = 0; j < 2; j++) //Player loop
            {

                for (int i = 0; i < 5; i++) //Ship loop
                {
                    
                    if (j==0)
                    {

                    placeShips(_playerNames[j], _bsBoard1, (ShipType)i);

                    }
                    else
                    {

                    placeShips(_playerNames[j], _bsBoard2, (ShipType)i);

                    }

                }

            }

        }

        private void placeShips(string playerName, Board board, ShipType type)
        {
            PlaceShipRequest request = new PlaceShipRequest();

            while (true)
            {
                Console.WriteLine($"{playerName} please place your {Enum.GetName(typeof(ShipType), type)} on your board.");

                Coordinate XY = _bsInput.queryPlayerForCoordinate(playerName);

                ShipDirection orientation = _bsInput.queryPlayerForShipDirection(playerName);

                request.ShipType = type;
                request.Coordinate = XY;
                request.Direction = orientation;

                ShipPlacement attempt = board.PlaceShip(request);

                switch (attempt)
                {
                    case ShipPlacement.Overlap:
                        Console.WriteLine($"{playerName}, another ship already exists in this location");
                        break;

                    case ShipPlacement.NotEnoughSpace:
                        Console.WriteLine($"{playerName}, your ship cannot go beyond the edge of the board");
                        break;

                    case ShipPlacement.Ok:

                        return;

                }

            }
        }

        private void gameCycle()
        { 
            while (!_gameOver)
            {
                           
                if (_player1Continue)
                {
                    _bsDisplay.displayBoard(_bsBoard2);
                    _gameOver = playerLoop(_playerNames[0], _bsBoard2);
                }

                else
                {
                    _bsDisplay.displayBoard(_bsBoard1);
                    _gameOver = playerLoop(_playerNames[1], _bsBoard1);
                }

                _player1Continue = !_player1Continue;

            }
        }


        private bool playerLoop(string playerName, Board board)
        {

            bool _continueLoop = true;

            while (_continueLoop)
            {
                Console.WriteLine($"{playerName}, please enter the coordinates of your shot: ");

                Coordinate XY = _bsInput.queryPlayerForCoordinate(playerName);

                FireShotResponse feedback = board.FireShot(XY);

                    switch (feedback.ShotStatus)
                    {
                        case ShotStatus.Hit:
                            Console.WriteLine("You hit my {0}!  Press any key to continue...", feedback.ShipImpacted);
                            Console.ReadKey();
                            _continueLoop = false;
                            return false;

                        case ShotStatus.Miss:
                            Console.WriteLine("It's a Miss!  Press any key to continue...");
                            Console.ReadKey();
                            _continueLoop = false;
                            return false;

                        case ShotStatus.Duplicate:
                            Console.WriteLine("You already shot here, try again.  Press any key to comtinuw...");
                            Console.ReadKey();
                            break;

                        case ShotStatus.HitAndSunk:
                            Console.WriteLine("You sank my {0}!  Press any key to continue...", feedback.ShipImpacted);
                            Console.ReadKey();
                            _continueLoop = false;
                            return false;

                        case ShotStatus.Victory:
                            Console.WriteLine("You Win!");
                            Console.WriteLine("");
                            Console.WriteLine("To quit the game, enter \"Q\", otherwise press any other key to play the game again:");
                            string temp = (Console.ReadLine().ToUpper());

                            if (temp=="Q")
                            {
                                return true;
                            }

                            else
                            {
                                gameStart();
                                return false;
                            }
                            
                        case ShotStatus.Invalid:
                            Console.WriteLine("You entered an invalid coordinate!  Press any key to continue...");
                            Console.ReadKey();
                            break;
                     }

                }

                return true;
            
          }
      }
 }