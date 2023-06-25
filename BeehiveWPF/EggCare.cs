using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveWPF
{
    public class EggCare : Bee
    {
        public override float CostPerShift => 1.35f;
        public EggCare(): base("Egg Carer") { }
    }
}
