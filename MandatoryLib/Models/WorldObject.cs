using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryLib.ObserverClasses.WorldObjectObserver;

namespace MandatoryLib.Models
{
    public class WorldObject
    {
        public int Id { get; }
        private static int newId = 1;

        public bool Removable { get; set; }
        public bool Lootable { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Position Position { get; set; }

        private List<IWorldObjectObserver> observers = new List<IWorldObjectObserver>();

        public WorldObject(bool removable, bool lootable, string name, string description, int x, int y)
        {
            Removable = removable;
            Lootable = lootable;
            Name = name;
            Description = description;
            Position = new Position(x, y);
            Id=newId++;
        }

        // Overload constructor to accept a Position object
        public WorldObject(bool removable, bool lootable, string name, string description, Position position)
        {
            Removable = removable;
            Lootable = lootable;
            Name = name;
            Description = description;
            Position = position;
        }

        public void RegObserver(IWorldObjectObserver observer)
        {
            observers.Add(observer);
        }

        public void UnRegObserver(IWorldObjectObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyPicked()
        {
            var objecttotell = new List<IWorldObjectObserver>(observers);

            foreach (var observer in objecttotell)
            {
                observer.ObjectLooted(this);
            }
        }

    }
}
