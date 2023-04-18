

namespace _Functions {

    public static class Functions {

        public static float map(float x, float in_min, float in_max, float out_min, float out_max) {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        public static float randomFloat(float min, float max) {
            Random random = new Random();
            return (float)random.NextDouble() * (max - min) + min;
        }

        public static float round(float value, int digits) {
            double mult = Math.Pow(10.0, digits);
            return (float)Math.Round(value * mult) / (float)mult;
        }

        public static object randomElement(object[] array) {
            Random random = new Random();
            return array[random.Next(array.Length)];
        }
        

    }

}