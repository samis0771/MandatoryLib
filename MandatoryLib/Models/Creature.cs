using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryLib.AttackDefenceHandler;
using MandatoryLib.LoggerAndPrintMSG;
using MandatoryLib.ObserverClasses.DeadObserver;
using Microsoft.Extensions.Logging;

namespace MandatoryLib.Models
{
    public enum Movment
    {
        Creature,
        Outside,
        Completion
    }
    public class Creature
    {
        public int Id { get; set; }
        private static int newId = 1;
        public string Name { get; set; }
        public int LifePoints { get; set; } 
        public int MaxLoadoutCarry { get; set; }
        public Position Position { get; set; }
        public List<AttackObject> Attacks { get; set; } 
        public List<DefenceObject> Defences { get; set; }
        public IAttackHandler AttackHandler { get; set; }
        public IDefenceHandler DefenceHandler { get; set; }
        public List<IDeadObserver> DeadObserver { get; set; }


        //Constructor
        public Creature(string name, int lifePoints, int maxLoadoutCarry, int x, int y)
        {
            Id = newId++;
            Name = name;
            LifePoints = lifePoints;
            MaxLoadoutCarry = maxLoadoutCarry;
            Position = new Position(x, y);
            Attacks = new List<AttackObject>();
            Defences = new List<DefenceObject>();
            AttackHandler = new AttackHandler();
            DefenceHandler = new DenfenceHandler();
            DeadObserver = new List<IDeadObserver>();
        }

        public void Hit(Creature target)
        {
            // Logic for attacking another creature
            int totalDamege = AttackHandler.CalculateDamageOutput(Attacks);
            Logger.WriteLog($"*STATUS*---Creature {Name} hit {target.Name}!");
            target.ReceiveHit(totalDamege);
        }

        public void ReceiveHit(int damage)
        {
            // Logic for receiving damage
            int totalDefence = DefenceHandler.CalulateDefenceOutput(Defences);
            LifePoints -= Math.Max(damage - totalDefence, 0); 
            if (LifePoints <= 0)
            {
                Die();
            }
            else
            {
                Logger.WriteLog($"*STATUS*---Creature {Name} now has {LifePoints}!");
            }
        }

        public void Pick(WorldObject obj)
        {
            // Logic for picking up a world object
            if (obj.Lootable==true)
            {
                if (obj is AttackObject attackObj)
                {
                    if (Attacks.Count + Defences.Count < MaxLoadoutCarry)
                    {
                        obj.NotifyPicked();
                        Attacks.Add(attackObj);
                        Logger.WriteLog($"*INFO*---Creature {Name} picked up {attackObj.Name},{attackObj.Description}, Damage:{attackObj.HitPoints}, Range:{attackObj.Range}!");
                    }
                    else
                    {
                        Logger.WriteLog($"*INFO*---Cannot add {attackObj.Name}; max loadout reached!");
                    }
                }

                else if (obj is DefenceObject defenceObj)
                {
                    if (Defences.Count + Attacks.Count < MaxLoadoutCarry)
                    {
                        obj.NotifyPicked();
                        Defences.Add(defenceObj);
                        Logger.WriteLog(@$"*INFO*---Creature {Name} picked up {defenceObj.Name},{defenceObj.Description}, Reduce Damege:{defenceObj.ReduceHitPoints}n\");
                    }
                    else
                    {
                        Logger.WriteLog($"*INFO*---Cannot add {defenceObj.Name}; max loadout reached!");
                    }
                }
                else
                {
                    // Additional logic for other types of world objects to be picked up
                    // e.g. increase life points, add magic, etc.

                }
                obj.Lootable = false; // Mark the object as not removable after being picked up
            }
            else
            {
                Logger.WriteLog("*INFO*---This item is not lootable!");
            }
        }

        public void Die()
        {
            // Logic for when the creature dies
            // Print a message indicating the creature's death
            Logger.WriteLog($"*DEATH*---Creature {Name} has died!");
            foreach (var observer in DeadObserver)
            {
                observer.WhenDead(this);   
            }

        }




        public Movment moves(int x, int y, World world)
        {
            int movedX = this.Position.X + x;
            int movedY= this.Position.Y + y;

            if (world.InWorldLocation(movedX, movedY, out Movment movment, out string thing))
            {
                this.Position.X = movedX;
                this.Position.Y = movedY;
                Logger.WriteLog($"*MOVEMENT*---Creature {Name} moved to ({this.Position.X},{this.Position.Y})");
            }
            else
            {
                 if(movment==Movment.Creature)
                 {
                     Logger.WriteLog($"*COMBAT*---Creature {Name} tried to move into a position where there already is another creature! {Name} makes a hit but stays in the same position:({this.Position.X},{this.Position.Y})");
                 }
                 else
                 {
                     Logger.WriteLog($"*MOVEMENT*---Creature {Name} tried to move outside the map ({this.Position.X},{this.Position.Y})");
                 }
            }

            return movment;
        }
    }
}
