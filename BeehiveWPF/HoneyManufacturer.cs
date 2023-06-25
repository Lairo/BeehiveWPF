using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveWPF
{
    public class HoneyManufacturer : Bee
    {
        public override float CostPerShift => 1.7f;

        public HoneyManufacturer(): base("Honey Manufacturer") { }
    }
}
