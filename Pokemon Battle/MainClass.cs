using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Battle
{
    internal class Pokemon
    {
        private int health;

        private int damage;

        private bool ultimate;

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value < 0) Console.WriteLine("Pokemon Has Fainted.");
                if (value > 500) Console.WriteLine("Pokemon Is Too Tanky.");
                health = value;
            }
        }

        public int Damage
        {
            get
            {
                return damage;
            }
            set
            {
                damage = value;
            }
        }

        public int mainAttack
        {
            get
            {
                return mainAttack;
            }
        }

        public int secondaryAttack
        {
            get
            {
                return secondaryAttack;
            }
        }

        public bool Ultimate
        {
            get 
            {
                return damage >= 100;
            }  
        }

        public Pokemon[] pokemonList()
        {
            Pokemon myPokemon = new Pokemon();

            Pokemon[] pokemonArray = new Pokemon[10];

            string Mew = "Mew";

            pokemonArray[0] = new Pokemon(Mew);

            string Goomy = "Goomy";

            pokemonArray[1] = new Pokemon(Goomy);

            string Paras = "Paras";

            pokemonArray[2] = new Pokemon(Paras);

            string Skitty = "Skitty";

            pokemonArray[2] = new Pokemon(Skitty);

            string Pikachu = "Pikachu";

            pokemonArray[2] = new Pokemon(Pikachu);

            string Lechonk = "Lechonk";

            pokemonArray[2] = new Pokemon(Lechonk);

            string Breloom = "BreLoom";

            pokemonArray[2] = new Pokemon(Breloom);

            string Grookey = "Grookey";

            pokemonArray[2] = new Pokemon(Grookey);

            string Salandit = "Salandit";

            pokemonArray[2] = new Pokemon(Salandit);

            string Tranquil = "Tranquil";

            pokemonArray[2] = new Pokemon(Tranquil);

            string JigglyPuff = "JigglyPuff";

            pokemonArray[2] = new Pokemon(JigglyPuff);

            /////////////////////MAKE CONSTRUCTOR IN POKEMON CLASS

            return pokemonArray;
        }
    }

    internal class Trainer
    {
        private Pokemon[] allPokemon;

        public Trainer(Pokemon[] allPokemon)
        {
            this.allPokemon = allPokemon;
        }
    }
}
