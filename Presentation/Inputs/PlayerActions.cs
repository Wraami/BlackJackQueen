using BlackJackQueen.Interfaces.Actions;
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
                Console.WriteLine("Invalid hand selection, pick a valid hand");
                return;
            }

            var handToHit = playerHand[handIndex];
            _gameService.Hit(handToHit);
            Console.WriteLine($"Player hit on hand {handIndex + 1}: {handToHit.GetHandDisplay()}");
        }

        public void PlayerStands(int handIndex)
        {
            _gameService.Stand();
        }
    }
}
