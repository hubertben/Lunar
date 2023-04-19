

namespace _Functions {

    public static class Functions {

        public static float map(float x, float in_min, float in_max, float out_min, float out_max) {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        public static float[] mapListRange(float[] list, float in_min, float in_max, float out_min, float out_max) {
            float[] mapped = new float[list.Length];
            for (int i = 0; i < list.Length; i++) {
                mapped[i] = map(list[i], in_min, in_max, out_min, out_max);
            }
            return mapped;
        }

        public static float[] mapList(float[] list, float out_min = -1, float out_max = 1) {
            float[] mapped = new float[list.Length];
            float in_min = list.Min();
            float in_max = list.Max();
            for (int i = 0; i < list.Length; i++) {
                mapped[i] = map(list[i], in_min, in_max, out_min, out_max);
            }
            return mapped;
        }

        public static float randomFloat(float min, float max) {
            Random random = new Random();
            return (float)random.NextDouble() * (max - min) + min;
        }

        public static float round(float value, int digits) {
            double mult = Math.Pow(10.0, digits);
            return (float)Math.Round(value * mult) / (float)mult;
        }

        public static float[] roundList(float[] list, int digits) {
            float[] rounded = new float[list.Length];
            for (int i = 0; i < list.Length; i++) {
                rounded[i] = round(list[i], digits);
            }
            return rounded;
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

        public static void displayList(float[] list){
            string target = "";
            for (int i = 0; i < list.Length - 1; i++) {
                target += list[i] + ", ";
            }

            target += list[list.Length - 1];
            System.Console.WriteLine("[" + target + "]");
        }

        public static float trunc(float x, int digits = 0){
            return (float)Math.Truncate(x * (float)Math.Pow(10, digits)) / (float)Math.Pow(10, digits);
        }

        public static float[] truncList(float[] list, int digits){
            float[] truncated = new float[list.Length];
            for (int i = 0; i < list.Length; i++) {
                truncated[i] = trunc(list[i], digits);
            }
            return truncated;
        }

        public static int closestIndexFloat(float x, float[] list){
            float[] distances = distListFloat(list, x);
            return Array.IndexOf(distances, distances.Min());
        }

        public static int[] closestIndexList(float[] compareTo, float[] compareFrom){
            float[] distances = distListList(compareTo, compareFrom);
            int[] closest = new int[distances.Length];
            for (int i = 0; i < distances.Length; i++) {
                closest[i] = Array.IndexOf(distances, distances.Min());
                distances[closest[i]] = float.MaxValue;
            }
            return closest;
        }

        public static float[] noramlizeList(float[] list, bool negOnetoPosOne = true){
            float[] normalized = new float[list.Length];
            float sum = sumList(list);
            for (int i = 0; i < list.Length; i++) {
                normalized[i] = list[i] / sum;
            }

            if (negOnetoPosOne) {
                for (int i = 0; i < normalized.Length; i++) {
                    normalized[i] = map(normalized[i], 0, 1, -1, 1);
                }
            }

            return normalized;
        }

        public static int[] stringToIntList(string s){
            int[] list = new int[s.Length];
            for (int i = 0; i < s.Length; i++) {
                list[i] = (int)Char.GetNumericValue(s[i]);
            }
            return list;
        }

        public static int getAscii(char c){
            return ((int)c) - 65;
        }

        public static void displayFloatListToAllowedChars(string allowedChars, float[] target){
            
            float[] targetLetters = new float[allowedChars.Length];
            for (int i = 0; i < allowedChars.Length; i++)
            {
                targetLetters[i] = (float)Functions.getAscii(allowedChars[i]);
            }

            targetLetters = Functions.mapList(targetLetters);

            Dictionary<float, char> dict = new Dictionary<float, char>();
            for (int i = 0; i < targetLetters.Length; i++)
            {
                dict.Add(targetLetters[i], allowedChars[i]);
            }
            
            string targetString = "";
            
            for (int i = 0; i < target.Length; i++)
            {
                int charLoc = Functions.closestIndexFloat(target[i], targetLetters);
                targetString += dict[targetLetters[charLoc]];
            }
            Console.WriteLine("\n\nBest Genome: " + targetString);
        }

    }

}