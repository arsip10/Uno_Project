namespace Uno_Project
{
    class Program
    {
        public static void StartMenu()
        {
            Console.WriteLine("--- WELCOME TO UNO ---\n"
                             +"Press:\n"
                             +"[1] Start\n"
                             +"[2] How To Play\n"
                             +"[0] Quit");
        }

        public static int MenuChoice()
        {
            if (!int.TryParse(Console.ReadLine(), out int menuchoice))
            {
                menuchoice = -1;
            }
            Console.Clear();

            return menuchoice;
        }

        public static void Tutorial()
        {
            Console.WriteLine("--- HOW TO PLAY ---\n"
                             +"Each player starts with 7 cards in their hands.\n"
                             +"Match the top card on the DISCARD pile either by number, color, or word. \nFor example, if the card is a Green 7, you must play a Green card or any color 7. \nOr, you may play any Wild card or a Wild Draw 4 card. If you don't have anything that matches, you must pick a card from the DRAW pile\n"
                             +"If you draw a card you can play, play it. Otherwise, play moves to the next person.\n"
                             +"The first player to get rid of all of their cards and yell out UNO wins!");
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool keepgoing = true;
            string systemMsg = "";

            while (keepgoing)
            {
                StartMenu();

                switch (MenuChoice())
                {
                    case 1:

                        break;

                    case 2:
                        Tutorial();
                        break;

                    case 0:
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
   