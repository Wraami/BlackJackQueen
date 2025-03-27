using BlackJackQueen.Interfaces.Actions;
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
