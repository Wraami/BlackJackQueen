using BlackJackQueen.Models.Enums;

namespace BlackJackQueen.Models
{
    public class CardModel
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public CardModel(Suit suit, Rank rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }

    }

}
