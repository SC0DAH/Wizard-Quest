using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardQuest
{
    internal class Entity
    {
        public int HP = 3;
        public int CP = 2;
        public Entity(int stage)
        {
            HP *= stage; // stage 1 = HP van 3, stage 2 = HP van 6
            CP *= stage; // stage 1 = CP van 2, stage 2 = CP van 4
        }

        public bool TakeDamage(int amountOfDMG)
        {
            HP = Math.Max(0, HP - amountOfDMG);
            if (HP == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
