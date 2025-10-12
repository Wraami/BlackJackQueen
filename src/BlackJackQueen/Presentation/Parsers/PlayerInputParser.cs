using BlackJackQueen.Models.Enums;
using BlackJackQueen.Models.Player;
using BlackJackQueen.Presentation.Constants;
using BlackJackQueen.Presentation.Output;

namespace BlackJackQueen.Presentation.Parsers
{
    public static class PlayerInputParser
    {
        public static PlayerInputType ParseGameInputs(string input)
        {
            switch (input.ToUpper())
            {
                case "H":
                    return PlayerInputType.Hit;
                case "D":
                    return PlayerInputType.Double;
                case "SP":
                    return PlayerInputType.Split;
                case "S":
                    return PlayerInputType.Stand;
                case "Q":
                    return PlayerInputType.Quit;
                case "V":
                    return PlayerInputType.ViewRules;
                case "'":
                    return PlayerInputType.Settings;
                default:
                    throw new ArgumentException("Invalid Input");
            }
        }

        public static void ParseExperienceLevel(string input)
        {
            switch (input)
            {
                case "1":
                    DisplayOptions.DisplayStarterOptions();
                    return;

                case "2":
                    DisplayOptions.DisplayCounterOptions();
                    return;

                default:
                    throw new ArgumentException(UIMessages.InvalidInputText);
            }
        }

        public static Player ParseName(string playerName)
        {
            if (string.IsNullOrWhiteSpace(playerName))
            {
                Console.WriteLine("Name not entered, logging as a guest...");
                return new Player("Guest");
            }

            return new Player(playerName);
        }

        public static bool ParseContinueGameInput(string input)
        {
            switch (input)
            {
                case "Y":
                    return true;

                case "N":
                    Console.WriteLine(UIMessages.LeavingMessage);
                    return false;

                default:
                    throw new ArgumentException(UIMessages.InvalidInputText);
            }
        }
    }
}