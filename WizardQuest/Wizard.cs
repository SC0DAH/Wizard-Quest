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
        public string Name;
        public string Spell;
        int CombatPower = 2;
        int HitPoints = 10;
        int maxHP = 10;
        int HPUP = 2;
        int Stage = 1;
        

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
            entity = new Entity(Stage);
            Console.WriteLine($"You've reached stage {Stage}! An entity has spawned with {entity.HP}HP and {entity.CP}CP!");
            Thread.Sleep(1500);
            Interact();
        }

        private void Interact()
        {
            Console.WriteLine($"Choose what you want to do:\n1. Fight the entity ({CombatPower} damage)\n2. Heal up ({HPUP} HP)");
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
                HitPoints += HPUP;
            }
        }

        private void DoDamage()
        {
            bool isDead = entity.TakeDamage(CombatPower);
            Console.WriteLine($"You casted your {Spell} and did {CombatPower} damage!");
            if (isDead)
            {
                Console.WriteLine("This attack was brutal and killed the entity!");
            }
            else
            {
                Console.WriteLine($"The entity has {entity.HP}HP remaining.");
            }
        }
    }
}
