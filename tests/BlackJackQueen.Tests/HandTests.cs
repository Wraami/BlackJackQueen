using BlackJackQueen.Models;
using BlackJackQueen.Services;

namespace BlackJackQueen.Tests;

public class HandTests
{
    [Fact]
    public void Split_ShouldCreateSeparateHands_WhenOneHandHasPair()
    {
        var hand = new Hand();

        hand.AddCard(new CardModel(Models.Enums.Suit.Diamonds, Models.Enums.Rank.Six));
        hand.AddCard(new CardModel(Models.Enums.Suit.Spades, Models.Enums.Rank.Six));

        var gameService = new GameService();

        gameService.SplitHand(hand);

        Assert.Single(hand.cards);

    }
}
