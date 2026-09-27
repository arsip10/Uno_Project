
using System.Text;

namespace Uno_Project
{
    class Program
    {
        public static void StartMenu()
        {
            Console.WriteLine("--- WELCOME TO UNO ---\n\n"
                             + "Press:\n"
                             + "[1] Start\n"
                             + "[2] How To Play\n"
                             + "[0] Quit");
        }

        public static ConsoleKey MenuChoice()
        {
            ConsoleKey menuchoice = Console.ReadKey().Key;
            if (menuchoice != ConsoleKey.D1 && menuchoice != ConsoleKey.D2 && menuchoice != ConsoleKey.D0)
            {
                menuchoice = ConsoleKey.D9;
            }
            Console.Clear();

            return menuchoice;
        }

        public static void Tutorial()
        {
            Console.WriteLine("--- HOW TO PLAY ---\n\n"
                             + "Each player starts with 7 cards in their hands.\n"
                             + "Match the top card on the DISCARD pile either by number, color, or word. \nFor example, if the card is a Green 7, you must play a Green card or any color 7. \nOr, you may play any Wild card or a Wild Draw 4 card. If you don't have anything that matches, you must pick a card from the DRAW pile\n"
                             + "If you draw a card you can play, play it. Otherwise, play moves to the next person.\n"
                             + "The first player to get rid of all of their cards and yell out UNO wins!\n\n"
                             + "Press any key to go back.");
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            bool keepgoing = true;
            string systemMsg = "";
            Deck deck = new();

            while (keepgoing)
            {
                StartMenu();

                switch (MenuChoice())
                {
                    case ConsoleKey.D1:
                        GameEngine.StartGame();
                        break;

                    case ConsoleKey.D2:
                        bool go = true;
                        Tutorial();
                        while (go)
                        {
                            if (Console.ReadKey().Key != null)
                            {
                                go = false;
                            }
                        }
                        Console.Clear();
                        break;

                    case ConsoleKey.D0:
                        keepgoing = false;
                        systemMsg = "Quitting...😢";
                        break;

                    default:
                        systemMsg = "Wrong input, sending you back to the main menu...";
                        break;
                }
                Console.WriteLine(systemMsg);
            }
        }
    }
}

