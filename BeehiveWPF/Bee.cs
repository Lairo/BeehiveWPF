namespace BeehiveWPF
{
    public class Bee
    {
        public virtual float CostPerShift { get;}
        public string Job { get; private set; }

        public void WorkTheNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift))
                DoJob();
            
        }

        public Bee(string Job)
        {
            Job = Job;
        }

        protected virtual void DoJob() { }
    }
}
