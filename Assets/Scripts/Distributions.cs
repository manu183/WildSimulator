namespace Backend
{
    using System;

    public static class Distributions
    {
        public static double Normal(double mu, double sigma)
        {
            double p, p1, p2;
            do
            {
                p1 = (Simulation.random.NextDouble() * 2) - 1;
                p2 = (Simulation.random.NextDouble() * 2) - 1;
                p = p1 * p1 + p2 * p2;
            } while (p >= 1);
            return mu + sigma * p1 * Math.Sqrt(-2 * Math.Log(p) / p);
        }

        public static double BimodalTruncated(double mu1, double sig1, double weight1, double mu2, double sig2, double weight2)
        {
            double result;
            do
            {
                if (Simulation.random.NextDouble() < weight1)
                {
                    result = Normal(mu1, sig1);
                }
                else
                {
                    result = Normal(mu2, sig2);
                }
            } while (result < 0); // Truncar valores menores que 0

            return result;
        }

    }
}