using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.XPath;
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

        public override string Print()
        {
            return "Heal";
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

        public override string Print()
        {
            return "Poison";
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

        public override string Print()
        {
            return "Dodge";
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

        public override string Print()
        {
            return "Lightning";
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

        public override string Print()
        {
            return "Stun";
        }
    }

    internal abstract class Ability
    {
        public abstract void Activate(Pokemon activator, Pokemon enemy);
        public virtual void Update(Pokemon activator, Pokemon enemy) { }
        public virtual int ModifyDamage(int damage, Pokemon activator, Pokemon enemy) { return damage; }
        public abstract string Print();
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

        public string printPokemon()
        {
            string result = $"Name: {name}, Health: {health}, ";

            for (int i = 0; i < pokemonAbilities.Length; i++)
            {
                result += pokemonAbilities[i].Print();
                result += ", ";
            }

            return result;
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

            public override string Print()
            {
                return "Flee";
            }
        }

        private Pokemon[] allPokemon;

        public Trainer(Pokemon[] allPokemon)
        {
            this.allPokemon = allPokemon;
        }
    }
}
