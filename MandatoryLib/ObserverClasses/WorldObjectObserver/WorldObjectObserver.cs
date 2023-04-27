using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryLib.Models;

namespace MandatoryLib.ObserverClasses.WorldObjectObserver
{
    public class WorldObjectObserver:IWorldObjectObserver
    {
        private World world;
        public List<WorldObject> RemovObjects { get;}

        public WorldObjectObserver(World w)
        {
            world = w;
            RemovObjects=new List<WorldObject>();
        }

        public void ObjectLooted(WorldObject worldObject)
        {
            world.RemoveWorldObject(worldObject);
            RemovObjects.Add(worldObject);
        }
    }
}
