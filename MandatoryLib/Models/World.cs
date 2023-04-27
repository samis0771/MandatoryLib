using System.Configuration;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using MandatoryLib.LoggerAndPrintMSG;
using MandatoryLib.ObserverClasses.DeadObserver;
using MandatoryLib.ObserverClasses.WorldObjectObserver;

namespace MandatoryLib.Models

{
    public class World
    {
        // The maximum size of the world in the X and Y dimensions
        public int MaxSizeX { get; set; }
        public int MaxSizeY { get; set; }

        // A list of all creatures in the world
        public List<Creature> Creatures { get; set; }

        // A list of all objects in the world
        public List<WorldObject> Objects { get; set; }
       
        // An observer that tracks dead creatures
        public DeadObserver DeadObserver { get; private set; }

        // An observer that tracks changes to world objects
        private WorldObjectObserver _observer;

        // Constructor for creating a new world with a given maximum size
        public World(int maxSizeX, int maxSizeY)
        {
            MaxSizeX = maxSizeX;
            MaxSizeY = maxSizeY;

            // Initialize the list of creatures and objects to be empty
            Creatures = new List<Creature>();
            Objects = new List<WorldObject>();

            // Create the dead observer and world object observer
            DeadObserver = new DeadObserver(this);
            _observer = new WorldObjectObserver(this);
        }


        // Adds a creature to the world at the specified position
        public void CreatureAddToWorld(Creature creature)
        {
            // Check if the creature is within the boundaries of the world
            if (InWorldLocation(creature.Position.X, creature.Position.Y, out _, out _))
            {
                // Add the creature to the dead observer's tracker
                DeadObserver.CreatureTracker(creature);
               // Add the creature to the list of creatures in the world
               Creatures.Add(creature);
            }
            else
            {
                // Throw an exception if the creature is not within the boundaries of the world
                throw new ArgumentException(
                    $"The creature {creature.Name} is given a invalid position;({creature.Position.X},{creature.Position.Y})");
            }
        }

        // Adds an object to the world at the specified position

        public void ObjectAddToWorld(WorldObject obj)
        {
            // Check if the object is within the boundaries of the world,
            //'OUT' is used to discard or ignore specific return values from the method
            if (InWorldLocation(obj.Position.X, obj.Position.Y, out _, out _))
            {
                // Register the object with the world object observer
                obj.RegObserver(_observer);
                // Add the object to the list of objects in the world
                Objects.Add(obj);
            }
            else
            {
                // Throw an exception if the object is not within the boundaries of the world
                throw new ArgumentException(
                    $"The object {obj.Name} is given a invalid position;({obj.Position.X},{obj.Position.Y})");
            }

        }

        public void RemoveWorldObject(WorldObject obj)
        {
            // Unregister the object with the world object observer
            obj.UnRegObserver(_observer);
            // Remove the object from the list of objects in the world
            Objects.Remove(obj);
        }

        //'OUT' is used to discard or ignore specific return values from the method.
        public bool InWorldLocation(int x, int y, out Movment movment, out string NameOfthing)
        {
            NameOfthing = null;
            if (x < 0 || x >= MaxSizeX || y < 0 || y >= MaxSizeY)
            {
                movment = Movment.Outside;
                return false;
            }

            Creature CreaturesInWorld = Creatures.FirstOrDefault(c => c.Position.X == x && c.Position.Y == y);
            if (CreaturesInWorld != null)
            {
                movment = Movment.Creature;
                return false;
            }

            movment = Movment.Completion;
            return true;
        }


        public void GameRounds(int rounds)
        {
            Logger.WriteLog("*---------------NEW GAME---------------*");
            for (int i = 1; i < rounds; i++)
            {
                if (Creatures.Count > 1)
                { 
                    Logger.WriteLog($"Round:{i} - Make a move!");
                List<Creature> c2 = new List<Creature>(Creatures);
                foreach (var creature in c2)
                {
                    //This will check if creature is still in game, and not dead.
                    if (!Creatures.Contains(creature))
                    {
                        continue;
                    }

                    int x = 0;
                    int y = 0;
                    bool ValidInput = false;

                    while (!ValidInput)
                    {
                        Console.WriteLine();
                        Logger.WriteLog($"*NEW TURN*---Creature {creature.Name} is located at ({creature.Position.X},{creature.Position.Y}), move the creature in any direction now!");
                        ConsoleKeyInfo move = Console.ReadKey();
                        
                        switch (move.Key)
                        {
                            case ConsoleKey.UpArrow: // Up arrow key
                                y = 1;
                                ValidInput = true;
                                break;
                            case ConsoleKey.LeftArrow: // Left arrow key
                                x = -1;
                                ValidInput = true;
                                break;
                            case ConsoleKey.DownArrow: // Down arrow key
                                y = -1;
                                ValidInput = true;
                                break;
                            case ConsoleKey.RightArrow: // Right arrow key
                                x = 1;
                                ValidInput = true;
                                break;
                            default:
                                Logger.WriteLog("!!!Invalid input. Please enter arrow keys (↑ / ← / ↓ / →)!!!");
                                break;
                        }
                    }

                    Movment movment= creature.moves(x,y,this);
                    //Checks if there already is a creature or object on the new position  
                    if (movment == Movment.Creature)
                    {
                            // Find the first creature in the collection that meets the specified conditions
                            // Exclude the current creature from consideration by checking if its Id is not equal to the Id of the creature being evaluated
                            // Check if the creature's position is located a certain distance away from the current creature's position, as indicated by the values of 'x' and 'y'
                            Creature target = Creatures.FirstOrDefault(c =>
                            c.Id != creature.Id && c.Position.X == creature.Position.X + x &&
                            c.Position.Y == creature.Position.Y + y);
                        if (target != null)
                        {
                            if (creature.Attacks.Count>0)
                            {
                                creature.Hit(target);
                            }
                            else
                            {
                                Logger.WriteLog($"Creature {creature.Name} does not have a weapon, thus can't hit {target.Name}!");
                            }
                            
                        }
                    }
                    else
                    {
                        WorldObject Object = Objects.FirstOrDefault(o => o.Position.X == creature.Position.X && o.Position.Y == creature.Position.Y);
                        if (Object!=null)
                        {
                            creature.Pick(Object);
                        }
                    }
                }

                Console.WriteLine();
                }
                else
                {
                    Logger.WriteLog($"-----------------GAME OVER! {Creatures.First().Name} WON!-----------------");
                }
            }
        }
    }
}