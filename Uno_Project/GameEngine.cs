using System;
using System.Collections.Generic;
using System.Text;

namespace Uno_Project
{
    internal class GameEngine
    {

        private List<Player> _players;

        


        static public void StartRound(Deck deck)
        {

            List<string> playerNames = GetPlayerNames();
            

            foreach (string playerName in playerNames)
            {
                
                Player player1 = new Player(playerName, CreateHand(deck.Cards));
            }

        }

        static List<string> GetPlayerNames()
        {

            Console.Write("Enter The Name of Player 1: ");
            string name1 = Console.ReadLine();

            Console.Write("Enter the Name of Player 2: ");
            string name2 = Console.ReadLine();

            return new List<string>() { name1, name2 };

        }


        static List<Card> CreateHand(List<Card> deck)
        {
            List<Card> hand = new();
            for (int i = 0; i <= 7; i++)
            {

                hand.Add(deck[0]);
                deck.RemoveAt(0);

            }
            return hand;
        }



    }


        
}
