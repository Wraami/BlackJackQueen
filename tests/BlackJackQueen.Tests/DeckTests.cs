using BlackJackQueen.Models;

namespace BlackJackQueen.Tests
{
    public class DeckTests
    {

        [Fact]
        public void Deck_ShouldGenerateNewDeck_WhenDeckIsEmptied()
        {
            var deck = new Deck();

            for (int i = 0; i < 52; i++)
            {
                deck.DrawCard();

            }

            deck.DrawCard();
            Assert.True(deck.CardsRemaining > 0);
        }


    }
}
