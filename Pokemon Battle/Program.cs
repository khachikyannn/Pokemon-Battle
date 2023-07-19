using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace Pokemon_Battle
{
    internal class Program
    {
        static void MakePokemons()
        { 
            pokemonArray[0] = new Pokemon("JigglyPuff", 300, new Lightning(100));

            pokemonArray[1] = new Pokemon("Grookey", 300, new Heal(75), new Poison(), new Dodge());

            pokemonArray[2] = new Pokemon("Mew", 300, new Heal(50), new Lightning(75), new Dodge());

            pokemonArray[3] = new Pokemon("Skitty", 300, new Heal(50), new Stun(), new Lightning(75));

            pokemonArray[4] = new Pokemon("Goomy", 300, new Lightning(75), new Poison(), new Dodge());

            pokemonArray[5] = new Pokemon("Paras", 300, new Heal(50), new Lightning(100), new Dodge());

            pokemonArray[6] = new Pokemon("Breloom", 300, new Stun(), new Heal(50), new Lightning(50));

            pokemonArray[7] = new Pokemon("Salandit", 300, new Lightning(100), new Stun(), new Dodge());

            pokemonArray[8] = new Pokemon("Lechonk", 500, new Heal(100), new Stun(), new Lightning(85), new Poison(), new Dodge());

            pokemonArray[9] = new Pokemon("Pikachu", 500, new Heal(100), new Stun(), new Lightning(100), new Poison(), new Dodge());

            pokemonArray[10] = new Pokemon("Tranquil", 500, new Heal(50), new Stun(), new Lightning(125), new Poison(), new Dodge());   
        }
        public static Pokemon[] pokemonArray = new Pokemon[11];

        public static int GetPokemonChoice(Pokemon[] pokemonArray, string pokemonChoice)
        {
            int pickedPokemon = 0;

            while (true)
            {
                for (int i = 0; i < pokemonArray.Length; i++)
                {
                    if (pokemonChoice == pokemonArray[i].Name)
                    {
                        pickedPokemon = i;

                        return pickedPokemon;
                    }
                }
                Console.WriteLine("Retry");
                pokemonChoice = Console.ReadLine();
            }               
        }

        public static void PrintPokemons(Pokemon[] pokemonArray)
        {
            for (int i = 0; i < pokemonArray.Length; i++)
            {
                Console.WriteLine(pokemonArray[i].PrintPokemon());
            }
        }

        public static void DisplayAttacks(Pokemon[] pokemonAttacks, int indexOfPokemon)
        {
            Console.WriteLine($"Available Attacks: {pokemonAttacks[indexOfPokemon].PrintPokemonAbilities()}");
        }
       
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            string playAgain = "yes";

            MakePokemons();

            Trainer[] PokemonTrainers;

            while (playAgain == "yes")
            {
                Console.WriteLine("<------------------------------------------->");

                Console.WriteLine("Pick Your First Pokemon");
                PrintPokemons(pokemonArray);
                string firstPokemonChoice = Console.ReadLine();
                int indexFirstPokemon = GetPokemonChoice(pokemonArray, firstPokemonChoice);

                Console.WriteLine("----------");

                Console.WriteLine("Pick Your Second Pokemon");
                PrintPokemons(pokemonArray);
                string secondPokemonChoice = Console.ReadLine();
                int indexSecondPokemon = GetPokemonChoice(pokemonArray, secondPokemonChoice);

                Console.WriteLine("----------");

                while (pokemonArray[indexFirstPokemon].Health != 0 || pokemonArray[indexSecondPokemon].Health != 0)
                {
                    Console.WriteLine("Pick Your Type Of Attack For First Pokemon");
                    DisplayAttacks(pokemonArray, indexFirstPokemon);
                    string attackPokemonChoice = Console.ReadLine();
                    if(attackPokemonChoice == "Heal")
                    {
                        indexFirstPokemon = 0;
                    }
                    else if(attackPokemonChoice == "Lightning")
                    {
                        indexFirstPokemon = 1;
                    }
                    else if(attackPokemonChoice == "Dodge")
                    {
                        indexFirstPokemon = 2;
                    }
                    else if(attackPokemonChoice == "Poison")
                    {
                        indexFirstPokemon = 3;
                    }
                    else if(attackPokemonChoice == "Stun")
                    {
                        indexFirstPokemon = 4;
                    }

                    Console.WriteLine("----------");

                    Console.WriteLine("Pick Your Type Of Attack For Second Pokemon");
                    DisplayAttacks(pokemonArray, indexSecondPokemon);
                    attackPokemonChoice = Console.ReadLine();
                    if (attackPokemonChoice == "Heal")
                    {
                        indexSecondPokemon = 0;
                    }
                    else if (attackPokemonChoice == "Lightning")
                    {
                        indexSecondPokemon = 1;
                    }
                    else if (attackPokemonChoice == "Dodge")
                    {
                        indexSecondPokemon = 2;
                    }
                    else if (attackPokemonChoice == "Poison")
                    {
                        indexSecondPokemon = 3;
                    }
                    else if (attackPokemonChoice == "Stun")
                    {
                        indexSecondPokemon = 4;
                    }

                    Console.WriteLine("----------");

                    pokemonArray[indexFirstPokemon].pokemonAbilities[indexFirstPokemon].Activate(pokemonArray[indexFirstPokemon], pokemonArray[indexSecondPokemon]);

                    pokemonArray[indexSecondPokemon].pokemonAbilities[indexSecondPokemon].Activate(pokemonArray[indexSecondPokemon], pokemonArray[indexFirstPokemon]);

                    Console.WriteLine($"Player 1 Health: {pokemonArray[indexFirstPokemon].Health}");

                    Console.WriteLine($"Player 2 Health: {pokemonArray[indexSecondPokemon].Health}");

                    Console.WriteLine("----------");
                }

                ///////////////////////////////////ADD END SCREEN

                Console.WriteLine("Play Again?");
                playAgain = Console.ReadLine();
            }
        }
    }
}