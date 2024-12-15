namespace Backend
{
    using System;

    public abstract class Specie
    {
        protected double temperaturaIdeal;
        public double probProcriar;
        public int tempoGravidez;
        public Specie(double temperaturaIdeal, double probProcriar, int timePregnant)
        {
            this.temperaturaIdeal = temperaturaIdeal;
            this.probProcriar = probProcriar;
            this.tempoGravidez = timePregnant;
        }

        public double getTemperaturaIdeal(){
            return temperaturaIdeal;
        }

        public double getProbProcriar(){
            return probProcriar;
        }

        public int getTempoGravidez(){
            return tempoGravidez;
        }


        public void setTemperaturaIdeal(double temperaturaIdeal){
            this.temperaturaIdeal = temperaturaIdeal;
        }

        public void setProbProcriar(double probProcriar){
            this.probProcriar = probProcriar;
        }

        public void setTempoGravidez(int tempoGravidez){
            this.tempoGravidez=tempoGravidez;
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

        public override string ToString(){
            return "=[temperaturaIdeal="+temperaturaIdeal+ ", probProcriar="+probProcriar + ", tempoGravidez="+tempoGravidez+ "]";
        }
    }
}


