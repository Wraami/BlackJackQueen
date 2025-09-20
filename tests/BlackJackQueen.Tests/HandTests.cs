using BlackJackQueen.Models;
using BlackJackQueen.Models.Enums;
using BlackJackQueen.Services;
using BlackJackQueen.Tests.Fixtures;

namespace BlackJackQueen.Tests;

public class HandTests
{

    [Fact]
    public void Split_ShouldCreateSeparateHands_WhenOneHandHasPair()
    {
        var hand = HandHelper.CreateGenericPairHand();
        var gameService = new GameService();

        gameService.SplitHand(hand);

        Assert.Single(hand.cards);

    }

    [Theory]
    [InlineData(Rank.Seven, Rank.Seven, Rank.Seven)]
    [InlineData(Rank.Six, Rank.Five, Rank.Ten)]
    [InlineData(Rank.Eight, Rank.Seven, Rank.Six)]
    public void Hand_IsNotBlackJack_WhenHasMoreThanTwoCards(Rank firstRank, Rank secondRank, Rank thirdRank)
    {
        var hand = new Hand();
        hand.AddCard(new CardModel(Suit.Clubs, firstRank));
        hand.AddCard(new CardModel(Suit.Clubs, secondRank));
        hand.AddCard(new CardModel(Suit.Clubs, thirdRank));

        Assert.False(hand.IsBlackjack);
    }

    [Fact]
    public void Double_ShouldBeAllowed_WhenHandHasTwoCards()
    {
        var hand = HandHelper.CreateGenericPairHand();
        Assert.True(hand.CanDouble());

    }


}
