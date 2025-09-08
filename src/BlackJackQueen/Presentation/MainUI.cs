using BlackJackQueen.Models;
using BlackJackQueen.Models.Enums;
using BlackJackQueen.Presentation.Constants;
using BlackJackQueen.Presentation.Inputs;
using BlackJackQueen.Presentation.Output;
using BlackJackQueen.Presentation.Parsers;
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
            Console.WriteLine(UIMessages.ExperienceSelectText);
            Console.WriteLine("1 - Casual Player");
            Console.WriteLine("2 - Card Counter");

            string experienceInput = Console.ReadLine();
            PlayerInputParser.ParseExperienceLevel(experienceInput);

            //Do a prompt here for new game, vs just accessing settings, so they can configure beyond defaults if they'd like.
            Console.WriteLine(UIMessages.NewGameText);
            //DEALER NEVER GETS A BREAK >:) 
            _gameService.DealInitialHand();

            var playerHands = _gameService.GetPlayerHands().ToList();

            foreach (var hand in playerHands)
            {
                bool playerTurn = true;
                bool isFirstTurn = true;
                while (playerTurn)
                {
                    DisplayPlayerTurnPrompt(hand, isFirstTurn);

                    string input = Console.ReadLine()?.ToUpperInvariant();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine(UIMessages.InvalidInputText);
                        continue;
                    }

                    var action = PlayerInputParser.ParseGameInputs(input);

                    switch (action)
                    {
                        case PlayerInputType.Hit:
                            _playerActions.PlayerHits(_gameService.GetPlayerHands().IndexOf(hand));
                            if (hand.IsBust)
                            {
                                Console.WriteLine(UIMessages.BustMessageText);
                                playerTurn = false;
                                _gameService.ResetGame();
                            }
                            break;

                        case PlayerInputType.Double:
                            //TODO: validation if the player can actually double their hand or not

                            break;

                        case PlayerInputType.Split:
                            if (!hand.CanSplit())
                            {
                                Console.WriteLine(UIMessages.PlayerSplitError);
                                continue;
                            }
                            _gameService.SplitHand(hand);
                            break;

                        case PlayerInputType.Stand:
                            //TODO: implement standing by specified index of hand
                            _playerActions.PlayerStands(0);
                            // Let dealer play after player stands (we should probably have a tracker for the gamestate so we can early terminate and not even need to access this method, maybe by just checking totals if the dealers already bust).
                            _dealerActions.DealerTurn();
                            break;

                        case PlayerInputType.Quit:
                            Console.WriteLine(UIMessages.QuitText);
                            _gameService.ResetGame();
                            playerTurn = false;
                            break;

                        case PlayerInputType.ViewRules:
                            Console.WriteLine("TODO: RULES RENDERING");
                            break;

                        case PlayerInputType.Settings:
                            Console.WriteLine("TODO: Settings");
                            //TableRules here.
                            break;

                        default:
                            Console.WriteLine(UIMessages.InvalidInputText);
                            continue;
                    }
                    isFirstTurn = false;
                }
            }

        }

        private static void DisplayPlayerTurnPrompt(Hand hand, bool isFirstTurn)
        {
            if (isFirstTurn)
            {
                Console.WriteLine(UIMessages.PlayerFirstTurnPrompt);
            }

            else
            {
                Console.WriteLine(UIMessages.PlayerInputPrompt);
            }

            //TODO: refactor this so we doesn't need to check every iteration.
            if (hand.CanSplit())
            {
                Console.WriteLine(UIMessages.PlayerSplitPrompt);
            }
        }

    }
}
