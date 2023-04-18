
using System;
using _GeneticAlgorithm;

namespace LC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            var GA = new GeneticAlgorithm(1000);
            GA.getUnit(0).displayGenome();
            GA.getUnit(0).mutate();
            GA.getUnit(0).displayGenome();

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
