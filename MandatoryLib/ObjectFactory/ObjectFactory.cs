using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryLib.Models;

namespace MandatoryLib.ObjectFactory
{
    public class ObjectFactory:AbstractObjectFactory
    {
        public override Creature NewCreature(string name, int lifePoints, int maxLoadoutCarry, int x, int y)
        {
            return new Creature(name, lifePoints, maxLoadoutCarry, x, y);
        }

        public override AttackObject NewAttackObject(bool removable, bool lootable, string name, string description, int x, int y,
            int hitPoints, int range)
        {
            return new AttackObject(removable, lootable, name, description, x, y, hitPoints, range);
        }

        public override DefenceObject NewDefenceObject(bool removable, bool lootable, string name, string description, int x, int y,
            int reduceHitPoints)
        {
            return new DefenceObject(removable, lootable, name, description, x, y, reduceHitPoints);
        }
    }
}
