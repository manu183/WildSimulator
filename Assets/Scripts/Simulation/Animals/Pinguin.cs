using System;

namespace Backend.Animals
{
    public class Pinguin : Specie
    {
        public Pinguin() : base(5, 0.5, 2, 50, 20) // Initialize with IdealTemperature,oddOfPregnant
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
