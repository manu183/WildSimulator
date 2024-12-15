using System;

namespace Backend.Animals
{
    public class Kitty : Specie
    {
        public Kitty() : base(25, 0.5, 2) // Initialize with IdealTemperature,oddOfPregnant
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

        public override int GetMaxAge()
        {
            return (int)Math.Round(Distributions.BimodalTruncated(0, 5, 0.1, 17, 20, 0.9));
        }

        public override double GetDesvioTemp()
        {
            return Distributions.Normal(13, 10);
        }
    }


}
