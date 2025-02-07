using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WizardQuest
{
    internal class Wizard
    {
        static Entity entity;
        bool isEntityDead = false;

        public string Name;
        public string Spell;
        int CombatPower = 5;
        int HitPoints = 10;
        int maxHP = 10;
        int HPUP = 2;
        int Stage = 0;
        bool IsUserDead = false;
        

        public Wizard(string wizardName, string spellName)
        {
            Name = wizardName;
            Spell = spellName;
        }

        public void StartGame()
        {
            Console.WriteLine("Do you want to read the instructions? (Y/N)");
            string answer = Console.ReadLine().ToUpper();
            if (answer == "Y")
            {
                Console.WriteLine($"Welcome {Name}, you're entering an adventure where you'll have to reach the castle of doom!" +
                    "\nThis castle contains the book of spells! This will make you the best wizard the world has ever known." +
                    "\nOn the way there you'll have to pass 10 stages. In every stage you'll have to fight an entity!" +
                    "\nYou're starting out with 10HP and 5CP. Good luck on becoming the best wizard ever known.");
                Thread.Sleep(3000);
            }
            Console.WriteLine("Press enter to start your journey!");
            Console.ReadKey();
            Adventure();
        }

        private void Adventure()
        {
            Console.WriteLine("You're running towards the castle...");
            Thread.Sleep(1500);
            Stage++;
            entity = new Entity(Stage);
            isEntityDead = false; // new entity spawns
            Console.WriteLine($"You've reached stage {Stage}! An entity has spawned with {entity.HP}HP and {entity.CP}CP!");
            Thread.Sleep(1500);
            bool result = StageStart();
            if (result)
            {
                Console.WriteLine($"You died while on the search to the book of spells. You reached stage {Stage}");
            }
            else
            {
                Adventure();
            }
        }

        private bool StageStart()
        {
            while (true) // stage will continue until user or entity is dead
            {
                Console.WriteLine($"It's your turn {Name}! You have {HitPoints}HP and {CombatPower}CP");
                UserTurn();
                if (isEntityDead)
                {
                    break;
                }
                Console.WriteLine("It's the entity's turn now!");
                EntityTurn();
                if (IsUserDead)
                {
                    break;
                }
            }
            return IsUserDead;
        }

        private void UserTurn()
        {
            Console.WriteLine($"Choose what you want to do:\n1. Fight the entity ({CombatPower} damage)");
            if (HitPoints < maxHP) // only available when user is not at full health
            {
                Console.WriteLine($"2. Heal up ({HPUP}HP)");
            }
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
            {
                    Console.WriteLine("Bad choice, try again!");    
            }
            if (choice == 1)
            {
                DoDamage();
            }
            else
            {
                HealUp();
            }
        }

        private void EntityTurn()
        {
            TakeDamage();
        }

        private void DoDamage()
        {
            isEntityDead = entity.TakeDamage(CombatPower);
            Console.WriteLine($"You casted your {Spell} and did {CombatPower} damage!");
            if (isEntityDead)
            {
                Console.WriteLine($"This attack was brutal and killed the entity!\nCongrats on clearing stage {Stage}!");
            }
            else
            {
                Console.WriteLine($"The entity has {entity.HP}HP remaining.");
            }
        }

        private void HealUp()
        {
            HitPoints += HPUP; // math.min doen
            Console.WriteLine($"You've healed up {HPUP}HP, you now have {HitPoints}HP!");
        }

        private void TakeDamage()
        {
            string[] attacks = { "bite", "punch", "kick" };
            Random random = new Random();
            int index = random.Next(0, attacks.Length);
            HitPoints = Math.Max(0, HitPoints - entity.CP);
            Console.WriteLine($"The entity decided to {attacks[index]} you, dealing {entity.CP} damage!");
            if (HitPoints == 0)
            {
                Console.WriteLine("This attack was too much for you to handle! You died :c");
                IsUserDead = true;
            }
        }


    }
}
