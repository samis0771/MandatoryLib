using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryLib.Models;

namespace MandatoryLib.AttackDefenceHandler
{
    public class AttackHandler:IAttackHandler
    {
        public int CalculateDamageOutput(List<AttackObject> attackObjects)
        {
            int totalDamageOutput = 0;
            foreach (var item in attackObjects)
            {
                totalDamageOutput += item.HitPoints;
            }
            return totalDamageOutput;
        }
    }
}
