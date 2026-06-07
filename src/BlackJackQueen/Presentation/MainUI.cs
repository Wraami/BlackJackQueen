using BlackJackQueen.Models;
using BlackJackQueen.Models.Player;
using BlackJackQueen.Presentation.Constants;
using BlackJackQueen.Presentation.Parsers;

namespace BlackJackQueen.Presentation
{
    public class MainUI
    {
        public MainUI()
        {
        }

        public void Start()
        {
            var controller = new GameController(this);
            controller.Start();
        }

        public void InitializePlayerBalance(Player player)
        {
            if (player.Balance != 0m)
            {
                return;
            }

            Console.WriteLine("You currently have no chips to play with, Please enter the amount of chips that you'd like below:");
            string balanceInput = Console.ReadLine();
            decimal parsedBalance = PlayerInputParser.ParseBalance(balanceInput);

            if (parsedBalance <= 0m)
            {
                Console.WriteLine("Invalid balance input, defaulting to 1000 chips.");
                player.Wallet.Deposit(Wallet.DefaultBalance);
            }
            else
            {
                player.Wallet.Deposit(parsedBalance);
            }
        }

        public Player CreatePlayer()
        {
            Console.WriteLine(UIMessages.PlayerNamePrompt);

            string nameInput = Console.ReadLine();

            var name = PlayerInputParser.ParseName(nameInput);
            var wallet = new Wallet(0m);
            return new Player(name, wallet);
        }
    }
}
