using BlackJackQueen.Models;
using BlackJackQueen.Presentation.Inputs;

namespace BlackJackQueen.Services
{
    public class GameService
    {
        private List<Hand> _playerHands;
        private Hand _dealerHand;
        private readonly GameActions _gameActions;

        public GameService()
        {
            _playerHands = new List<Hand>();
            _dealerHand = new Hand();
            _gameActions = new GameActions(this);

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

        public void DealInitialHand()
        {
            foreach (var hand in _playerHands)
            {
                DealCards(hand, 2);

            }
            DealCards(_dealerHand, 2);
        }

        //TODO: actually implement standing and hitting logic in full for differing player and dealer case.
        public void Hit(Hand hand)
        {
            DealCards(hand, 1);
        }

        public List<Hand> GetPlayerHands() => _playerHands;
        public Hand GetDealerHand() => _dealerHand;

    }
}
