using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Montecarlo.TablaDistribucion
{
    public class DistribucionAleatoria
    {
        public DistribucionAleatoria(IList<Probabilidad> valores)
        {
            Valores = valores ?? new List<Probabilidad>();

            GenerarTablaRandom();
        }

        public DistribucionAleatoria(double valor, double probabilidadAsociada)
        {
            var probabilidad = new Probabilidad(valor, probabilidadAsociada);

            Valores = new List<Probabilidad>() {probabilidad};

            GenerarTablaRandom();
        }

        public void AgregarProbabilidad(Probabilidad probabilidad)
        {
            Valores.Add(probabilidad);

            GenerarTablaRandom();
        }

        public void AgregarProbabilidad(double valor, double probabilidadAsociada)
        {
            var probabilidad = new Probabilidad(valor, probabilidadAsociada);

            Valores.Add(probabilidad);

            GenerarTablaRandom();
        }

        private void GenerarTablaRandom()
        {
            if (Valores.Sum(v => v.ProbabilidadAsociada) > 1)
                throw new NotSupportedException("La suma de las probabilidades no puede ser mayor a 1");

            Valores = Valores.OrderBy(v => v.Valor).ToList();
            RandomAsociados = new List<double> {0};

            for (var i = 1; i < Valores.Count; i++)
            {
                RandomAsociados.Add(RandomAsociados[i - 1] + Valores[i - 1].ProbabilidadAsociada);
            }
        }

        public double ObtenerValor()
        {
            Thread.Sleep(20);

            var random = new Random().NextDouble();

            return ObtenerValor(random);
        }

        public double ObtenerValor(double random)
        {
            if (random < 0 || random > 1)
                throw new NotSupportedException("El número aleatorio debe estar entre 0 y 1");

            for (var i = 1; i < RandomAsociados.Count; i++)
            {
                if (random < RandomAsociados[i])
                    return Valores[i - 1].Valor;
            }

            return Valores.Last().Valor;
        }

        private IList<Probabilidad> Valores { get; set; }
        private IList<double> RandomAsociados { get; set; }
    }
}
