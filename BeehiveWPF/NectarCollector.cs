﻿namespace BeehiveWPF
{
    class NectarCollector : Bee
    {
        private const float NECTAR_COLLECTED_PER_SHIFT = 33.25f;
        public override float CostPerShift => 1.95f;
        public NectarCollector() : base("Nectar Collector") { }

        protected override void DoJob()
        {
            HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
        }
    }
}
