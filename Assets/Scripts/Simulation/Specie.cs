namespace Backend
{
    using System;

    public abstract class Specie
    {
        protected double temperaturaIdeal;
        public double probProcriar;
        public int tempoGravidez;

        public int idadeMedia;


        public double toleracaoTemperatura;

        public Specie(double temperaturaIdeal, double probProcriar, int timePregnant, int idadeMedia, double toleracaoTemperatura)
        {
            this.temperaturaIdeal = temperaturaIdeal;
            this.probProcriar = probProcriar;
            this.tempoGravidez = timePregnant;
            this.idadeMedia = idadeMedia;
            this.toleracaoTemperatura = toleracaoTemperatura;
        }

        public double GetTemperaturaIdeal()
        {
            return temperaturaIdeal;
        }

        public double GetProbProcriar()
        {
            return probProcriar;
        }

        public int GetTempoGravidez()
        {
            return tempoGravidez;
        }

        public int GetIdadeMedia()
        {
            return idadeMedia;
        }
        public double GetToleracaoTemperatura()
        {
            return toleracaoTemperatura;
        }


        public void SetTemperaturaIdeal(double temperaturaIdeal)
        {
            this.temperaturaIdeal = temperaturaIdeal;
        }

        public void SetProbProcriar(double probProcriar)
        {
            this.probProcriar = probProcriar;
        }

        public void SetTempoGravidez(int tempoGravidez)
        {
            this.tempoGravidez = tempoGravidez;
        }

        public void SetIdadeMedia(int idadeMedia)
        {
            this.idadeMedia = idadeMedia;
        }
        public void SetToleracaoTemperatura(double toleracaoTemperatura)
        {
            this.toleracaoTemperatura = toleracaoTemperatura;
        }



        public abstract int GetNrOfKids();


        public double ProbabilidadeSobreviver(double T, double desvio)
        {
            double numerador = Math.Pow(T - temperaturaIdeal, 2);
            double denominador = 2 * Math.Pow(desvio, 2);
            double resultado = Math.Exp(-numerador / denominador);
            return resultado;
        }

        public override string ToString()
        {
            return "=[temperaturaIdeal=" + temperaturaIdeal + ", probProcriar=" + probProcriar + ", tempoGravidez=" + tempoGravidez + ",IdadeMedia="+idadeMedia +", toleranciaTemperatura="+toleracaoTemperatura+ "]";
        }

        public int GetMaxAge()
        {
            return (int)Math.Round(Distributions.BimodalTruncated(0, 5, 0.1, GetIdadeMedia(), 20, 0.9));
        }

        public double GetDesvioTemp()
        {
            return Distributions.Normal(GetToleracaoTemperatura(), 6);
        }
    }
}


