using BlackJackQueen.Presentation.Output;
using BlackJackQueen.Services;

namespace BlackJackQueen.Presentation
{
    public class MainUI
    {
        private GameService _gameService;
        private DisplayOptions displayOptions;
        //maybe change this to dependency injection if get the time.
        public MainUI()
        {
            _gameService = new GameService();
            displayOptions = new DisplayOptions();
        }

        public void Start()
        {
            SelectExperienceLevel();

            _gameService.DealInitialHand();
            displayOptions.ShowGameState();

            //DEALER NEVER GETS A BREAK >:) 
            bool gameRunning = true;

            string input = Console.ReadLine()?.ToUpperInvariant();

            while (gameRunning)
            {

                if (input == "H")
                {
                    //if (_gameService.GetPlayerHandCount().Count == 1)
                    //{
                    //    _gameService.PlayerHits();
                    //}
                }
                else if (input == "S")
                {

                }
                else if (input == "Q")
                {
                    Console.WriteLine("Quitting this blackjack hand!");
                }
            }
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
