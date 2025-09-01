namespace BlackJackQueen.Models
{
    public class HandValue
    {
        public int Total { get; }
        public bool IsSoft { get; }
        public bool IsBust { get; }
        public bool IsBlackjack { get; }

        public HandValue(int total, bool isSoft, bool isBust, bool isBlackjack)
        {
            Total = total;
            IsSoft = isSoft;
            IsBust = isBust;
            IsBlackjack = isBlackjack;
        }
    }
}
