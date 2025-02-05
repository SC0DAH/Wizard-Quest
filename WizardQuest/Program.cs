namespace WizardQuest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Wizard! What do you want to name yourself?");
            string name = Console.ReadLine();
            Console.WriteLine("Choose a spell to cast during battle!");
            string spell = ChooseSpell();
            Wizard user01 = new Wizard(name, spell);
            Console.WriteLine($"Welcome {user01.Name}! You're set to go on adventure, your spell is {user01.Spell}!");
            Console.WriteLine($"Press enter to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public static string ChooseSpell()
        {
            Console.WriteLine($"1. {Spells.Fireball}\n2. {Spells.Waterwave}\n3. {Spells.Earthquake}\n4. {Spells.Poison}");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Ongeldige keuze, probeer opnieuw:");
            }
            string spellChoice = "";
            switch ((Spells)choice - 1)
            {
                case Spells.Fireball:
                    spellChoice = Spells.Fireball.ToString();
                    break;
                case Spells.Waterwave:
                    spellChoice = Spells.Waterwave.ToString();
                    break;
                case Spells.Earthquake:
                    spellChoice = Spells.Earthquake.ToString();
                    break;
                case Spells.Poison:
                    spellChoice = Spells.Poison.ToString();
                    break;
                default:
                    break;
            }
            return spellChoice;
        }
    }
}
