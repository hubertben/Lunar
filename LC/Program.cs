
using _GeneticAlgorithm;

namespace LC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            var GA = new GeneticAlgorithm(1000);

            GA.simulate(500, 100);

            GA.maxFitness().displayGenome();

        }

        // static void keyboardInput()
        // {
        //     while (true)
        //     {

        //         var line = Console.ReadLine();

        //         if (line == "exit")
        //         {
        //             break;
        //         }
        //         else
        //         {
        //             Console.WriteLine(">>> " + line);
        //         }

        //     }
        // }

    }
}
