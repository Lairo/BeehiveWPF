﻿namespace BeehiveWPF
{
    static class HoneyVault
    {
        private static float honey = 25f;
        private static float nectar = 100f;

        private const float NECTAR_CONVERSION_RATIO = .19f;
        private const float LOW_LEVEL_WARNING = 10f;

        public static void ConvertNectarToHoney(float amount)
        {
            float nectarToConvert = amount;
            if (nectarToConvert > nectar) _ = nectar;
            nectar -= amount;
            honey += amount * NECTAR_CONVERSION_RATIO;
        }

        public static void CollectNectar(float amount)
        {
            if (amount > 0f)
            {
                honey += amount;
            }

        }

        public static bool ConsumeHoney(float amount)
        {
            if (amount > honey)
            {
                honey -= amount;
                return true;
            }
            return false;
        }

        public static string StatusReport
        {
            get
            {
                string status = $"Honey: {honey:0.0}\nNectar: {nectar:0.0}. ";

                string warning = "";

                if (honey < LOW_LEVEL_WARNING || nectar < LOW_LEVEL_WARNING)
                {
                    warning += "\nLOW HONEY = ADD A HONEY MANUFACTURER";
                }

                return status + warning;
            }
        }

    }
}