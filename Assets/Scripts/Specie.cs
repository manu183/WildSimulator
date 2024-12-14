namespace Backend
{
    using System;

    public abstract class Specie
    {
        protected readonly double temperaturaIdeal;
        public readonly double probProcriar;
        public readonly int tempoGravidez;
        public Specie(double temperaturaIdeal, double probProcriar, int timePregnant)
        {
            this.temperaturaIdeal = temperaturaIdeal;
            this.probProcriar = probProcriar;
            this.tempoGravidez = timePregnant;
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


