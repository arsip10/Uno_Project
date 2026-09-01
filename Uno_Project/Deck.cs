namespace Uno_Project
{
    internal class Deck
    {

        public static List<Card> Cards { get; private set; }

        public Deck()
        {
            Cards = new List<Card>();
        }

        public static void MakeNumbercards()
        {
            for (int i = 0; i < 9; i++)
            {
                if (i == 0)
                {
                    NumberCard nc8 = new NumberCard("blue", i);
                    NumberCard nc9 = new NumberCard("red", i);
                    NumberCard nc10 = new NumberCard("yellow", i);
                    NumberCard nc11 = new NumberCard("green", i);
                    Cards.AddRange(nc8, nc9, nc10, nc11);
                }

                NumberCard nc = new NumberCard("blue", i + 1);
                NumberCard nc1 = new NumberCard("blue", i + 1);
                NumberCard nc2 = new NumberCard("red", i + 1);
                NumberCard nc3 = new NumberCard("red", i + 1);
                NumberCard nc4 = new NumberCard("yellow", i + 1);
                NumberCard nc5 = new NumberCard("yellow", i + 1);
                NumberCard nc6 = new NumberCard("green", i + 1);
                NumberCard nc7 = new NumberCard("green", i + 1);
                Cards.AddRange(nc, nc1, nc2, nc3, nc4, nc5, nc6, nc7);
            }
            

        }

        public static void MakeWildcards()
        {
            WildCard wc = new WildCard("blue", "block");
            WildCard wc1 = new WildCard("blue", "addTwo");
            WildCard wc2 = new WildCard("blue", "switchDir");
            WildCard wc3 = new WildCard("red", "block");
            WildCard wc4 = new WildCard("red", "addTwo");
            WildCard wc5 = new WildCard("red", "switchDir");
            WildCard wc6 = new WildCard("yellow", "block");             //ett annat sätt att göra utan att ta upp så många rader?
            WildCard wc7 = new WildCard("yellow", "addTwo");
            WildCard wc8 = new WildCard("yellow", "switchDir");
            WildCard wc9 = new WildCard("green", "block");
            WildCard wc10 = new WildCard("green", "addTwo");
            WildCard wc11 = new WildCard("green", "switchDir");
            Cards.AddRange(wc, wc1, wc2, wc3, wc4, wc5, wc6, wc7, wc8, wc9, wc10, wc11);

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