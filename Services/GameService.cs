using BlackJackQueen.Models;
using BlackJackQueen.Presentation.Inputs;

namespace BlackJackQueen.Services
{
    public class GameService
    {
        private List<Hand> _playerHands;
        private Hand _dealerHand;
        private readonly DealerActions _gameActions;

        public GameService()
        {
            _playerHands = new List<Hand> { new Hand() };
            _dealerHand = new Hand();
            _gameActions = new DealerActions(this);

        }

        public void DealInitialHand()
        {
            foreach (var hand in _playerHands)
            {
                DealCards(hand, 2);
                Console.WriteLine($"Player Hand: {hand.GetHandDisplay()} (Total: {hand.GetTotalValueOfHand()})");
            }

            DealCards(_dealerHand, 2);
            Console.WriteLine($"Dealer Hand: {_dealerHand.GetHandDisplay()}");
        }

        public void DealCards(Hand hands, int? count)
        {
            for (int i = 0; i < count; i++)
            {
                //TODO: logic, draw a card from a deck / deck in a shoe.

                CardModel drawnCard = new CardModel(Models.Enums.Suit.Hearts, Models.Enums.Rank.Ace);

                hands.AddCard(drawnCard);
            }

        }

        //TODO: actually implement standing and hitting logic in full for differing player and dealer case.
        public void Hit(Hand hand)
        {
            DealCards(hand, 1);
        }

        public void Stand()
        {
            Console.WriteLine("Player stands");
        }

        public List<Hand> GetPlayerHands() => _playerHands;
        public Hand GetDealerHand() => _dealerHand;

        //TODO: reset game state somewhere here in a new method.

    }
}
