namespace BlackJackQueen.Models
{
    public class Hand
    {
        public List<CardModel> cards { get; private set; }
        public bool IsStanding { get; set; }
        public bool IsDealerHand { get; set; }

        public Hand()
        {
            cards = new List<CardModel>();
        }

        public void AddCard(CardModel card)
        {
            cards.Add(card);
        }

        public int GetCardCount()
        {
            return cards.Count();
        }

        public int GetTotalValueOfHand()
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

            return total;
        }

        //show the cards in the hand to the player.
        public string GetHandDisplay()
        {
            return string.Join(", ", cards.Select(c => c.ToString()));
        }
    }
}
