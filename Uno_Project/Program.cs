

namespace Uno_Project
{

    class Program
    {
        static void Main()
        {
            Deck cardDeck = new Deck();


            for(int i = 0; i < cardDeck.Cards.Length; i++)
            {
                Console.WriteLine($"[{i}] color: {cardDeck.Cards[i].Color}, ");
            }
        }
    }

}
   