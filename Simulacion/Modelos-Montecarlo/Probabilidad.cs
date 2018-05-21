using System;

namespace Montecarlo.TablaDistribucion
{
    public class Probabilidad
    {
        public Probabilidad(double valor, double probabilidadAsociada)
        {
            if (probabilidadAsociada < 0 || probabilidadAsociada >1)
                throw new NotSupportedException("La probabilidad asociada debe ser entre 0 y 1");

            Valor = valor;
            ProbabilidadAsociada = probabilidadAsociada;
        }

        public double Valor { get; protected set; }
        public double ProbabilidadAsociada { get; protected set; }
    }
}
