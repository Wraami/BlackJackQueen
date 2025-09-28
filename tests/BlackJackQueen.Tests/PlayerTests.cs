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

    }
}
