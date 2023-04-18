
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

        public void setFitness(float fitness) {
            this.fitness = fitness;
        }

        public float getFitness() {
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
                }
            }
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