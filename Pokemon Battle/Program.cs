using System.Security.Cryptography.X509Certificates;

namespace Pokemon_Battle
{
    internal class Program
    {
        static void MakePokemons()
        {
            pokemonArray[0] = new Pokemon("Mew", 300, new Heal(50), new Lightning(75), new Dodge());

            pokemonArray[1] = new Pokemon("Goomy", 300, new Lightning(75), new Poison(), new Dodge());

            pokemonArray[2] = new Pokemon("Paras", 300, new Heal(50), new Lightning(100), new Dodge());

            pokemonArray[3] = new Pokemon("Skitty", 300);

            pokemonArray[4] = new Pokemon("Pikachu", 300);

            pokemonArray[5] = new Pokemon("Lechonk", 300);

            pokemonArray[6] = new Pokemon("Breloom", 300);

            pokemonArray[7] = new Pokemon("Grookey", 300);

            pokemonArray[8] = new Pokemon("Salandit", 300);

            pokemonArray[9] = new Pokemon("Tranquil", 300);

            pokemonArray[10] = new Pokemon("JigglyPuff", 300);
        }
        public static Pokemon[] pokemonArray = new Pokemon[11];

        public static int getPokemonChoice(Pokemon[] pokemonArray, string pokemonChoice)
        {
            int pickedPokemon = 0;

            for (int i = 0; i < pokemonArray.Length; i++)
            {
                if (pokemonChoice == pokemonArray[i].ToString())
                {
                    pickedPokemon = i;
                }
            }

            return pickedPokemon;
        }

        public static void printPokemons(Pokemon[] pokemonArray)
        {
            for (int i = 0; i < pokemonArray.Length; i++)
            {
                Console.WriteLine(pokemonArray[i].printPokemon());
            }
        }

        public static void DisplayAttacks()
        {
            for(int i = 0; i < pokemonArray.Length; i++)
            {
                Console.WriteLine($"Available Attacks: {attacks}");
            }
        }
        public static Ability[] attacks;

        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            string playAgain = "yes";

            MakePokemons();

            Pokemon[] PokemonTrainers;

            //Each "player" gets a pokemon (store that pokemon)
            //Print out the abilities they have
            //The person will choose the attack or ability
            //Then use that ability on the pokemon against the enemy

            while (playAgain == "yes")
            {


                Console.WriteLine("Pick Your First Pokemon");
                printPokemons(pokemonArray);
                string firstPokemonChoice = Console.ReadLine();
                int indexFirstPokemon = getPokemonChoice(pokemonArray, firstPokemonChoice);
                int firstPickedPokemon = int.Parse(firstPokemonChoice);
                if (firstPickedPokemon == indexFirstPokemon)
                {
                    Console.WriteLine($"Final First Pokemon: {pokemonArray[firstPickedPokemon]}");
                }


                Console.WriteLine("Pick Your Second Pokemon");
                printPokemons(pokemonArray);
                string secondPokemonChoice = Console.ReadLine();
                int indexSecondPokemon = getPokemonChoice(pokemonArray, secondPokemonChoice);
                int secondPickedPokemon = int.Parse(secondPokemonChoice);
                if (secondPickedPokemon == indexSecondPokemon)
                {
                    Console.WriteLine($"Final Second Pokemon: {pokemonArray[secondPickedPokemon]}");
                }


                Console.WriteLine("Pick Your Type Of Attack For First Pokemon");
                DisplayAttacks();
                string attackPokemonChoice = Console.ReadLine();
                int mainAttackChoice = int.Parse(attackPokemonChoice);

                Console.WriteLine("Pick Your Type Of Attack For Second Pokemon");
                DisplayAttacks();
                attackPokemonChoice = Console.ReadLine();
                int secondAttackChoice = int.Parse(attackPokemonChoice);

                pokemonArray[indexFirstPokemon].pokemonAbilities[mainAttackChoice].Activate(pokemonArray[indexFirstPokemon], pokemonArray[indexSecondPokemon]);

                Console.WriteLine("Play Again?");
                playAgain = Console.ReadLine();
            }
        }
    }
}