using BlackJackQueen.Interfaces;

namespace BlackJackQueen.Models.Player
{
    public class Wallet : IWallet
    {
        public decimal Balance { get; private set; }

        public Wallet(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
