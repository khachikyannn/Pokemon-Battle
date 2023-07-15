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

            pokemonArray[3] = new Pokemon("Skitty", 300, new Heal(50), new Stun(), new Lightning(75));

            pokemonArray[4] = new Pokemon("Pikachu", 500, new Heal(100), new Stun(), new Lightning(100), new Poison(), new Dodge());

            pokemonArray[5] = new Pokemon("Lechonk", 500, new Heal(100), new Stun(), new Lightning(85), new Poison(), new Dodge());

            pokemonArray[6] = new Pokemon("Breloom", 300, new Stun(), new Heal(50), new Lightning(50));

            pokemonArray[7] = new Pokemon("Grookey", 300, new Heal(75), new Poison(), new Dodge());

            pokemonArray[8] = new Pokemon("Salandit", 300, new Lightning(100), new Stun(), new Dodge());

            pokemonArray[9] = new Pokemon("Tranquil", 500, new Heal(50), new Stun(), new Lightning(125), new Poison(), new Dodge());

            pokemonArray[10] = new Pokemon("JigglyPuff", 300, new Lightning(100));
        }
        public static Pokemon[] pokemonArray = new Pokemon[11];

        public static int getPokemonChoice(Pokemon[] pokemonArray, string pokemonChoice)
        {
            int pickedPokemon = 0;

            for (int i = 0; i < pokemonArray.Length; i++)
            {
                if (pokemonChoice == pokemonArray[i].Name)
                {
                    pickedPokemon = i;

                    return pickedPokemon;
                }
                else
                {
                    Console.WriteLine("Pick Valid Option.");
                    pokemonChoice = Console.ReadLine();
                }
            }
                                ////////////////////////////////////////////////////FIX NOT RECOGNIZING NAMES
            return pickedPokemon;
        }

        public static void printPokemons(Pokemon[] pokemonArray)
        {
            for (int i = 0; i < pokemonArray.Length; i++)
            {
                Console.WriteLine(pokemonArray[i].printPokemon());
            }
        }

        public static void DisplayAttacks(Pokemon[] pokemonAttacks)
        {
            for(int i = 0; i < pokemonArray.Length; i++)
            {
                Console.WriteLine($"Available Attacks: {pokemonAttacks[i].printPokemonAbilities()}");
            }
        }
       
        static void Main()
        {
          
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            string playAgain = "yes";

            MakePokemons();

            Trainer[] PokemonTrainers;

            //Each "player" gets a pokemon (store that pokemon)
            //Print out the abilities they have
            //The person will choose the attack or ability
            //Then use that ability on the pokemon against the enemy

            while (playAgain == "yes")
            {
                Console.WriteLine("<------------------------------------------->");

                Console.WriteLine("Pick Your First Pokemon");
                printPokemons(pokemonArray);
                string firstPokemonChoice = Console.ReadLine();
                int indexFirstPokemon = getPokemonChoice(pokemonArray, firstPokemonChoice);

                //do
                //{
                //    Console.WriteLine("Pick Valid Pokemon");
                //    firstPokemonChoice = Console.ReadLine();
                //}
                //while (firstPokemonChoice != indexFirstPokemon.ToString());


                Console.WriteLine("Pick Your Second Pokemon");
                printPokemons(pokemonArray);
                string secondPokemonChoice = Console.ReadLine();
                int indexSecondPokemon = getPokemonChoice(pokemonArray, secondPokemonChoice);

                //do
                //{
                //    Console.WriteLine("Pick Valid Pokemon");
                //    secondPokemonChoice = Console.ReadLine();
                //}
                //while (secondPokemonChoice != indexSecondPokemon.ToString());


                Console.WriteLine("Pick Your Type Of Attack For First Pokemon");

                DisplayAttacks(pokemonArray);

                string attackPokemonChoice = Console.ReadLine();

                int mainAttackChoice = int.Parse(attackPokemonChoice);


                Console.WriteLine("Pick Your Type Of Attack For Second Pokemon");
                DisplayAttacks(pokemonArray);
                attackPokemonChoice = Console.ReadLine();
                int secondAttackChoice = int.Parse(attackPokemonChoice);

                pokemonArray[indexFirstPokemon].pokemonAbilities[mainAttackChoice].Activate(pokemonArray[indexFirstPokemon], pokemonArray[indexSecondPokemon]);

                Console.WriteLine("Play Again?");
                playAgain = Console.ReadLine();
            }
        }
    }
}