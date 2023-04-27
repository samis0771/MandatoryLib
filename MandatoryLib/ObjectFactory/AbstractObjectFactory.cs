using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryLib.Models;

namespace MandatoryLib.ObjectFactory
{
    public abstract class AbstractObjectFactory
    {
        public abstract Creature NewCreature(string name, int lifePoints, int maxLoadoutCarry, int x, int y);

        public abstract AttackObject NewAttackObject(bool removable, bool lootable, string name, string description,
            int x, int y, int hitPoints, int range);

        public abstract DefenceObject NewDefenceObject(bool removable, bool lootable, string name, string description,
            int x, int y, int reduceHitPoints);
        
    }
}
