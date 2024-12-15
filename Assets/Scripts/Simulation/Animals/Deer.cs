using System;

namespace Backend.Animals
{
    public class Deer : Specie
    {
        public Deer() : base(14, 0.5, 2, 60, 17 ) // Initialize with IdealTemperature,oddOfPregnant
        {
        }

        public override int GetNrOfKids()
        {
            double r = Simulation.random.NextDouble();

            if (r < 0.6)
                return 1;
            if (r < 0.85)
                return 2;
            if (r < 0.95)
                return 3;
            else
                return 4;
        }

       
    }


}
