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
            _dealerHand = new Hand()
            {
                IsDealerHand = true
            };
            _gameActions = new DealerActions(this);
            _deck = new Deck();
        }

        public void DealInitialHand()
        {
            foreach (var hand in _playerHands)
            {
                DealCards(hand, 2);
                Console.WriteLine($"Player Hand: {hand.GetHandDisplay()} (Total: {hand.TotalValue})");
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
                //we need to have something to track if its a dealer hand or a regular hand beyond the bool prop, maybe IsInitialDeal via a game state?
                if (hands.IsDealerHand)
                {
                    if (hands.cards.Count() == 2)
                    {
                        Console.WriteLine($"Dealt [HIDDEN CARD] to dealer's hand");
                        continue;

                    }
                    Console.WriteLine($"Dealt {drawnCard} to dealer's hand");

                }
                else
                {
                    Console.WriteLine($"Dealt {drawnCard} to player's hand");
                }
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

    }
}
