namespace Backend.Animals
{
    public class Animal1 : Specie
    {
        public Animal1() : base(25, 0.5) // Initialize with specific values for Animal1
        {
        }

        public override int GetNrOfKids()
        {
            if (Simulation.random.NextDouble() > probProcriar)
                return 0;

            double r = Simulation.random.NextDouble();

            if (r < 0.2)
                return 1;
            if (r < 0.5)
                return 2;
            if (r < 0.85)
                return 3;
            else
                return 4;
        }

        public override int GetMaxAge()
        {
            return (int)System.Math.Round(Distributions.BimodalTruncated(0, 5, 0.1, 80, 20, 0.9));
        }

        public override double GetDesvioTemp()
        {
            return Distributions.Normal(13, 10);
        }
    }


}
