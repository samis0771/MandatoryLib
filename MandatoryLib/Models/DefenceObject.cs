using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryLib.Models
{
    //DefenceObject inherit from WorldObject because they share common properties or characteristics with WorldObject, such as being placed in the world, being removable, and having additional properties like hit points, range, and description.
    public class DefenceObject : WorldObject
    {
        public int ReduceHitPoints { get; set; }
     
        public DefenceObject(bool removable, bool lootable, string name, string description, int x, int y, int reduceHitPoints)
            : base(removable, lootable, name, description, x, y)
        {
            ReduceHitPoints = reduceHitPoints;
        }
    }
}

