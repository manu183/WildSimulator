namespace Backend
{
    using System;
    public class Individuo
    {

        public int age; //dias
        public int maxAge;// dias
        public Specie specie;
        public double desvioTemperatura;
        public int pregnant;
        public Boolean died;

        public Individuo(Specie specie)
        {
            age = 0;
            pregnant = 0;
            maxAge = specie.GetMaxAge();
            desvioTemperatura = specie.GetDesvioTemp();
            this.specie = specie;
            died = false;
            //Console.WriteLine("Nasceu: "+this);
        }

        public int MakeChildren()
        {
            if (pregnant == 0)
            {
                double r = Simulation.random.NextDouble();
                if (r < specie.probProcriar)
                    pregnant++;
            }
            else if (pregnant == specie.tempoGravidez)
            {
                pregnant = 0;
                return specie.GetNrOfKids();
            }
            return 0;
        }
        public Boolean Dies(Day day)
        {
            age++;
            //morrer velhice
            if (age == maxAge)
            {
                died = true;
                /*                 Console.WriteLine("MORREU VELHICE");
                 */
                return true;
            }
            //morrer temperatura
            double r = Simulation.random.NextDouble();
            if (r > specie.ProbabilidadeSobreviver(day.temperature, desvioTemperatura))
            {
                died = true;
                /* Console.WriteLine("PROBABILIDADE SOBREVIVER: " + ProbabilidadeSobreviver(day.temperature));
                Console.WriteLine("MORREU TEMPERATURA"); */
                return true;
            }
            // fazer morrer desastre natural
            died = false;
            return false;
        }
        public override string ToString()
        {
            return $"Individuo {{ age: {age}, maxAge: {maxAge} }}";
        }
    }

}
