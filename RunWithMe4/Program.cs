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

            var holiday = new Holiday();
            var istodayaholiday = holiday.IsTodayAHoliday();
            decimal distance = istodayaholiday ? 1 : 10;
            while (run.Distance < distance )
            {
                
           
                Console.WriteLine("You have not ran 10 miles yet.");
                Console.WriteLine("How many additional miles did you run? (or press e to exit)");

                var milesInput = Console.ReadLine();
                if (milesInput.ToUpper() == "E")
                {
                    return;
                }


                if (!decimal.TryParse(milesInput, out decimal howFarRan))
                {
                    LogError(milesInput, 2);
                    return;
                }
                run.Distance += howFarRan;

                

                Console.WriteLine(run);

                if (run.Distance == 10m)
                {
                    Console.WriteLine("Congrats you ran 10 miles!");
                }
            }
        }
    }

}
