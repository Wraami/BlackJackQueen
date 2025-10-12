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
            Console.WriteLine($"dealer shows: {dealerTotalValue}");
            var playerHands = _gameService.GetPlayerHands();

            while (dealerTotalValue < GameConstants.DealerStandValue)
            {
                Console.WriteLine(UIMessages.DealerHitText);
                _gameService.Hit(dealerHand);
                dealerTotalValue = dealerHand.TotalValue;
                Console.WriteLine($"Dealer now has a total of: {dealerTotalValue}");
                Console.WriteLine($"Dealers hand: {dealerHand.GetHandDisplay()}");
            }

            Console.WriteLine(UIMessages.DealerStandText);

            foreach (var hand in playerHands)
            {
                string gameResult = DetermineRoundOutcome(hand, dealerTotalValue);
                Console.WriteLine(gameResult);
            }
        }

        private string DetermineRoundOutcome(Hand hand, int dealerTotalValue)
        {
            int playerTotal = hand.TotalValue;

            if (playerTotal > GameConstants.Blackjack)
            {
                return "Player busts! Dealer wins :/.";
            }

            else if (dealerTotalValue > GameConstants.Blackjack)
            {
                return "Dealer busts! Player wins.";
            }

            else if (dealerTotalValue > playerTotal)
            {
                return "Dealer wins.";
            }

            else if (dealerTotalValue < playerTotal)
            {
                return "Player wins.";
            }

            else
            {
                return "Push (tie).";
            }
        }
    }
}
