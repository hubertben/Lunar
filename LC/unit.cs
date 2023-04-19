
using _Functions;

namespace _Unit {

    public class Unit {

        private float[] genome;
        private float fitness = 0;
        private float mutation_rate;

        public Unit(int genome_length, float mutation_rate, bool init = true) {
            this.genome = new float[genome_length];
            this.mutation_rate = mutation_rate;

            if (init) {
                this.initRandomGenome();
            }
        }

        public string __repr__(int round_to = 2) {
            float rounded2Fitness = Functions.round(this.fitness, round_to);
            string r2F = rounded2Fitness.ToString();
            string space = "";
            for (int i = 0; i < ((5 + round_to) - r2F.Length); i++) {
                space += " ";
            }

            return "Unit:"+ space + (rounded2Fitness);
        }

        public void setFitness(float fitness) {
            this.fitness = fitness;
        }

        public float getFitness(bool regenerate = false) {
            if (regenerate && this.fitness != -1) {
                this.fitness = this.computeFitness(0);
            }
            return this.fitness;
        }

        public void setGenome(float[] genome) {
            this.genome = genome;
        }

        public float[] getGenome() {
            return this.genome;
        }

        public void initRandomGenome() {
            for (int i = 0; i < this.genome.Length; i++) {
                this.genome[i] = Functions.randomFloat(-1, 1);
            }
        }

        public void mutate() {
            for (int i = 0; i < this.genome.Length; i++) {
                if (this.mutation_rate > Functions.randomFloat(0, 1)) {
                    this.genome[i] += Functions.randomFloat(-1, 1);
                    this.genome[i] = Functions.map(this.genome[i], -2, 2, -1, 1);
                }
            }
        }

        public Unit cross(Unit other, string _type = "rand"){
            Unit child = new Unit(this.genome.Length, this.mutation_rate, false);
            for (int i = 0; i < this.genome.Length; i++) {
                float A = this.genome[i];
                float B = other.getGenome()[i];

                switch (_type) {
                    case "rand":
                        child.getGenome()[i] = Functions.randomFloat(0, 1) > 0.5f ? A : B;
                        break;
                    case "avg":
                        child.getGenome()[i] = (A + B) / 2;
                        break;
                    case "min":
                        child.getGenome()[i] = A < B ? A : B;
                        break;
                    case "max":
                        child.getGenome()[i] = A > B ? A : B;
                        break;
                }
            }
            return child;
        }

        public float computeFitness(float x){
            float distance = Functions.sumList(Functions.distListFloat(this.genome, 0));
            float fitness = 1 / ((distance + 1) + .0001f);
            return fitness;
        }

        public void displayGenome() {
            System.Console.Write("[");
            for (int i = 0; i < this.genome.Length - 1; i++) {
                System.Console.Write(this.genome[i] + ", ");
            }
            System.Console.WriteLine(this.genome[this.genome.Length - 1] + "]");
        }


    }

}