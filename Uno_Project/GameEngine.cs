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

        


        static public void StartGame()
        {

            List<string> playerNames = GetPlayerNames();
            

            foreach (string playerName in playerNames)
            {
                
                Player player = new Player(playerName, CreateHand(Deck.Cards));
                _players.Add(player);
            }

            Round();

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
            for (int i = 0; i <= 7; i++) // Seven cards per hand
            {

                hand.Add(deck[0]);
                deck.RemoveAt(0);

            }
            return hand;
        } 

        static void Round() 
        {
            bool game = true;
            PlaceFirstCard();
            while (game)
            {
                foreach (Player p in _players)
                {

                    Console.WriteLine($"{p.Name}'s Turn.");
                    ShowHand(p);
                    PlayCard(GetPlayedCard(p), p);
                    if (p.Hand.Count == 0)
                    {
                        Console.WriteLine($"{p.Name} Won!");
                        game = false;
                        
                    }
                }

                
            }
            Console.Write("Game End!");


        }


        static void ShowHand(Player p) // Shows Hand and corresponding letters 
        {
            Console.WriteLine($"\n\nTop Card: {GamePile.Cards[GamePile.Cards.Count - 1].Color}-{GamePile.Cards[GamePile.Cards.Count - 1].Value}\n\n");
            Console.WriteLine("Your Hand:");
            for (int i = 0; i < p.Hand.Count(); i++)
            {

                Console.Write($"[{Letters[i]}]: {p.Hand[i].Color}-{p.Hand[i].Value} | "); //change color to emojis
            }

            

        } 

        static Card GetPlayedCard(Player p) 
        {
            while (true)
            {
                Console.WriteLine("\nChoose a card to play by entering it's corresponding letter.");
                Console.Write(">>>");
                string choice = Console.ReadLine().ToUpper();

                int cardIndex = 100;
                for (int i = 0; i < p.Hand.Count; i++) // this could be a problem
                {
                    if (Letters[i] == choice) { cardIndex = i; break; }
                }

                if (cardIndex != 100) { return p.Hand[cardIndex]; } //Next Time: check and loop until cardIndex isn't 100
            }
            
            
            

        } 


        static void PlayCard(Card playedCard, Player p) // Checks and plays card
        {


            if (GamePile.Cards[GamePile.Cards.Count - 1].Color == playedCard.Color || GamePile.Cards[GamePile.Cards.Count - 1].Value == playedCard.Value) 
            {
                Console.WriteLine($"Played: {playedCard.Value}");
                GamePile.Cards.Add(playedCard);
                p.Hand.Remove(playedCard);
            }
            else { Console.WriteLine("Cannot Play This Card!"); }

        } 



        static void PlaceFirstCard() 
        {
            GamePile.Cards.Add(Deck.Cards[0]);
        }



    }


        
}
