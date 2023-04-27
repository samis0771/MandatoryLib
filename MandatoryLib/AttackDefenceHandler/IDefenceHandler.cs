using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryLib.Models;

namespace MandatoryLib.AttackDefenceHandler
{
    public interface IDefenceHandler
    {
        int CalulateDefenceOutput(List<DefenceObject> defenceObjects);
    }
}
