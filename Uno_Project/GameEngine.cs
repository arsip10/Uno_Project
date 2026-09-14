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

        


        static public void StartGame(Deck deck)
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

        } //Done

        static List<Card> CreateHand(List<Card> deck)
        {
            List<Card> hand = new();
            for (int i = 0; i <= 7; i++) // Seven cards per hand
            {

                hand.Add(deck[0]);
                deck.RemoveAt(0);

            }
            return hand;
        } //Done

        static void Round(Deck deck, GamePile gp) // Ongoing
        {
            PlaceFirstCard(deck, gp);

            foreach (Player p in _players)
            {
                
                Console.WriteLine($"{p.Name}'s Turn.");
                ShowHand(p);
                PlayCard(GetPlayedCard(p), gp);
                if (p.Hand.Count == 0)
                {
                    Console.WriteLine($"{p.Name} Won!");
                }
            }

        }


        static void ShowHand(Player p) // Shows Hand and corresponding letters 
        {
            for(int i = 0; i < p.Hand.Count(); i++)
            {

                Console.WriteLine("Your Hand:");
                Console.Write($"[{Letters[i]}]: {p.Hand[i].Color}-{p.Hand[i].Value} | ");
            }
        } //Done

        static Card GetPlayedCard(Player p) 
        {
            while (true)
            {
                Console.WriteLine("Choose a card to play by entering it's corresponding letter.");
                Console.Write(">>>");
                string choice = Console.ReadLine();

                int cardIndex = 100;
                for (int i = 0; i < p.Hand.Count; i++) // this could be a problem
                {
                    if (Letters[i] == choice) { cardIndex = i; break; }
                }

                if (cardIndex != 100) { return p.Hand[cardIndex]; } //Next Time: check and loop until cardIndex isn't 100
            }
            
            
            

        } //Done


        static void PlayCard(Card playedCard, GamePile gp) // Checks and plays card
        {


            if (gp.Cards[0].Color == playedCard.Color || gp.Cards[0].Value == playedCard.Value) 
            {
                Console.WriteLine($"Played: {playedCard.Value}");
                gp.Cards.Add(playedCard);
            }
            else { Console.WriteLine("Cannot Play This Card!"); }

        } //Done



        static void PlaceFirstCard(Deck deck, GamePile gp) //Done
        {
            gp.Cards.Add(deck.Cards[0]);
        }



    }


        
}
