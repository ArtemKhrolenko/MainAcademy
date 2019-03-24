using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.FarmerGame
{
    internal class Wolf : Stuff
    {
        internal override string Name { get; }

        internal Wolf()
        {
            Name = "Wolf";
        }
    }
}
