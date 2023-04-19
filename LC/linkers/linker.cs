
using _Functions; 

namespace _Linker {

    public class Linker {

        private float[] target;
        private int targetLength;
        private string allowedChars;

        public Linker(Dictionary<string, object> linkerData) {
            this.target = (float[]) linkerData["target"];
            this.allowedChars = (string) linkerData["allowedChars"];

            for (int i = 0; i < targetLength; i++) {
                this.target[i] = 0;
            }

            if (linkerData.ContainsKey("targetLength")) {
                this.targetLength = (int) linkerData["targetLength"];
            }else{
                this.targetLength = this.target.Length;
            }

        }

        public float[] normalizedTarget(){
            return Functions.mapList(this.target);
        }

        public float linkFitness(float[] genome){
        
            //////////////////////////////////////////////////////////////////////////////
            
            // This is where the Lunar code is translated into a fitness value.

            //////////////////////////////////////////////////////////////////////////////

            float[] tempTarget = this.normalizedTarget();
            return 1 - Functions.sumList(Functions.distListList(genome, tempTarget));
        }

        public void setTarget(float[] target) {
            this.target = target;
        }

        public float[] getTarget() {
            return this.target;
        }

        public void displayLinkerTarget() {
            string target = "";
            for (int i = 0; i < this.target.Length - 1; i++) {
                target += this.target[i] + ", ";
            }

            target += this.target[this.target.Length - 1];
            System.Console.WriteLine("[" + target + "]");
        }

    }



}
