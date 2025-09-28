using BlackJackQueen.Tests.Fixtures;

namespace BlackJackQueen.Tests
{
    public class WalletTests
    {

        [Fact]
        public void Wallet_ShouldStartWithInitialBalance_WhenPassedIn()
        {
            var wallet = WalletHelper.CreateGenericWalletWithBalance();
            Assert.Equal(500m, wallet.Balance);
        }

        [Theory]
        [InlineData(500)]
        [InlineData(200)]
        public void Wallet_ShouldUpdateBalance_WhenDepositIsCalled(decimal balanceToDeposit)
        {
            var wallet = WalletHelper.CreateGenericWalletWithBalance(0m);
            wallet.Deposit(balanceToDeposit);
            Assert.Equal(balanceToDeposit, wallet.Balance);
        }

    }
}
