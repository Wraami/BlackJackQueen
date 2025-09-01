using BlackJackQueen.Models;
using BlackJackQueen.Presentation.Constants;
using BlackJackQueen.Presentation.Inputs;

namespace BlackJackQueen.Services
{
    public class GameService
    {
        private List<Hand> _playerHands;
        private Hand _dealerHand;
        private readonly DealerActions _gameActions;
        private readonly Deck _deck;

        public GameService()
        {
            _playerHands = new List<Hand> { new Hand() };
            _dealerHand = new Hand();
            _gameActions = new DealerActions(this);
            _deck = new Deck();
        }

        public void DealInitialHand()
        {
            foreach (var hand in _playerHands)
            {
                DealCards(hand, 2);
                Console.WriteLine($"Player Hand: {hand.GetHandDisplay()} (Total: {hand.GetTotalValueOfHand().Total})");
            }

            DealCards(_dealerHand, 2);
            Console.WriteLine($"Dealer shows: {_dealerHand.GetHandDisplay().Split(',')[0]}");
        }

        public void DealCards(Hand hands, int? count)
        {
            for (int i = 0; i < count; i++)
            {
                var drawnCard = _deck.DrawCard();
                hands.AddCard(drawnCard);
                CardModel drawnCard = new CardModel(Models.Enums.Suit.Hearts, Models.Enums.Rank.Ace);

                hands.AddCard(drawnCard);
            }

        }

        //TODO: actually implement standing and hitting logic in full for differing player and dealer case.
        public void Hit(Hand hand)
        {
            DealCards(hand, 1);
        }

        public void Stand(Hand? hand = null)
        {
            Console.WriteLine(UIMessages.PlayerStandText);
            if (hand != null)
            {
                hand.IsStanding = true;
            }
        }

        public List<Hand> GetPlayerHands() => _playerHands;
        public Hand GetDealerHand() => _dealerHand;

        public void ResetGame()
        {
            _playerHands.Clear();
            _dealerHand.cards.Clear();
        }
        //TODO: reset game state somewhere here in a new method.

    }
}
