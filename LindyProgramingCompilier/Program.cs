﻿using System;
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

            WriteLine("Welcome to Lindy compilier :-) ");
            WriteLine("Please enter a command: ");
            string lindyCommandString = ReadLine();

            while (!lindyCommandString.Equals("exit"))
            {
                try
                {
                    var commandPair = parser.CreateCommandPair(parser.ParseCommandPair(lindyCommandString));

                    floor.Run(commandPair);
                    WriteLine("\nCurrent State => " + floor.PositionValuesString());
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
