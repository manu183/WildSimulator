namespace Backend
{
    using System;
    using System.Data;
    using System.Runtime.ConstrainedExecution;

    public class Day
    {

        private static int totalDays = 0;


        public readonly double temperature;
        public readonly int disasterType;
        public readonly int nrDay;


        public Day()
        {
            temperature = SetTemperature();
            disasterType = SetDisasterType();
            totalDays++;
            nrDay = totalDays;
        }
        private static int SetDisasterType()
        {
            double r = Simulation.random.NextDouble();
            if (r < 0.8)
                return 1;
            if (r < 0.95)
                return 2;
            if (r < 0.985)
                return 3;
            else
                return 4;
            // TO DO USING V.A. OF DISASTER GRAPH 
        }

        private static readonly double[] avrTemp = { 0, 4, 9.5, 14, 17.5, 20, 21.5, 22, 21.5, 20, 17.5, 14, 9.5 };
        private double SetTemperature()
        {
            double temp = getAvrTemp();
            return Distributions.Normal(temp, 5);
        }

        private double getAvrTemp()
        {
            DateTime dataInicial = new DateTime(1, 5, 1); //Começa em maio
            DateTime dataFinal = dataInicial.AddDays(nrDay);
            return avrTemp[dataFinal.Month];
        }


    }
}