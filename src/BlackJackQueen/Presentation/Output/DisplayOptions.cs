using BlackJackQueen.Interfaces;

namespace BlackJackQueen.Presentation.Output
{
    public class DisplayOptions : IDisplay
    {
        public static void DisplayStarterOptions()
        {
            Console.Clear();
            Console.WriteLine("Welcome to BlackJackQueen! we're gonna teach you, yes YOU! how to actually play blackjack so you don't embarrass yourself when you go to a real casino :)");
            Console.WriteLine("");
        }

        public void ShowGameState()
        {
            Console.WriteLine("Your Hands: ");

            Console.WriteLine($"Dealer's hand: ");

        }

        //TODO: Implement logic that if we've chosen this, we display true count information and strategy.
        public static void DisplayCounterOptions()
        {
            Console.Clear();
            Console.WriteLine("Welcome back to blackjack.");
            Console.WriteLine("Do you want to see basic strategy? Y/N");
            Console.WriteLine("Do you want to see the true count? Y/N");


        }
    }
}
