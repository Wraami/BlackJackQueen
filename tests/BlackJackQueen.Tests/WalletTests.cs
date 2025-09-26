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

    }
}
