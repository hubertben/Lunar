
using System;

namespace LC
{
    class Program
    {
        static void Main(string[] args)
        {
            keyboardInput();
        }

        static void keyboardInput()
        {
            while (true)
            {

                var key = Console.ReadLine();

                if (key == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine(key);
                }

            }
        }

    }
}
