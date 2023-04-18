
using _Unit;

namespace _GeneticAlgorithm {
    
    public class GeneticAlgorithm {
        
        public int population_size = 100;
        private Unit[] population;
        private int generation = 0;
        private int rounds = 500;
        private float mutation_rate = 0.001f;


        public GeneticAlgorithm(int population_size, bool init = true) {
            this.population_size = population_size;
            this.population = new Unit[population_size];

            if (init) {
                this.initializePopulation();
            }
        }

        public void setRounds(int rounds) {
            this.rounds = rounds;
        }

        public void setMutationRate(float mutation_rate) {
            this.mutation_rate = mutation_rate;
        }

        public Unit[] getPopulation() {
            return this.population;
        }

        public Unit getUnit(int index) {
            return this.population[index];
        }

        public void initializePopulation() {
            for (int i = 0; i < this.population_size; i++) {
                this.population[i] = new Unit(10, this.mutation_rate);
            }
        }


    }
}