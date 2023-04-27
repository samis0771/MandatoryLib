using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryLib.Models
{
    //AttackObject inherit from WorldObject because they share common properties or characteristics with WorldObject, such as being placed in the world, being removable, and having additional properties like hit points, range, and description.
    public class AttackObject : WorldObject
    {
        public int HitPoints { get; set; }
        public int Range { get; set; }


        public AttackObject(bool removable, bool lootable, string name, string description, int x, int y, int hitPoints, int range)
            : base(removable, lootable, name, description, x,y)
        {
            HitPoints = hitPoints;
            Range = range;
        }
    }
}
