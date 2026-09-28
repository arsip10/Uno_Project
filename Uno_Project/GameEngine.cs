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
        static int currentPlayerIndex = 0;
        static int playDirection = 1; // 1 for forward, -1 for reverse




        static public void StartGame() // Initiates Game
        {

            List<string> playerNames = GetPlayerNames();


            foreach (string playerName in playerNames)
            {

                Player player = new Player(playerName, CreateHand(Deck.Cards));
                _players.Add(player);
            }

            Round();

        }

        static int GetNrOfPlayers()
        {
            Console.WriteLine("");
            int nrP = Console.ReadLine(); //använda arrow keys för att user ska kunna välja amount of players men bara mellan 1-4 players (controlled)
            return nrP;
        }

        static List<string> GetPlayerNames(int nrPlayers)
        {
            List<string> pn = new List<string>();

            for(int i=0; i<nrPlayers; i++)
            {
                Console.Write($"Enter The Name of Player {i+1}: ");
                string name = Console.ReadLine();
                pn.Add(name);
            }
            return pn;

        }

        static List<Card> CreateHand(List<Card> deck)
        {
            List<Card> hand = new();
            for (int i = 0; i < 7; i++) // Seven cards per hand
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
                Player p = _players[currentPlayerIndex]; // Use index instead of foreach
                bool turn = true;
                while (turn)
                {
                    Console.WriteLine($"\n==========================================");
                    Console.WriteLine($"{p.Name}'s Turn.");

                    Card cardToPlay = GetPlayedCard(p);
                    if (PlayCard(cardToPlay, p))
                    {
                        turn = false;
                    }

                    if (p.Hand.Count == 0)
                    {
                        Console.WriteLine($"{p.Name} Won!");
                        game = false;
                        break;
                    }
                }

                if (!game) break;

                NextTurn(); // Move to the next player based on playDirection
            }
            Console.WriteLine("Game End!");
        }


        static void ShowHand(Player p) // Shows Hand and corresponding letters 
        {
            Console.WriteLine($"\n\nTop Card: {GamePile.Cards[GamePile.Cards.Count - 1].Color} {GamePile.Cards[GamePile.Cards.Count - 1].Value}\n\n");
            Console.WriteLine("Your Hand:");
            for (int i = 0; i < p.Hand.Count(); i++)
            {

                Console.Write($"[{Letters[i]}]: {p.Hand[i].Color} {p.Hand[i].Value} | "); 
            }



        }

        static Card GetPlayedCard(Player p) // Gets player choice. Player may choose to draw.
        {
            while (true)
            {
                ShowHand(p);
                Console.WriteLine("\nChoose a card to play by entering its corresponding letter, or press [Enter] to draw.");
                Console.Write(">>> ");
                string choice = Console.ReadLine().Trim().ToUpper();

                if (choice == "")
                {
                    if (DrawCard(p))
                    {
                        return null; // Draw was valid; signals turn completion to PlayCard
                    }

                    // Draw was rejected because playable cards exist; loop repeats & turn continues
                    Console.WriteLine("\nPress any key to try again...");
                    Console.ReadKey();
                    continue;
                }

                int cardIndex = 100;
                for (int i = 0; i < p.Hand.Count; i++)
                {
                    if (Letters[i] == choice) { cardIndex = i; break; }
                }

                if (cardIndex != 100)
                {
                    return p.Hand[cardIndex];
                }

                Console.WriteLine("Invalid input. Please enter a valid letter or press [Enter].");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }


        static bool PlayCard(Card playedCard, Player p)
        {
            if (playedCard == null)
            {
                return true;
            }

            if (PileCardCompare(playedCard))
            {
                // 1. If it's a Wild card, let the player choose the new color
                if (playedCard.Value == "switchCol" || playedCard.Value == "addFourSwitchCol")
                {
                    ChooseWildColor(playedCard);
                }

                Console.WriteLine($"Played: {playedCard.Color}-{playedCard.Value}");
                GamePile.Cards.Add(playedCard);
                p.Hand.Remove(playedCard);

                // 2. Apply Special Card Effects (Skip, Reverse, Draw)
                ApplyCardEffect(playedCard);

                return true;
            }
            else
            {
                Console.WriteLine("Cannot Play This Card!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return false;
            }
        }

        // ==========================================
        // NEW HELPER METHODS (Add these to GameEngine)
        // ==========================================

        static void NextTurn()
        {
            currentPlayerIndex += playDirection;
            // Loop back around if we go out of bounds
            if (currentPlayerIndex >= _players.Count) currentPlayerIndex = 0;
            if (currentPlayerIndex < 0) currentPlayerIndex = _players.Count - 1;
        }

        static void ApplyCardEffect(Card card)
        {
            if (card.Value == "switchDir")
            {
                playDirection *= -1; // Reverses the turn order
                Console.WriteLine("Direction Reversed!");
                if (_players.Count == 2) NextTurn(); // In a 2-player game, reverse acts as a skip
            }
            else if (card.Value == "block")
            {
                Console.WriteLine("Next player is skipped!");
                NextTurn(); // Advances the index an extra time to skip
            }
            else if (card.Value == "addTwo")
            {
                Console.WriteLine("Next player draws 2 and is skipped!");
                NextTurn(); // Move to the target player
                ForceDraw(_players[currentPlayerIndex], 2);
            }
            else if (card.Value == "addFourSwitchCol")
            {
                Console.WriteLine("Next player draws 4 and is skipped!");
                NextTurn(); // Move to the target player
                ForceDraw(_players[currentPlayerIndex], 4);
            }
        }

        static void ForceDraw(Player p, int count)
        {
            Console.WriteLine($"{p.Name} must draw {count} cards!");
            for (int i = 0; i < count; i++)
            {
                if (Deck.Cards.Count > 0)
                {
                    p.Hand.Add(Deck.Cards[0]);
                    Deck.Cards.RemoveAt(0);
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void ChooseWildColor(Card card)
        {
            while (true)
            {
                Console.WriteLine("\nChoose a new color:");
                for (int i = 0; i < Deck.Colors.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {Deck.Colors[i]}");
                }
                Console.Write(">>> ");

                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= Deck.Colors.Count)
                {
                    card.Color = Deck.Colors[choice - 1]; // This is why we needed the Card.cs fix!
                    break;
                }
                Console.WriteLine("Invalid color choice. Try again.");
            }
        }



        static void PlaceFirstCard()
        {
            GamePile.Cards.Add(Deck.Cards[0]);
        }


        static bool DrawCard(Player p)
        {
            foreach (Card card in p.Hand)
            {
                if (PileCardCompare(card))
                {
                    Console.WriteLine("May only draw card if no playable cards available in hand.");
                    return false;
                }
            }

            if (Deck.Cards.Count == 0)
            {
                Console.WriteLine("No cards left in the deck to draw!");
                return false;
            }

            Card drawnCard = Deck.Cards[0];
            p.Hand.Add(drawnCard);
            Deck.Cards.RemoveAt(0);
            Console.WriteLine($"Card Drawn: {drawnCard.Color}-{drawnCard.Value}");

            // Rule check: If the drawn card is playable, offer to play it immediately
            if (PileCardCompare(drawnCard))
            {
                Console.Write("The drawn card can be played! Play it now? (Y/N): ");
                string choice = Console.ReadLine().Trim().ToUpper();
                if (choice == "Y" || choice == "YES")
                {
                    PlayCard(drawnCard, p);
                }
            }
            else
            {
                Console.WriteLine("Drawn card cannot be played. Ending turn.");
            }

            return true; // Turn ends
        }

        static bool PileCardCompare(Card card)
        {
            Card topCard = GamePile.Cards[GamePile.Cards.Count - 1];
            // Matches by color, value, or if the played card is a Wild card ("black")
            return (card.Color == topCard.Color || card.Value == topCard.Value || card.Color == "black");
        }

    }
        
}
