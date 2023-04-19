
using _GeneticAlgorithm;
using _Linker;
using _Functions;

namespace LC
{
    class Program
    {

        static void Main(string[] args)
        {

            string allowedChars = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string sampleTarget = "HELLO WORLD MY NAME IS BEN";
            float[] linkerTarget = new float[sampleTarget.Length];

            for (int i = 0; i < sampleTarget.Length; i++)
            {
                linkerTarget[i] = (float)(((int) sampleTarget[i]) - 65);
            }

            linkerTarget = Functions.mapList(linkerTarget);

            Dictionary<string, Object> linkerData = new Dictionary<string, Object>();
            linkerData.Add("target", linkerTarget);
            linkerData.Add("allowedChars", allowedChars);

            Functions.displayList(linkerTarget);

            int genome_length = linkerTarget.Length;
            int population_size = 1000;
            int rounds = 500;
            int selection_size = 100;
            bool verbose = false;

            Linker L = new Linker(linkerData);

            Console.WriteLine("//////////////////////////////////////////");
            
            GeneticAlgorithm GA = new GeneticAlgorithm(L, population_size, genome_length);
            GA.simulate(rounds, selection_size, verbose);
            
            float[] bestGenome = GA.maxFitness().getGenome();

            Functions.displayFloatListToAllowedChars(allowedChars, bestGenome);


            
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
