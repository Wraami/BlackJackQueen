using BlackJackQueen.Services;

namespace BlackJackQueen.Presentation.Inputs
{
    public class GameActions
    {
        private readonly GameService _gameService;

        public GameActions(GameService gameService)
        {
            _gameService = gameService;
        }

        public void PlayerHits(int handIndex)
        {
            var playerHand = _gameService.GetPlayerHands();
            if (handIndex >= playerHand.Count())
            {
                Console.WriteLine("Invalid hand selection, pick a valid hand");
                return;
            }

            var handToHit = playerHand[handIndex];
            _gameService.Hit(handToHit);
            Console.WriteLine($"Player hit on hand {handIndex + 1}: {handToHit.GetHandDisplay()}");
        }

        public void PlayerStands()
        {
            Console.WriteLine("Player stands");
        }

        public void DealerTurn()
        {
            var dealerHand = _gameService.GetDealerHand();
            int dealerTotalValue = dealerHand.GetTotalValueOfHand();

            if (dealerTotalValue < 17)
            {
                Console.WriteLine("Dealer Hits!");
                _gameService.Hit(dealerHand);
                dealerTotalValue = dealerHand.GetTotalValueOfHand();
            }

            Console.WriteLine("Dealer stands");
        }
    }
}
