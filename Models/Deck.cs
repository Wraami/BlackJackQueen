using BlackJackQueen.Models.Enums;

namespace BlackJackQueen.Models
{
    //TODO: Add logic for ranks and suits within a deck.
    public class Deck
    {
        public int CardsLeft { get; set; }
        public List<CardModel>? Cards { get; set; }

        public Deck()
        {
            Cards = new List<CardModel>();
            GenerateDeck();
        }

        private void GenerateDeck()
        {
            foreach (Suit suit in Enum.GetValues<Suit>())
            {
                foreach (Rank rank in Enum.GetValues<Rank>())
                {
                    Cards.Add(new CardModel(suit, rank));
                }
            }
        }

        //TODO: human hand shuffle logic? how would this be accounted for? migrate away from use of random :)
        private void Shuffle()
        {
            var rng = new Random();

            for (int i = 0; i < Cards.Count; i++)
            {
                int j = rng.Next(Cards.Count);
                var tempCard = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = tempCard;
            }

        }
    }
}
