using System;

namespace Backend.Animals
{
    public class Kitty : Specie
    {
        public Kitty() : base(20, 0.4, 2, 34,17) // Initialize with IdealTemperature,oddOfPregnant
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
