using BlackJackQueen.Models.Enums;

namespace BlackJackQueen.Presentation.Parsers
{
    public static class PlayerInputParser
    {
        public static PlayerInputType ParseInputs(string input)
        {
            switch (input.ToUpper())
            {
                case "H":
                    return PlayerInputType.Hit;
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
    }
}
