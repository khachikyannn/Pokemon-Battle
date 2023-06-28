using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Net.Mime.MediaTypeNames;

namespace Pokemon_Battle
{
    internal class Heal : Ability
    {
        bool active; 

        private int heal;

        public Heal(int heal)
        {
            this.heal = heal;
        }

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
        int count = 0;

        public override void Activate(Pokemon activator, Pokemon enemy)
        {
            active = true;
        }

        public override void Update(Pokemon activator, Pokemon enemy)
        {
            if (active && count < 3)
            {
                enemy.Health = enemy.Health - 30;
            }

            count++;

            active = false;
        }
    }

    internal class Dodge : Ability
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

    internal class Lightning : Ability
    {
        int damage;

        public Lightning(int damage)
        {
            this.damage = damage;
        }

        public override void Activate(Pokemon activator, Pokemon enemy)
        {
            enemy.Damage(activator, damage);            
        }
    }

    internal class Stun : Ability
    { 
        public override void Activate(Pokemon activator, Pokemon enemy)
        {
            enemy.IsStunned = true;
        }

        public override void Update(Pokemon activator, Pokemon enemy)
        {
            enemy.IsStunned = false;
        }
    }

    internal abstract class Ability
    {
        public abstract void Activate(Pokemon activator, Pokemon enemy);
        public virtual void Update(Pokemon activator, Pokemon enemy) { }
        public virtual int ModifyDamage(int damage, Pokemon activator, Pokemon enemy) { return damage; }
    }

    internal class Pokemon
    {
        private string name;

        private int health;

        public bool IsStunned = false;

        public Ability[] pokemonAbilities;

        public void Damage(Pokemon enemy, int damage)
        {
            for (int i = 0; i < pokemonAbilities.Length; i++)
            {
                damage = pokemonAbilities[i].ModifyDamage(damage, this, enemy);
            }

            health -= damage;
        }

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

        public Pokemon(string name, int health, params Ability[] pokemonAbilities)
        {
            this.name = name;

            this.health = health;

            this.pokemonAbilities = pokemonAbilities;
        }

        public Pokemon[] PokemonList()
        {
            Pokemon[] pokemonArray = new Pokemon[10];

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

            return pokemonArray;
        }
    }

    internal class Trainer
    {
        internal class Flee : Ability
        {
            bool leaveGame;

            public override void Activate(Pokemon activator, Pokemon enemy)
            {
                leaveGame = true;
            }

            public override void Update(Pokemon activator, Pokemon enemy)
            {
                if (leaveGame)
                {
                    Console.WriteLine("Player Has Fled.");
                }
            }
        }

        private Pokemon[] allPokemon;

        public Trainer(Pokemon[] allPokemon)
        {
            this.allPokemon = allPokemon;
        }
    }
}
