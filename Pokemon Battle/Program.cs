namespace Pokemon_Battle
{
    internal class Program
    { 
        static void Main()
        {
            Trainer myTrainer = new Trainer();

            string playAgain = "";

            while (playAgain == "yes")
            {
                Console.WriteLine("Pick Your First Pokemon");
                // display pokemon
                string firstPokemonChoice = Console.ReadLine();

                Console.WriteLine("Pick Your Second Pokemon");
                // display pokemon w/o first choice
                string secondPokemonChoice = Console.ReadLine();

                Console.WriteLine("Pick Your Type Of Attack For First Pokemon");
                // display attack choices 
                string attackPokemonChoice = Console.ReadLine();

                Console.WriteLine("Pick Your Type Of Attack For Second Pokemon");
                // display all attack choices
                attackPokemonChoice = Console.ReadLine();

                Console.WriteLine("Play Again?");
                playAgain = Console.ReadLine();
            }
        }
    }
}