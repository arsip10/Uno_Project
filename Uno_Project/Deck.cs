namespace Uno_Project
{
    internal class Deck
    {

        public static List<Card> Cards { get; private set; }
        public static List<string> Colors = new List<string>(["🔵", "🔴", "🟡", "🟢"]);

        public Deck()
        {
            Cards = new List<Card>();
            MakeNumbercards();
            MakeWildcards();
        }

        public static void MakeNumbercards()
        {
            for (int ix = 0; ix < 4; ix++)
            {
                Cards.Add(new NumberCard(Colors[ix], "0"));
            }

            for (int i = 0; i < 9; i++)
            {
                for (int index = 0; index < 2; index++)
                {
                    for (int ind = 0; ind < 4; ind++)
                    {
                        Cards.Add(new NumberCard(Colors[ind], (i + 1).ToString()));
                    }
                }
            }


        }

        public static void MakeWildcards()
        {
            for (int index = 0; index < 2; index++)
            {
                for (int ind = 0; ind < 4; ind++)
                {
                    Cards.Add(new WildCard(Colors[ind], "block"));
                    Cards.Add(new WildCard(Colors[ind], "addTwo"));
                    Cards.Add(new WildCard(Colors[ind], "switchDir"));
                }

            }

            for (int i = 0; i < 4; i++)
            {
                Cards.AddRange(new WildCard("🌈", "switchCol"), new WildCard("🌈", "addFourSwitchCol"));
            }

        }
    }
}

/*
                        1.switchDir
                        3.addTwo
                        4.switchCol(black)
                        5.addFourSwitchCol(black)
                        6.block
*/