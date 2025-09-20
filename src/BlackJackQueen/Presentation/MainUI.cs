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
            SelectGameExperience();
            //TODO: Do a prompt here for new game, vs just accessing settings, so they can configure beyond defaults if they'd like.
            //DEALER NEVER GETS A BREAK >:)
            Console.WriteLine(UIMessages.NewGameText);

            _gameService.DealInitialHand();
            PlayAllHands();

            _dealerActions.DealerTurn();
            _gameService.ResetGame();
        }

        private static void SelectGameExperience()
        {
            Console.WriteLine(UIMessages.ExperienceSelectText);
            Console.WriteLine("1 - Casual Player");
            Console.WriteLine("2 - Card Counter");

            string experienceInput = Console.ReadLine();
            PlayerInputParser.ParseExperienceLevel(experienceInput);
        }

        private void PlayAllHands()
        {
            var playerHands = _gameService.GetPlayerHands().ToList();

            foreach (var hand in playerHands)
            {
                PlayHand(hand);
            }
        }

        private void PlayHand(Hand hand)
        {
            if (IsHandNaturalBlackjack(hand))
            {
                Console.WriteLine(UIMessages.BlackjackText);
                return;
            }

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
                playerTurn = HandlePlayerAction(input, hand);
                isFirstTurn = false;
            }
        }

        private bool HandlePlayerAction(string input, Hand hand)
        {
            var action = PlayerInputParser.ParseGameInputs(input);

            switch (action)
            {
                case PlayerInputType.Hit:
                    _playerActions.PlayerHits(_gameService.GetPlayerHands().IndexOf(hand));
                    if (hand.IsBust)
                    {
                        Console.WriteLine(UIMessages.BustMessageText);
                        return false;
                    }

                    return true;

                case PlayerInputType.Double:
                    //TODO: validation if the player can actually double their hand or not
                    return false;

                case PlayerInputType.Split:
                    if (!hand.CanSplit())
                    {
                        Console.WriteLine(UIMessages.PlayerSplitError);
                        return true;
                    }

                    _gameService.SplitHand(hand);

                    return true;

                case PlayerInputType.Stand:
                    _playerActions.PlayerStands(_gameService.GetPlayerHands().IndexOf(hand));
                    return false;

                case PlayerInputType.Quit:
                    Console.WriteLine(UIMessages.QuitText);
                    return false;


                case PlayerInputType.ViewRules:
                    Console.WriteLine("TODO: RULES RENDERING");
                    return true;

                case PlayerInputType.Settings:
                    Console.WriteLine("TODO: Settings");
                    //TableRules here.
                    return true;

                default:
                    Console.WriteLine(UIMessages.InvalidInputText);
                    return true;
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

        private static bool IsHandNaturalBlackjack(Hand hand)
        {
            return hand.IsBlackjack;
        }
    }
}
