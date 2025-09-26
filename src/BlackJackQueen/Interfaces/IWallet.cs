namespace BlackJackQueen.Interfaces
{
    public interface IWallet
    {
        decimal Balance { get; }
        void Deposit(decimal amount);
    }
}
