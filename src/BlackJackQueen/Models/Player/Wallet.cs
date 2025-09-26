using BlackJackQueen.Interfaces;
using BlackJackQueen.Presentation.Constants;

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
            if (amount < 0)
            {
                Console.WriteLine(UIMessages.DepositErrorMessage);
                return;
            }
            Balance += amount;
        }
    }
}
