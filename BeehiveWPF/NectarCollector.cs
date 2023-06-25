using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveWPF
{
    public class NectarCollector : Bee
    {
        public override float CostPerShift => 1.95f;
        public NectarCollector() :base("Nectar Collector") { }
    }
}
