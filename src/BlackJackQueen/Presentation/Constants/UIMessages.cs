namespace BlackJackQueen.Presentation.Constants
{
    public class UIMessages
    {
        #region Welcome Messages
        public const string StarterMessage = "Welcome to BlackJackQueen! we're gonna teach you, yes YOU! how to actually play blackjack so you don't embarrass yourself when you go to a real casino :)";
        public const string CounterStarterMessage = "Welcome back to blackjack.";
        public const string WelcomeBasicStrategyPrompt = "Do you want to see basic strategy? Y/N";
        public const string WelcomeTrueCountPrompt = "Do you want to see the true count? Y/N";
        public const string ExperienceSelectText = "Select your experience you want to use with blackjack:";
        public const string NoNameUserMessage = "Name not entered, logging as a guest...";
        public const string NewGameText = "Starting a new round of blackjack, best of luck!";
        #endregion

        #region Player Prompts
        public const string PlayerNamePrompt = "Please enter your name: ";
        public const string PlayerInputPrompt = "Enter H (Hit), S (Stand), Q (Quit), V (Rules), ' (Settings), C (clear):";
        public const string PlayerFirstTurnPrompt = "Enter H (Hit), S (Stand), D (Double), SP (Split), Q (Quit), V (Rules), ' (Settings), C (clear):";
        public const string PlayerSplitPrompt = "You can split this hand, enter SP if you'd like to split.";
        public const string InvalidInputText = "Invalid input, please enter H, S, Q or one of the other prompt options and try again :)";
        public const string DoublePrompt = "Invalid input, please enter H, S, Q or one of the other prompt options and try again :)";
        #endregion

        public const string PlayerSplitError = "This hand can't be split! try again with a splittable hand.";

        #region Experience Prompts
        public const string PlayerCasualOption = "1 - Casual Player";
        public const string PlayerCounterOption = "2 - Card Counter";
        #endregion

        #region Hand Logic
        public const string SuccessfulSplitMessage = "Hand successfully split!";
        public const string PlayerDoubleError = "This hand can't be doubled! try a different option";
        public const string QuitText = "Quitting this blackjack hand!";
        public const string BustMessageText = "Hand has bust! ouchie!";
        public const string DealerHiddenCardMessage = "Dealt [HIDDEN CARD] to dealer's hand";
        public const string InvalidHandSelectionMessage = "Invalid hand selection, pick a valid hand";
        #endregion

        #region Action Messages

        public const string DealerHitText = "Dealer hits!";
        public const string DealerStandText = "Dealer stands!";
        public const string PlayerStandText = "Player stands!";
        #endregion

        public const string BlackjackText = "Blackjack! :D";
        public const string BetPrompt = "How much would you like to bet this round?";
        public const string EmptyDeckMessage = "Deck is empty! generating a new deck...";
        public const string PlayAgainPrompt = "Would you like to play another round? (Y/N)";

        #region Game Results
        public const string DealerWinBustMessage = "Player busts! Dealer wins :/.";
        public const string PlayerWinBustMessage = "Dealer busts! Player wins.";
        public const string DealerWinMessage = "Dealer wins.";
        public const string PlayerWinMessage = "Player wins.";
        public const string GamePushMessage =  "Push (tie).";
        public const string LeavingMessage = "Thanks for playing!";

        #endregion

        #region Wallet
        public const string DepositErrorMessage = "Cannot Deposit an invalid amount!";
        public const string DepositErrorUserMessage = "You've tried to deposit an invalid balance, can you try entering a number?";

        #endregion
    }
}
