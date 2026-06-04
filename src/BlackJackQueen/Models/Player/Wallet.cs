using BlackJackQueen.Interfaces;
using BlackJackQueen.Presentation.Constants;

namespace BlackJackQueen.Models.Player
{
    public class Wallet : IWallet
    {
        public decimal Balance { get; private set; }

        //TODO: allow a user to negate or set this appropriately, but for now just a default starting balance of 1000 chips.
        public static decimal DefaultBalance => 1000m;

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
