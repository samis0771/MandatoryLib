using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryLib.LoggerAndPrintMSG;
using MandatoryLib.Models;

namespace MandatoryLib.ObserverClasses.DeadObserver
{
    public class DeadObserver:IDeadObserver
    {
        private World world { get; set; }
        public List<Creature> DeadCreatures { get; private set; }

        public DeadObserver(World w)
        {
            world = w;
            DeadCreatures = new List<Creature>();
        }

        public void CreatureTracker(Creature creature)
        {
            creature.DeadObserver.Add(this);
        }


        public void WhenDead(Creature creature)
        { 
            DeadCreatures.Add(creature);
            world.Creatures.Remove(creature);
            Console.WriteLine();
            Logger.WriteLog($"*RESULTS*---{creature.Name} died at position:({creature.Position.X},{creature.Position.Y})---*RESULTS*");
            ;
        }
    }
}
