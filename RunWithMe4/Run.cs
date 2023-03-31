using System;

namespace RunwithMe
{
    public class Run
    {
        public bool Ran { get; set; }
        public decimal Distance { get; set; }
        

        public override string ToString()
        {
            return "Ran:" +
                this.Ran +
                "\nDistance " +
                this.Distance;
                
        }
    }
}

