namespace SomeSpace
{
    public abstract class Specie
    {
        protected readonly double temperaturaIdeal;
        protected readonly double probProcriar;

        public Specie(double temperaturaIdeal, double probProcriar)
        {
            this.temperaturaIdeal = temperaturaIdeal;
            this.probProcriar = probProcriar;
        }

        public abstract int GetNrOfKids();
        public abstract int GetMaxAge();

        public abstract double GetDesvioTemp();

        public double ProbabilidadeSobreviver(double T, double desvio)
        {
            double numerador = Math.Pow(T - temperaturaIdeal, 2);
            double denominador = 2 * Math.Pow(desvio, 2);
            double resultado = Math.Exp(-numerador / denominador);
            return resultado;
        }
    }
}
