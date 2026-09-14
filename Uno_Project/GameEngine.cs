using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Uno_Project
{
    internal class GameEngine
    {

        static private List<Player> _players = new();
        static List<String> Letters = Enumerable.Range('A', 26).Select(c => ((char)c).ToString()).ToList(); // List of letters A-Z

        


        static public void StartRound(Deck deck)
        {

            List<string> playerNames = GetPlayerNames();
            

            foreach (string playerName in playerNames)
            {
                
                Player player = new Player(playerName, CreateHand(deck.Cards));
                _players.Add(player);
            }

        } // Initiates Game

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

        static void Round()
        {

            foreach (Player p in _players)
            {
                Console.WriteLine($"{p.Name}'s Turn.");

            }

        }


        static void ShowHand(Player p) // Shows Hand and corresponding letters 
        {
            for(int i = 0; i < p.Hand.Count(); i++)
            {

                Console.WriteLine("Your Hand:");
                Console.Write($"[{Letters[i]}]: {p.Hand[i].Color}-{p.Hand[i].Value} | ");
            }
        }

        static Card GetPlayedCard(Player p)
        {

            Console.WriteLine("Choose a card to play by entering it's corresponding letter.");
            Console.Write(">>>");
            string choice = Console.ReadLine();

            int cardIndex = 100;
            for (int i = 0; i < p.Hand.Count; i++) // this could be a problem
            {
                if (Letters[i] == choice) { cardIndex = i; break; }
            }

            if (cardIndex != 100) { } //Next Time: check and loop until cardIndex isn't 100
            return p.Hand[cardIndex];
            
            
            

        }


        static void PlayCard(Card playedCard, Card gameCard) // Checks and plays card
        {


            if (gameCard.Color == playedCard.Color || gameCard.Value == playedCard.Value) 
            {
                
            }

        }







    }


        
}
