using BlackJackQueen.Models;
using BlackJackQueen.Presentation.Parsers;
using BlackJackQueen.Services;
using BlackJackQueen.Presentation.Constants;
using BlackJackQueen.Presentation.Inputs;
using BlackJackQueen.Models.Player;
using BlackJackQueen.Presentation.Output;
using BlackJackQueen.Models.Enums;

namespace BlackJackQueen.Presentation
{
    public class GameController
    {
        private readonly MainUI _ui;
        private readonly GameService _gameService;
        private readonly DealerActions _dealerActions;
        private readonly PlayerActions _playerActions;
        private Player _player;
        //maybe change this to dependency injection if get the time.

        public GameController(MainUI ui)
        {
            _ui = ui;
            _gameService = new GameService();
            _playerActions = new PlayerActions(_gameService);
            _dealerActions = new DealerActions(_gameService);

            _player = _ui.CreatePlayer();
            _ui.InitializePlayerBalance(_player);
        }

        private static void SelectGameExperience()
        {
            Console.WriteLine(UIMessages.ExperienceSelectText);
            DisplayOptions.InsertDisplayDivider();
            Console.WriteLine(UIMessages.PlayerCasualOption);
            Console.WriteLine(UIMessages.PlayerCounterOption);

            string experienceInput = Console.ReadLine();
            PlayerInputParser.ParseExperienceLevel(experienceInput);
        }

        public void Start()
        {
            SelectGameExperience();

            bool playAgain = true;

            while (playAgain)
            {
                StartMessaging();
                _gameService.ResetGame();
                _gameService.DealInitialHand();

                PlayAllHands();
                _dealerActions.DealerTurn();

                Console.WriteLine(UIMessages.PlayAgainPrompt);
                playAgain = PlayerInputParser.ParseContinueGameInput(Console.ReadLine());
            }
        }

        private void StartMessaging()
        {
            DisplayOptions.InsertDisplayDivider();
            Console.WriteLine($"Welcome {_player.PlayerName}, You've started with a balance of: {_player.Balance} chips");
            Console.WriteLine(UIMessages.NewGameText);

            DisplayOptions.InsertDisplayDivider();

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
            if (hand.IsBlackjack)
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
                    if (!hand.CanDouble())
                    {
                        Console.WriteLine(UIMessages.PlayerDoubleError);
                        return false;
                    }

                    _playerActions.PlayerDoubles(_gameService.GetPlayerHands().IndexOf(hand));
                    //TODO: implement a bet service tied to a player so we can start betting monies :)
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
            DisplayOptions.InsertDisplayDivider(1);
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
