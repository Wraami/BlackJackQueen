using BlackJackQueen.Models.Player;

namespace BlackJackQueen.Tests
{
    public class WalletTests
    {

        [Fact]
        public void Wallet_ShouldStartWithInitialBalance_WhenPassedIn()
        {
            var wallet = new Wallet(500m);
            Assert.Equal(500m, wallet.Balance);
        }

        [Fact]
        public void Wallet_ShouldUpdateBalance_WhenDepositIsCalled()
        {
            var wallet = new Wallet(0m);
            wallet.Deposit(200m);
            Assert.Equal(200m, wallet.Balance);
        }

    }
}
