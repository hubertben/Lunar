
using _GeneticAlgorithm;
using _Linker;
using _Functions;
using _ParamsLoader;

using _Lexer;
using _Parser;

namespace LC
{
    class Program
    {

        public static Linker buildLinkert(string text, string allowedChars){
            Dictionary<string, float> mapping = Functions.mapCharsetNormal(allowedChars);
            float[] linkerTarget = Functions.applyMappingToString(mapping, text);
            Dictionary<string, Object> linkerData = new Dictionary<string, Object>();
            linkerData.Add("target", linkerTarget);
            linkerData.Add("allowedChars", allowedChars);
            linkerData.Add("mapping", mapping);
            Linker L = new Linker(linkerData);
            return L;
        }

        public static void test1(){
            string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890 .,-+=_!@#$%^&*()";
            string sampleTarget = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";

            Linker L = buildLinkert(sampleTarget, allowedChars);
            
            int genome_length = sampleTarget.Length;
            ParamsLoader PL = new ParamsLoader("Genetic Algorithm/params/params.json");

            int population_size = PL.getItem<int>("population_size");
            int rounds = PL.getItem<int>("rounds");
            int selection_size = PL.getItem<int>("selection_size");
            float mutation_rate = PL.getItem<float>("mutation_rate");
            bool verbose = true;

            GeneticAlgorithm GA = new GeneticAlgorithm(L, population_size, genome_length);
            GA.setMutationRate(mutation_rate);
            GA.simulate(rounds, selection_size, verbose);
            GA.displayMaxMapping();
        }

        static void Main(string[] args)
        {
            Parser p = new Parser("1 + 2 + 3");
            var exp = p.parseExpression();
            Parser.printAST(exp);
            
            // keyboardInput();
        }

        static void keyboardInput()
        {
            while (true)
            {

                Console.Write(">>> ");
                var line = Console.ReadLine();

                if (line == "exit")
                {
                    break;
                }
                else
                {
                    Lexer L = new Lexer(line);
                    while (true)
                    {
                        Lexer.Token t = L.getNextToken();
                        if (t.type == Lexer.Types.EOF || t.type == Lexer.Types.UNKNOWN)
                        {
                            break;
                        }
                        Console.WriteLine(t.__repr__());
                    }
                }

            }
        }

    }
}
