using System.Text;
using System.Collections.Generic;
using System;

namespace RunwithMe
{
    internal class Program
    {
        static string errorloggingpath = Directory.GetCurrentDirectory();

        public static string AddTimestamp()
        {
            return " - " + DateTime.Now;
        }

        private static void LogError(string response, int errorCode)
        {
            Console.WriteLine("You entered an invalid option, logging error and quitting");
            File.AppendAllText(errorloggingpath, "User entered a " + response + ", was an invalid character.error code " + errorCode + AddTimestamp());
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            var responseDidTheyRun = new Char();
            var run = new Run();


            try
            {
                Console.WriteLine("Welcome to RunwithMe!");
                Console.WriteLine("\tDid you run today? Y/N");
                responseDidTheyRun = Console.ReadKey().KeyChar;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                File.AppendAllText(errorloggingpath, e.Message);
            }

            if (responseDidTheyRun.ToString().ToLower() == "y")
            {
                run.Ran = true;
                Console.WriteLine("\nThanks for running!");
            }
            else if (responseDidTheyRun.ToString().ToLower() == "n")
            {
                run.Ran = false;
                Console.WriteLine("\nYou should run more.");
            }
            else
            {
                LogError(responseDidTheyRun.ToString(), 1);
                return;
            }

            if (run.Ran == false) { return; }

            int
            while (run.Ran == true)
            {
                Console.WriteLine("How far and how long did you run?");



                Console.WriteLine("Since you ran, how far did you run? Enter distance in miles");
                var responseHowFarRan = Console.ReadLine();
                if (!decimal.TryParse(responseHowFarRan, out decimal howFarRan))
                {
                    LogError(responseHowFarRan, 2);
                    return;
                }
                run.Distance = howFarRan;

                Console.WriteLine("How long did it take you to run? Enter duration in hours and/or minutes eg. 1:15");
                if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan HowLongRan))
                {
                    LogError(HowLongRan.ToString(), 3);
                    return;
                }
                run.Duration = HowLongRan;

                Console.WriteLine(run);


            }
        }
    }


