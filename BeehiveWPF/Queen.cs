using System;

namespace BeehiveWPF
{
    public class Queen : Bee
    {
        public override float CostPerShift => 2.15f;
        private float eggs = 0;
        private float unassignedWorkers = 3;
        private const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;
        private const float EGGS_PER_SHIFT = 0.45f;        
        public string StatusReport { get; private set; }


        private Bee[] workers = new Bee[0];

        public void AssignBee(string job)
        {
            switch (job)
            {
                case "Egg Carer":
                    AddWorker(new EggCare());
                    break;
                case "Nectar Collector":
                    AddWorker(new NectarCollector());
                    break;
                case "Honey Manufacturer":
                    AddWorker(new HoneyManufacturer());
                    break;
            }
            UpdateStatusReport();
        }

        private void AddWorker(Bee worker)
        {
            if(unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }
        }

        public void CareForEggs(float eggsToConvert)
        {            
            if (eggs >= eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }

        }

        public string WorkerStatus(string job)
        {
            int count = 0;
            foreach (Bee worker in workers)
                if (worker.Job == job) count++;
            string s = "s";
            if (count == 1) s = "";
            return $"{count} {job} bee{s}";
        }

        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            foreach(Bee worker in workers)
            {
                worker.WorkTheNextShift();
            }

            HoneyVault.ConsumeHoney(HONEY_PER_UNASSIGNED_WORKER * unassignedWorkers);
            
        }

        private void UpdateStatusReport()
        {
            StatusReport = 
                $"Vault Report: {HoneyVault.StatusReport}\n" +
                $"Egg count: {eggs:0.0}\n" +
                $"Unassigned workers: {unassignedWorkers:0.0}\n" +
                $"{WorkerStatus("Egg Carer")} Nectar Collector bee\n" +
                $"{WorkerStatus("Nectar Collector")} Honey Manufacturer bee" +
                $"{WorkerStatus("Honey Manufacturer")} Egg Care bee" +
                $"TOTAL WORKERS {workers.Length}" ;           
        }

        public Queen() : base("Queen")
        {   
            AssignBee("Egg Carer");
            AssignBee("Nectar Collector");
            AssignBee("Honey Manufacturer");
        }         
    }
}
