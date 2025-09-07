using BlackJackQueen.Models.Enums;
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
                    throw new NotImplementedException("Invalid Input");
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
                    throw new ArgumentNullException(UIMessages.InvalidInputText);
            }
        }
    }
}
