

namespace Uno_Project
{


    class Program
    {


        static void Checker(Card playedCard, Card pileCard)
        {

            if (playedCard.color == pileCard.color || playedCard.value == pileCard.value)
            {
                Console.WriteLine("Valid move");
            }
            else
            {
                Console.WriteLine("Invalid move");
            }

        }


        



        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            


        }





    }




}
   