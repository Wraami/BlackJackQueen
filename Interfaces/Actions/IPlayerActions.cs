namespace BlackJackQueen.Interfaces.Actions
{
    public interface IPlayerActions
    {
        //we always want to execute on a specific hand
        void PlayerHits(int handIndex);
        void PlayerStands(int handIndex);

    }
}
