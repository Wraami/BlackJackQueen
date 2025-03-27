using BlackJackQueen.Presentation.Inputs;
using BlackJackQueen.Presentation.Output;
using BlackJackQueen.Services;

namespace BlackJackQueen.Presentation
{
    public class MainUI
    {
        private GameService _gameService;
        private PlayerActions _playerActions;
        private DealerActions _dealerActions;
        private DisplayOptions displayOptions;
        //maybe change this to dependency injection if get the time.
        public MainUI()
        {
            _gameService = new GameService();
            displayOptions = new DisplayOptions();
            _playerActions = new PlayerActions(_gameService);
            _dealerActions = new DealerActions(_gameService);
        }

        public void Start()
        {
            SelectExperienceLevel();

            //DEALER NEVER GETS A BREAK >:) 
            _gameService.DealInitialHand();


            foreach (var hand in _gameService.GetPlayerHands())
            {
                bool playerTurn = true;

                while (playerTurn)
                {
                    string input = Console.ReadLine()?.ToUpperInvariant();


                    switch (input)
                    {
                        case "H":
                            _playerActions.PlayerHits(_gameService.GetPlayerHands().IndexOf(hand));
                            if (hand.GetTotalValueOfHand() > 21)
                            {
                                playerTurn = false;
                            }
                            break;

                        case "S":
                            _playerActions.PlayerStands(0);
                            _dealerActions.DealerTurn();  // Let dealer play after player stands.
                            break;

                        case "Q":
                            Console.WriteLine("Quitting this blackjack hand!");
                            playerTurn = false;
                            break;

                        default:
                            Console.WriteLine("Invalid input, please enter H, S, or Q.");
                            continue;
                    }
                }
            }
            _dealerActions.DealerTurn();
        }

        private void SelectExperienceLevel()
        {
            Console.WriteLine("Select your experience you want to use with blackjack:");
            Console.WriteLine("1. Casual Player");
            Console.WriteLine("2. Card Counter");

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "1")
                {
                    DisplayOptions.DisplayStarterOptions();
                    return;
                }
                else if (input == "2")
                {
                    DisplayOptions.DisplayCounterOptions();
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input, put a valid number!");
                }
            }
        }
    }
}
