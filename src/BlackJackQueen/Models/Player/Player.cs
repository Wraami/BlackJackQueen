using BlackJackQueen.Interfaces;

namespace BlackJackQueen.Models.Player
{
    public class Player
    {
        public IWallet? Wallet { get; }
        public string PlayerName { get; private set; }
        public decimal Balance => Wallet.Balance;

        public Player(string playerName, IWallet? wallet = null)
        {
            Wallet = wallet;
            PlayerName = playerName;
        }
    }
}
