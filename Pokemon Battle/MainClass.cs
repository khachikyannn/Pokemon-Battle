using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Pokemon_Battle
{
    internal class Heal : Ability
    {
        bool active; 

        private int heal;

        public override void Activate(Pokemon activator, Pokemon enemy)
        {
            active = true;
        }

        public override void Update(Pokemon activator, Pokemon enemy)
        {
            if (active)
            {
                activator.Health += heal;
            }

            active = false;
        }
    }

    internal class Poison : Ability
    {
        bool active;
        private int poisonDamage;

        public override void Activate(Pokemon activator, Pokemon enemy)
        {
            active = true;
        }

        public override void Update(Pokemon activator, Pokemon enemy)
        {
            if (active)
            {
                enemy.Health = enemy.Health - 30;
            }

            active = false;
        }
    }

    internal class Dodge : Ability
    {
        bool active;

        int damage;

        public override void Activate(Pokemon activator, Pokemon enemy)
        {
            active = true;
        }

        public override int ModifyDamage(int damage, Pokemon activator, Pokemon enemy)
        {
            if(active)
            {
                damage = 0;
            }

            active = false;

            return damage;
        }
    }

    internal class Lightning : Ability
    {
        bool active;
        int damage;

        public override void Activate(Pokemon activator, Pokemon enemy)
        {
            active = true;
        }

        public override int ModifyDamage(int damage, Pokemon activator, Pokemon enemy)
        {
            if (active)
            {
                damage = 75; 
            }

            active = false;

            return damage;
        }
    }

    internal class AttackSkip : Ability
    {
        bool active;
        
        public override void Activate(Pokemon activator, Pokemon enemy)
        {
            active = true;
        }

        public override int ModifyDamage(int damage, Pokemon activator, Pokemon enemy)
        {
            if(active)
            {
                damage = 0;
            }

            active = false;

            return damage;
        }
    }

    //class StealHealth : Ability
    //{
    //    int HealthToSteal;
    //    float percentageStolen;

    //    public override void Activate(Pokemon activator, Pokemon enemy)
    //    {
    //        enemy.Health -= HealthToSteal;
    //        activator.Health += (int)(HealthToSteal * percentageStolen);
    //    }
    //}

    internal abstract class Ability
    {
        public abstract void Activate(Pokemon activator, Pokemon enemy);
        public virtual void Update(Pokemon activator, Pokemon enemy) { }
        public virtual int ModifyDamage(int damage, Pokemon activator, Pokemon enemy) { return damage; }
    }

    internal class Pokemon
    {
        //bool stunned

        private string name;

        private int health;

        public string Name
        {
            get
            {
                return name;
            }
        }

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

        public Pokemon[] PokemonList()
        {
            Pokemon[] pokemonArray = new Pokemon[10];

            string Mew = "Mew";

            pokemonArray[0] = new Pokemon(Mew, 300);

            string Goomy = "Goomy";

            pokemonArray[1] = new Pokemon(Goomy, 300);

            string Paras = "Paras";

            pokemonArray[2] = new Pokemon(Paras, 300);

            string Skitty = "Skitty";

            pokemonArray[3] = new Pokemon(Skitty, 300);

            string Pikachu = "Pikachu";

            pokemonArray[4] = new Pokemon(Pikachu, 300);

            string Lechonk = "Lechonk";

            pokemonArray[5] = new Pokemon(Lechonk, 300);

            string Breloom = "BreLoom";

            pokemonArray[6] = new Pokemon(Breloom, 300);

            string Grookey = "Grookey";

            pokemonArray[7] = new Pokemon(Grookey, 300);

            string Salandit = "Salandit";

            pokemonArray[8] = new Pokemon(Salandit, 300);

            string Tranquil = "Tranquil";

            pokemonArray[9] = new Pokemon(Tranquil, 300);

            string JigglyPuff = "JigglyPuff";

            pokemonArray[10] = new Pokemon(JigglyPuff, 300);

            return pokemonArray;
        }

        public Pokemon(string name, int health)
        {
            this.name = name;

            this.health = health;
        }
    }

    internal class Trainer
    {
        //internal class Flee : Ability
        //{
        //    bool leaveGame;

        //    public override void Activate(Pokemon activator, Pokemon enemy)
        //    {
        //        leaveGame = true;
        //    }

        //    public override void Update(Pokemon activator, Pokemon enemy)
        //    {
        //        if (leaveGame)
        //        {
        //            Console.WriteLine("Player Has Fled.");
        //        }
        //    }
        //}

        private Pokemon[] allPokemon;

        public Trainer(Pokemon[] allPokemon)
        {
            this.allPokemon = allPokemon;
        }
    }
}
