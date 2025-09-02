using BlackJackQueen.Interfaces.Actions;
using BlackJackQueen.Models;
using BlackJackQueen.Presentation.Constants;
using BlackJackQueen.Services;

namespace BlackJackQueen.Presentation.Inputs
{
    public class DealerActions : IDealerActions
    {
        private readonly GameService _gameService;

        public DealerActions(GameService gameService)
        {
            _gameService = gameService;
        }

        public void DealerTurn()
        {
            var dealerHand = _gameService.GetDealerHand();
            int dealerTotalValue = dealerHand.TotalValue;
            Console.WriteLine($"dealer currently has {dealerTotalValue}");
            var playerHands = _gameService.GetPlayerHands();

            while (dealerTotalValue < GameConstants.DealerStandValue)
            {
                Console.WriteLine(UIMessages.DealerHitText);
                _gameService.Hit(dealerHand);
                dealerTotalValue = dealerHand.TotalValue;
                Console.WriteLine($"Dealer now has {dealerTotalValue}");
                Console.WriteLine($"Dealers hand: {dealerHand.GetHandDisplay()}");
            }

            if (dealerTotalValue == GameConstants.DealerStandValue)
            {
                Console.WriteLine(UIMessages.DealerStandText);
                return;
            }

            foreach (var hand in playerHands)
            {
                int playerTotal = hand.TotalValue;
                string gameResult;

                if (playerTotal > GameConstants.Blackjack)
                {
                    gameResult = "Player busts! Dealer wins :/.";
                }
                else if (dealerTotalValue > GameConstants.Blackjack)
                {
                    gameResult = "Dealer busts! Player wins.";
                }
                else if (dealerTotalValue > playerTotal)
                {
                    gameResult = "Dealer wins.";
                }
                else if (dealerTotalValue < playerTotal)
                {
                    gameResult = "Player wins.";
                }
                else
                {
                    gameResult = "Push (tie).";
                }

                Console.WriteLine(gameResult);
            }
        }
    }
}
