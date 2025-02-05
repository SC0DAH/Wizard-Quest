using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardQuest
{
    internal class Wizard
    {
        public string Name;
        public string Spell;

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
                Console.WriteLine($"Welcome ${Name}, you're entering an adventure where you'll have to reach the castle of doom!" +
                    "\nThis castle contains the book of spells! This will make you the best wizard the world has ever known." +
                    "\nOn the way there you'll have to pass 10 stages. In every stage you'll have to fight an entity!" +
                    "\nYou're starting out with 10HP and 5CP. Good luck on becoming the best wizard ever known.");
                Thread.Sleep(3000);
            }
            Console.WriteLine("Press enter to start your journey!");
            Console.ReadKey();
        }
    }
}
