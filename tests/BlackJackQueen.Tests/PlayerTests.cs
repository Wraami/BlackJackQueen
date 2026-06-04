using BlackJackQueen.Models.Player;

namespace BlackJackQueen.Tests
{
    public class PlayerTests
    {
        [Theory]
        [InlineData("Lizzy")]
        [InlineData("Kitty")]
        [InlineData("Regina")]
        public void Player_ShouldBeAllowedToSetName_WhenConstructed(string playerName)
        {
            var player = new Player(playerName);
            Assert.Equal(player.PlayerName, playerName);
        }

        [Fact]
        public void Player_SetsNameAndReadsBalanceFromWallet()
        {
            var wallet = new Wallet(250m);
            var player = new Player("Lizzy", wallet);

            Assert.Equal("Lizzy", player.PlayerName);
            Assert.Equal(250m, player.Balance);
        }

    }
}
