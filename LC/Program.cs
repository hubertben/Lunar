
using _GeneticAlgorithm;

namespace LC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            var GA = new GeneticAlgorithm(2);
            GA.getUnit(0).displayGenome();
            GA.getUnit(1).displayGenome();

            var child = GA.getUnit(0).cross(GA.getUnit(1), "min");
            child.displayGenome();
            
            // keyboardInput();
        }

        static void keyboardInput()
        {
            while (true)
            {

                var line = Console.ReadLine();

                if (line == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine(">>> " + line);
                }

            }
        }

    }
}
