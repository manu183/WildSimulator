using System;

namespace Backend.Animals
{
    public class Chicken : Specie
    {
        public Chicken() : base(17, 0.8, 2, 40,12) // Initialize with IdealTemperature,oddOfPregnant
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
