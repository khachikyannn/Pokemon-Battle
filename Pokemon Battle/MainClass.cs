using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        private int heal;

        public override string Name => "Heal";
        public Heal(int heal)
        {
            this.heal = heal;
        }

        public override void Activate(Pokemon activator, Pokemon enemy)
        {
            activator.Health += heal;
        }

        public override string Print()
        {
            return "Heal";
        }
    }

    internal class Poison : Ability
    {
        int count = 3;

        public override string Name => "Poison";
        public override void Activate(Pokemon activator, Pokemon enemy) ////////////////////////////FIX POISION NOT WORKING
        {
            count = 0;
        }

        public override void Update(Pokemon activator, Pokemon enemy)
        {
            if (count < 3)
            {
                enemy.Health = enemy.Health - 30;
            }

            count++;
        }

        public override string Print()
        {
            return "Poison";
        }
    }

    internal class Dodge : Ability
    {
        bool active;
        public override string Name => "Dodge";
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

        public override string Name => "Lightning";

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
        public override string Name => "Stun";
        public override void Activate(Pokemon activator, Pokemon enemy)
        {
            enemy.IsStunned = true;
        }

        public override int ModifyDamage(int damage, Pokemon activator, Pokemon enemy)
        {
            if (enemy.IsStunned == true)
            {
                damage = 0;
            }

            enemy.IsStunned = false;

            return damage;
        }

        public override string Print()
        {
            return "Stun";
        }
    }

    internal abstract class Ability
    {
        public abstract string Name { get; }
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
                health = value;
            }
        }

        public Pokemon(string name, int health, params Ability[] pokemonAbilities)
        {
            this.name = name;

            this.health = health;

            this.pokemonAbilities = pokemonAbilities;
        }

        public string PrintPokemon()
        {
            string result = $"Name: {name}, Health: {health}, ";

            for (int i = 0; i < pokemonAbilities.Length; i++)
            {
                result += pokemonAbilities[i].Print();
                result += ", ";
            }

            result = result.Remove(result.Length - 2);

            return result;
        }

        public string PrintPokemonAbilities()
        {
            string result = $"";
           
            for(int i = 0; i < pokemonAbilities.Length; i++)
            {
                result += pokemonAbilities[i].Print();
                result += ", ";
            }
            result = result.Remove(result.Length - 2);
            return result;
        }

        public int CheckPokemonAbilities(string choice)
        {
            for(int i = 0; i < pokemonAbilities.Length; i++)
            {
                if (choice == pokemonAbilities[i].Name)
                {
                    return i;
                }
            }

            return -1;
        }

        public void UpdateAbilities(Pokemon enemy)
        {
            for (int i = 0; i < pokemonAbilities.Length; i++)
            {
                pokemonAbilities[i].Update(this, enemy);
            }

            //pokemonAbilities[0].Update(activator, enemy);

            //pokemonAbilities[1].Update(activator, enemy);
        }
    }
}
