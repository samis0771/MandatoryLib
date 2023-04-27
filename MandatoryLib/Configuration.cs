using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryLib
{
    public class Configuration
    {
        //World
        public int MaxSizeX { get; set; }
        public int MaxSizeY { get; set; }
        //Creatrue
        public string CreatureName { get; set; }
        public int LifePoints { get; set; }
        public int CreatureposX { get; set; }
        public int CreatureposY { get; set; }
        //Weapon
        public bool weaponRemovable { get; set; }
        public bool weaponLootable { get; set; }
        public string weaponName { get; set; }
        public int WeaponposX { get; set; }
        public int WeaponposY { get;set; }
        public int HitPoints { get; set; }
        public int WeaponRange { get; set; }
        public  string WeaponDescription { get; set; }
        //Defence
        public bool defenceRemovable { get; set; }
        public bool defenceLootable { get;set; }
        public string defenceName { get; set;}
        public int defencePosX { get; set;}
        public int defencePosY { get; set;}
        public int reduceHitpoints { get; set; }
        public string defenceDescription { get; set; }
    }
}
