

namespace Uno_Project
{

    class Program
    {
        static void Main()
        {
            Deck cardDeck = new Deck();

            Console.WriteLine(Deck.Cards.Count);




        }
    }

            for(int i = 0; i < cardDeck.Cards.Length; i++)
            {
                Console.WriteLine($"[{i}] color: {cardDeck.Cards[i].Color}, ");
            }
        }
    }

}
   