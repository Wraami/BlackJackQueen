using BlackJackQueen.Interfaces;
using BlackJackQueen.Presentation.Constants;

namespace BlackJackQueen.Presentation.Output
{
    public class DisplayOptions : IDisplay
    {
        public static void DisplayStarterOptions()
        {
            Console.Clear();
            Console.WriteLine(UIMessages.StarterMessage);
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
            Console.WriteLine(UIMessages.CounterStarterMessage);
            Console.WriteLine(UIMessages.WelcomeBasicStrategyPrompt);
            Console.WriteLine(UIMessages.WelcomeTrueCountPrompt);
        }
        
        //TODO: implement a more robust divider that can be used to break up different logical sections of the game, potentially use some ASCII to make this more visually appealing :)
        public static void InsertDisplayDivider(int? displayDividerAmount = 1)
        {
            for (int i = 0; i < displayDividerAmount; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
