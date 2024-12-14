using System;

namespace Backend.Animals
{
    public class Animal1 : Specie
{
    public Animal1() : base(25, 0.3,3) // Initialize with IdealTemperature,oddOfPregnant
    {
    }

    public override int GetNrOfKids()
    {
        double r = Simulation.random.NextDouble();

        if (r < 0.8)
            return 1;
        if (r < 0.92)
            return 2;
        if (r < 0.98)
            return 3;
        else
            return 4;
    }

    public override int GetMaxAge()
    {
        return (int)Math.Round(Distributions.BimodalTruncated(0, 5, 0.1, 17, 20, 0.9));
    }

    public override double GetDesvioTemp(){
        return  Distributions.Normal(13, 10);
    }
}


}
