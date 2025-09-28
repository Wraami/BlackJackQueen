using BlackJackQueen.Models.Player;

namespace BlackJackQueen.Tests.Fixtures
{
    public static class WalletHelper
    {
        public static Wallet CreateGenericWalletWithBalance(decimal defaultBalance = 500m)
        {
            return new Wallet(defaultBalance);
        }
    }
}
