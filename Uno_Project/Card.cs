using System;
using System.Collections.Generic;
using System.Text;

namespace Uno_Project
{
    internal class Card
    {

        public string Color { get; private set; }

        public Card(string color)
        {
            Color = color;
        }
    }

    class NumberCard : Card
    {
        public int Number { get; private set; }

        public NumberCard(string color, int number) : base(color)
        {
            Number = number;
        }
    }

    class WildCard : Card
    {
        public string Function { get; private set; }

        public WildCard(string color, string function) : base(color)
        {
            Function = function;
        }

        /*
         olika functions:
                        1. switchDir

                        3. addTwo
                        4. switchCol (black)
                        5. addFourSwitchCol (black)
                        6. block
        */
    }
}