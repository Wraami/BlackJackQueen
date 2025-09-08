namespace BlackJackQueen.Models
{
    public class Hand
    {
        public List<CardModel> cards { get; private set; }
        public bool IsStanding { get; set; }
        public bool IsDealerHand { get; set; }
        public bool IsBust => GetTotalValueOfHand().IsBust;
        public bool IsSoft => GetTotalValueOfHand().IsSoft;
        public bool IsBlackjack => GetTotalValueOfHand().IsBlackjack;
        public int TotalValue => GetTotalValueOfHand().Total;

        public Hand()
        {
            cards = new List<CardModel>();
        }

        public void AddCard(CardModel card)
        {
            cards.Add(card);
        }

        public void RemoveCard(CardModel card)
        {
            cards.Remove(card);
        }

        public HandValue GetTotalValueOfHand()
        {
            int total = 0;
            int aceCount = 0;

            foreach (var card in cards)
            {
                if (card.Rank == Enums.Rank.Ace)
                {
                    aceCount++;
                    total += 11;
                }
                else
                {
                    total += (int)card.Rank;
                }
            }

            //Attempt to handle aces.
            while (total > 21 && aceCount > 0)
            {
                total -= 10;
                aceCount--;
            }

            bool isSoft = aceCount > 0;
            bool isBust = total > 21;
            bool isBlackjack = total == 21 && cards.Count == 2;

            return new HandValue(total, isSoft, isBust, isBlackjack);
        }

        //show the cards in the hand to the player.
        public string GetHandDisplay()
        {
            return string.Join(", ", cards.Select(c => c.ToString()));
        }

        public bool CanSplit()
        {
            return cards[0].Rank == cards[1].Rank && cards.Count == 2;
        }
    }
}
