using MandatoryLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryLib.ObserverClasses.DeadObserver
{
    public interface IDeadObserver
    {
        void WhenDead(Creature creature);
    }
}
