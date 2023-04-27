using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryLib.Models;

namespace MandatoryLib.ObserverClasses.WorldObjectObserver
{
    public interface IWorldObjectObserver
    {
        void ObjectLooted(WorldObject worldObject);
    }
}
