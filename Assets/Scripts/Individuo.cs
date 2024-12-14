
using HelloWorld;

namespace SomeSpace
{
    public class Individuo
    {

        public int age; //dias
        public int maxAge;// dias
        public Specie specie;
        public double desvioTemperatura;

        public Individuo(Specie specie)
        {
            age = 0;
            maxAge = specie.GetMaxAge();
            desvioTemperatura = specie.GetDesvioTemp();
            this.specie = specie;
            //Console.WriteLine("Nasceu: "+this);
        }
        public Boolean Dies(Day day)
        {
            //morrer velhice
            if (age == maxAge)
            {
                /*                 Console.WriteLine("MORREU VELHICE");
                 */
                return true;
            }
            //morrer temperatura
            double r = Simulation.random.NextDouble();
            if (r > specie.ProbabilidadeSobreviver(day.temperature, desvioTemperatura))
            {
                /* Console.WriteLine("PROBABILIDADE SOBREVIVER: " + ProbabilidadeSobreviver(day.temperature));
                Console.WriteLine("MORREU TEMPERATURA"); */
                return true;
            }
            // fazer morrer desastre natural
            return false;
        }
        public override string ToString()
        {
            return $"Individuo {{ age: {age}, maxAge: {maxAge} }}";
        }
    }
}