

namespace Uno_Project
{

    class Program
    {
        static void Main()
        {
            Deck cardDeck = new Deck();

            Console.WriteLine(Deck.Cards.Count);

            
            for(int i = 0; i<Deck.Cards.Count; i++)
            {
                if (Deck.Cards[i] is NumberCard)
                {
                    Console.WriteLine($"{Deck.Cards[i].Color}, {((NumberCard)Deck.Cards[i]).Number}");
                }
                
            }

        }
    }

}
   