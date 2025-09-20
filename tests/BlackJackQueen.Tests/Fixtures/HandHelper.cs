using BlackJackQueen.Models;
using BlackJackQueen.Models.Enums;

namespace BlackJackQueen.Tests.Fixtures
{
    public static class HandHelper
    {
        public static Hand CreateGenericPairHand()
        {
            var hand = new Hand();

            hand.AddCard(new CardModel(Suit.Diamonds, Rank.Six));
            hand.AddCard(new CardModel(Suit.Spades, Rank.Six));

            return hand;
        }
    }
}
