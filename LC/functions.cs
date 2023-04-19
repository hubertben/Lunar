

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
        
        public static float dist(float a, float b){
            return Math.Abs(a - b);
        }

        public static float distFloatFloat(float x1, float y1, float x2, float y2){
            return (float)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public static float[] distListFloat(float[] list1, float x){

            float[] distances = new float[list1.Length];

            for (int i = 0; i < list1.Length; i++) {
                distances[i] = dist(list1[i], x);
            }

            return distances;
        }

        public static float[] distListList(float[] list1, float[] list2){
            if (list1.Length != list2.Length) {
                throw new Exception("Lists must be of equal length");
            }

            float[] distances = new float[list1.Length];

            for (int i = 0; i < list1.Length; i++) {
                distances[i] = dist(list1[i], list2[i]);
            }

            return distances;
        }

        public static float sumList(float[] list){
            float sum = 0;
            foreach (float item in list) {
                sum += item;
            }
            return sum;
        }

    }

}