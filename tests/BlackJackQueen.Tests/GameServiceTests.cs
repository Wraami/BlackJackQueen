using BlackJackQueen.Tests.Fixtures;

namespace BlackJackQueen.Tests
{
    public class GameServiceTests
    {

        [Fact]
        public void Double_ShouldStand_AfterPerformedOnFirstHand()
        {
            var hand = HandHelper.CreateGenericPairHand();
            Assert.True(hand.CanDouble());

        }

    }
}
