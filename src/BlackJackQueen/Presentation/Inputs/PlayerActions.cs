using BlackJackQueen.Interfaces.Actions;
using BlackJackQueen.Presentation.Constants;
using BlackJackQueen.Services;

namespace BlackJackQueen.Presentation.Inputs
{
    public class PlayerActions : IPlayerActions
    {
        private readonly GameService _gameService;

        public PlayerActions(GameService gameService)
        {
            _gameService = gameService;
        }

        public void PlayerHits(int handIndex)
        {
            var playerHand = _gameService.GetPlayerHands();
            if (handIndex >= playerHand.Count())
            {
                Console.WriteLine(UIMessages.InvalidHandSelectionMessage);
                return;
            }

            var handToHit = playerHand[handIndex];
            Console.WriteLine($"Player hit on hand {handIndex + 1}: Currently hand shows: ({handToHit.GetHandDisplay()})");
            _gameService.Hit(handToHit);
            Console.WriteLine($"New player Hand: {handToHit.GetHandDisplay()} (Total: {handToHit.TotalValue})");
        }

        public void PlayerDoubles(int handIndex)
        {
            var playerHand = _gameService.GetPlayerHands();
            var handToDouble = playerHand[handIndex];

            //TODO: add a betting service to implement a balance to bet :)
            _gameService.Hit(handToDouble);
            Console.WriteLine($"Player doubled on hand {handIndex + 1}: Currently hand shows: ({handToDouble.GetHandDisplay()})");
            Console.WriteLine($"New player Hand: {handToDouble.GetHandDisplay()} (Total: {handToDouble.TotalValue})");
            _gameService.Stand(handToDouble);
        }

        public void PlayerStands(int handIndex)
        {
            _gameService.Stand();
        }
    }
}
