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

        public bool Ultimate
        {
            get 
            {
                return damage >= 100;
            }  
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
