using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MandatoryLib
{
    internal class Cofigstuff
    {
        protected const string CONFIG_FILE = "ConfigWorld.xml";

        public World(string configFilePath)
        {
            Configuration conf = new Configuration();
            String fullConfigFilename = configFilePath + @"\" + CONFIG_FILE;
            if (!File.Exists(fullConfigFilename))
            {
                throw new FileNotFoundException(fullConfigFilename);
            }
            XmlDocument configDoc = new XmlDocument();
            configDoc.Load(configFilePath + @"\" + CONFIG_FILE);

            /*
             * Read MaxSizeX
             */
            XmlNode MaxXNode = configDoc.DocumentElement.SelectSingleNode("MaxSizeX");
            if (MaxXNode != null)
            {
                String str = MaxXNode.InnerText.Trim();
                conf.MaxSizeX = Convert.ToInt32(str);
            }

            /*
             * Read MaxSizeY
             */
            XmlNode MaxYNode = configDoc.DocumentElement.SelectSingleNode("MaxSizeY");
            if (MaxYNode != null)
            {
                String str = MaxYNode.InnerText.Trim();
                conf.MaxSizeY = Convert.ToInt32(str);
            }

            /*
             * Read creature name
             */
            XmlNode nameNode = configDoc.DocumentElement.SelectSingleNode("CName");
            if (nameNode != null)
            {
                conf.CreatureName = nameNode.InnerText.Trim();
            }

            /*
             * Read LifePoints
             */
            XmlNode lifePointsNode = configDoc.DocumentElement.SelectSingleNode("LifePoints");
            if (lifePointsNode != null)
            {
                String str = lifePointsNode.InnerText.Trim();
                conf.LifePoints = Convert.ToInt32(str);
            }

            /*
             * Read creature X pos
             */
            XmlNode creatureXNode = configDoc.DocumentElement.SelectSingleNode("CX");
            if (creatureXNode != null)
            {
                String str = creatureXNode.InnerText.Trim();
                conf.CreatureposX = Convert.ToInt32(str);
            }

            /*
            * Read creature Y pos
            */
            XmlNode creatureYNode = configDoc.DocumentElement.SelectSingleNode("CY");
            if (creatureYNode != null)
            {
                String str = creatureYNode.InnerText.Trim();
                conf.CreatureposY = Convert.ToInt32(str);
            }

            /*
            * Read weaponRemovable
            */
            XmlNode WeaponRemovableNode = configDoc.DocumentElement.SelectSingleNode("WRemovable");
            if (WeaponRemovableNode != null)
            {
                String str = WeaponRemovableNode.InnerText.Trim();
                conf.weaponRemovable = Convert.ToBoolean(str);
            }

            /*
            * Read weaponLootable
            */
            XmlNode WeaponLootableNode = configDoc.DocumentElement.SelectSingleNode("WLootable");
            if (WeaponLootableNode != null)
            {
                String str = WeaponLootableNode.InnerText.Trim();
                conf.weaponLootable = Convert.ToBoolean(str);
            }

            /*
            * Read creature name
            */
            XmlNode WeaponnameNode = configDoc.DocumentElement.SelectSingleNode("WName");
            if (WeaponnameNode != null)
            {
                conf.weaponName = WeaponnameNode.InnerText.Trim();
            }

            /*
            * Read weapons X pos
            */
            XmlNode WeaponXNode = configDoc.DocumentElement.SelectSingleNode("WX");
            if (WeaponXNode != null)
            {
                String str = WeaponXNode.InnerText.Trim();
                conf.WeaponposX = Convert.ToInt32(str);
            }

            /*
           * Read weapons Y pos
           */
            XmlNode WeaponYNode = configDoc.DocumentElement.SelectSingleNode("WY");
            if (WeaponYNode != null)
            {
                String str = WeaponYNode.InnerText.Trim();
                conf.WeaponposY = Convert.ToInt32(str);
            }

            /*
          * Read weapons hitPoints
          */
            XmlNode WeaponHpNode = configDoc.DocumentElement.SelectSingleNode("WHitPoints");
            if (WeaponHpNode != null)
            {
                String str = WeaponHpNode.InnerText.Trim();
                conf.HitPoints = Convert.ToInt32(str);
            }

            /*
         * Read weapons range
         */
            XmlNode WeaponRangeNode = configDoc.DocumentElement.SelectSingleNode("WHitPoints");
            if (WeaponRangeNode != null)
            {
                String str = WeaponRangeNode.InnerText.Trim();
                conf.WeaponRange = Convert.ToInt32(str);
            }

            /*
            * Read weapon description
            */
            XmlNode WeaponDescriptionNode = configDoc.DocumentElement.SelectSingleNode("WDescription");
            if (WeaponDescriptionNode != null)
            {
                conf.WeaponDescription = WeaponDescriptionNode.InnerText.Trim();
            }

            /*
            * Read DefenceRemovable
            */
            XmlNode DefenceRemovableNode = configDoc.DocumentElement.SelectSingleNode("DRemovable");
            if (DefenceRemovableNode != null)
            {
                String str = DefenceRemovableNode.InnerText.Trim();
                conf.defenceRemovable = Convert.ToBoolean(str);
            }

            /*
            * Read DefenceLootable
            */
            XmlNode DefenceLootableNode = configDoc.DocumentElement.SelectSingleNode("DLootable");
            if (DefenceLootableNode != null)
            {
                String str = DefenceLootableNode.InnerText.Trim();
                conf.defenceLootable = Convert.ToBoolean(str);
            }

            /*
            * Read Denfence name
            */
            XmlNode DefenceNameNode = configDoc.DocumentElement.SelectSingleNode("DName");
            if (DefenceNameNode != null)
            {
                conf.defenceName = DefenceNameNode.InnerText.Trim();
            }

            /*
            * Read Defence X pos
            */
            XmlNode DefenceXNode = configDoc.DocumentElement.SelectSingleNode("DX");
            if (DefenceXNode != null)
            {
                String str = DefenceXNode.InnerText.Trim();
                conf.defencePosX = Convert.ToInt32(str);
            }

            /*
           * Read Defence Y pos
           */
            XmlNode DefenceYNode = configDoc.DocumentElement.SelectSingleNode("DY");
            if (DefenceYNode != null)
            {
                String str = DefenceYNode.InnerText.Trim();
                conf.defencePosY = Convert.ToInt32(str);
            }

            /*
          * Read Reduce hitpoints
          */
            XmlNode ReducedHpNode = configDoc.DocumentElement.SelectSingleNode("ReduceHitPoints");
            if (ReducedHpNode != null)
            {
                String str = ReducedHpNode.InnerText.Trim();
                conf.reduceHitpoints = Convert.ToInt32(str);
            }

            /*
            * Read Denfence description
            */
            XmlNode DefenceDescriptionNode = configDoc.DocumentElement.SelectSingleNode("DDescription");
            if (DefenceDescriptionNode != null)
            {
                conf.defenceDescription = DefenceDescriptionNode.InnerText.Trim();
            }

            SetupWorld(conf);

        }
        /*
         * Implements the reads
         */
        public void SetupWorld(Configuration conf)
        {
            MaxSizeX = conf.MaxSizeX;
            MaxSizeY = conf.MaxSizeY;
            Creatures[1].Name = conf.CreatureName;
            Creatures[1].LifePoints = conf.LifePoints;
            Creatures[1].Position.X = conf.CreatureposX;
            Creatures[1].Position.Y = conf.CreatureposY;
            Creatures[1].Attacks[1].Name = conf.weaponName;
            Creatures[1].Attacks[1].Description = conf.WeaponDescription;
            Creatures[1].Attacks[1].HitPoints = conf.HitPoints;
            Creatures[1].Attacks[1].Range = conf.WeaponRange;
            Creatures[1].Attacks[1].Position.X = conf.WeaponposX;
            Creatures[1].Attacks[1].Position.Y = conf.WeaponposY;
            Creatures[1].Attacks[1].Lootable = conf.weaponLootable;
            Creatures[1].Attacks[1].Removable = conf.weaponRemovable;
            Creatures[1].Defences[1].Name = conf.defenceName;
            Creatures[1].Defences[1].Description = conf.defenceDescription;
            Creatures[1].Defences[1].ReduceHitPoints = conf.reduceHitpoints;
            Creatures[1].Defences[1].Position.X = conf.defencePosX;
            Creatures[1].Defences[1].Position.Y = conf.defencePosY;
            Creatures[1].Defences[1].Lootable = conf.weaponLootable;
            Creatures[1].Defences[1].Removable = conf.weaponRemovable;

        }
    }
}
