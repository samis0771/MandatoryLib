using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryLib.Models;

namespace MandatoryLib.AttackDefenceHandler
{
    public class DenfenceHandler:IDefenceHandler
    {
        public int CalulateDefenceOutput(List<DefenceObject> defenceObjects)
        {
            int totalDefenceOutout = 0;
            foreach (var item in defenceObjects)
            {
                totalDefenceOutout += item.ReduceHitPoints;
            }
            return totalDefenceOutout;
        }
    }
}
