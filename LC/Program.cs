﻿
using _GeneticAlgorithm;
using _Linker;
using _Functions;

namespace LC
{
    class Program
    {

        static void Main(string[] args)
        {

            string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890 .,-+=_!@#$%^&*()";
            Dictionary<string, float> mapping = Functions.mapCharsetNormal(allowedChars);

            string sampleTarget = "This is - sample text. @@@ (2 + 2) = 4)!";
            float[] linkerTarget = Functions.applyMappingToString(mapping, sampleTarget);
           
            Dictionary<string, Object> linkerData = new Dictionary<string, Object>();
            linkerData.Add("target", linkerTarget);
            linkerData.Add("allowedChars", allowedChars);
            linkerData.Add("mapping", mapping);

            int genome_length = linkerTarget.Length;
            int population_size = 1250;
            int rounds = 200;
            int selection_size = 50;
            bool verbose = true;

            Linker L = new Linker(linkerData);
            
            GeneticAlgorithm GA = new GeneticAlgorithm(L, population_size, genome_length);
            GA.simulate(rounds, selection_size, verbose);

            GA.displayMaxMapping();
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
