using System;
using System.Collections.Generic;
using System.Text;

namespace Uno_Project
{
    internal class Card
    {

        public string Color { get; set; }
        public string Value { get; private set; }

        public Card(string color, string value)
        {
            Color = color;
            Value = value;
        }
    }

    class NumberCard : Card
    {
        public NumberCard(string color, string number) : base(color, number)
        {

        }
    }

    class WildCard : Card
    {
        public WildCard(string color, string function) : base(color, function)
        {

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