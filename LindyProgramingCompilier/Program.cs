using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LindyProgramingCompilier
{
    class Program
    {
        static void Main(string[] args)
        {
            LindyParser parser = new LindyParser();
            DanceFloor floor = new DanceFloor();
            var dancer = new Dancer();
            floor.AddDancer(dancer);
            WriteLine("Welcome to Lindy compilier :-) ");
            WriteLine("Please enter a command: ");
            string lindyCommandString = ReadLine();

            while (!lindyCommandString.Equals("exit"))
            {
                try
                {
                    //var commandPair = parser.CreateCommandPair(parser.ParseCommandPair(lindyCommandString));

                    //floor.Run(commandPair);
                    dancer.Dance(DanceStep.Create(lindyCommandString));
                    WriteLine("\nCurrent State => " + floor.PositionValuesString());
                    WriteLine(floor.ValueGrid());
                }
                catch(ArgumentException e) when (e.Message.Contains("command"))
                {
                    WriteLine("Invalid command!!!");
                }
                WriteLine("Please enter a command: ");
                lindyCommandString = ReadLine();
            }
            WriteLine("Press a key to exit.");
            ReadKey();

        }
    }
}
