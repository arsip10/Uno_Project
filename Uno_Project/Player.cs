using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Uno_Project

{
    internal class Player
    {

        public string Name { get; private set; }

        public List<Card> Hand { get; set; }

        public Player(string name, List<Card> hand)
        {
            Name = name;
            Hand = hand;
        }



    }






}
