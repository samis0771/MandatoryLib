using System.Diagnostics;
using MandatoryLib;
using MandatoryLib.Models;
using MandatoryLib.ObjectFactory;

Trace.Listeners.Add(new ConsoleTraceListener());

World world = new World(20, 20);

AbstractObjectFactory factory = new ObjectFactory();

Creature c1 = factory.NewCreature("Sami", 10, 1, 5, 5);
Creature c2 = factory.NewCreature("Monster", 95, 1, 5, 4);


world.CreatureAddToWorld(c1);
world.CreatureAddToWorld(c2);

AttackObject a1 = factory.NewAttackObject(true, true, "Stick", "Dangerous Stick", 6, 5, 95, 1);
AttackObject a2 = factory.NewAttackObject(true, true, "Somthing", "Somthing Weapon", 7, 5, 10, 1);

DefenceObject d1 = factory.NewDefenceObject(true, true, "Shield", "Light amour", 6, 4, 50);

world.ObjectAddToWorld(a1);
world.ObjectAddToWorld(a2);

world.ObjectAddToWorld(d1);

world.GameRounds(10);
