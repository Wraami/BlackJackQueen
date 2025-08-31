using BlackJackQueen.Models.Enums;

namespace BlackJackQueen.Models
{
    public class Deck
    {
        private readonly List<CardModel> _cards;

        public Deck()
        {
            _cards = new List<CardModel>();
            //TODO: allow custom specifying of generating decks at users discretion
            GenerateDeck(1);
        }

        private void GenerateDeck(int desiredCount = 1)
        {
            for (int i = 0; i < desiredCount; i++)
            {
                foreach (Suit suit in Enum.GetValues<Suit>())
                {
                    foreach (Rank rank in Enum.GetValues<Rank>())
                    {
                        _cards.Add(new CardModel(suit, rank));
                    }
                }
            }
            Shuffle();
        }

        //TODO: human hand shuffle logic? how would this be accounted for? migrate away from use of random :)
        private void Shuffle()
        {
            var rng = new Random();

            for (int i = 0; i < _cards?.Count; i++)
            {
                int j = rng.Next(_cards.Count);
                CardModel tempCard = _cards[i];
                _cards[i] = _cards[j];
                _cards[j] = tempCard;
            }

        }

        public CardModel DrawCard()
        {
            if (_cards.Count == 0)
            {
                throw new InvalidOperationException("Deck is empty.");
            }
            var card = _cards[0];
            _cards.RemoveAt(0);
            return card;
        }
    }
}
