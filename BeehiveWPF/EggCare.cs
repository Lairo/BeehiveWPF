namespace BeehiveWPF
{
    class EggCare : Bee
    {
        private const float CARE_PROGRESS_PER_SHIFT = 0.15f;

        public override float CostPerShift => 1.35f;
        
        private Queen queen;
        public EggCare(Queen queen) : base("Egg Carer")
        {
            this.queen = queen;
        }

        protected override void DoJob()
        {
            queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        }
    }
}
