
using _Unit;
using _Functions;

namespace _GeneticAlgorithm {
    
    public class GeneticAlgorithm {
        
        public int population_size;
        private Unit[] population;
        private int rounds;
        private float mutation_rate = 0.5f;


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
        public float calculateTotalFitness() {
            float total_fitness = 0;
            for (int i = 0; i < this.population_size; i++) {
                Unit U = this.population[i];
                total_fitness += U.getFitness();
            }
            return total_fitness;
        }

        public Unit maxFitness(){
            Unit max = this.population[0];
            for (int i = 0; i < this.population_size; i++) {
                Unit U = this.population[i];
                if (U.getFitness(true) > max.getFitness(true)) {
                    max = U;
                }
            }
            return max;
        }

        public Unit[] getTopXUnits(Unit[] sample, int x = 10) {
            return sample.OrderByDescending(u => u != null ? u.getFitness(true) : -1).Take(x).ToArray();
        }

        public Unit[] selection(int slots = 10){
            return this.getTopXUnits(this.population, slots);
        }

        public void replacePopulation(Unit[] sample){

            this.population = new Unit[this.population_size];
            int appendIndex = sample.Length;

            for (int i = 0; i < sample.Length; i++) {
                this.population[i] = sample[i];
            }

            while (appendIndex < this.population_size) {

                Unit A = (Unit)(Functions.randomElement(sample));
                Unit B = (Unit)(Functions.randomElement(sample));

                if (A != B) {
                    Unit child = A.cross(B, "rand");
                    child.mutate();
                    this.population[appendIndex] = child;
                    appendIndex++;
                }
            }
        }

        public Dictionary<object, object> simulate(int rounds = 50, int slots = 10, bool print_ = false) {
            Dictionary<object, object> stats = new Dictionary<object, object>();
            int generation = 0;

            for (int i = 0; i < rounds; i++) {
                
                Unit[] top = this.selection(slots);
                this.replacePopulation(top);

                if (print_) {
                    Console.WriteLine("Generation: " + generation);
                    Console.WriteLine("Total Fitness: " + this.calculateTotalFitness());
                    Console.WriteLine("Max Fitness: " + this.maxFitness().getFitness(true));
                    Console.WriteLine("");
                }
                generation++;
            }
            
            stats["population"] = this.population;
            return stats;
        }


        public void displayPopulation(Unit[] sample, int top = int.MaxValue) {
            for (int i = 0; i < Math.Min(sample.Length, top); i++) {
                Unit U = sample[i];
                System.Console.WriteLine(U.__repr__(4));
            }
        }

    }
}