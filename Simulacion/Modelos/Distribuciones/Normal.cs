using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meta.Numerics.Statistics.Distributions;

namespace Simulacion.Modelos.Distribuciones
{
    public class Normal : Distribucion
    {
        public double Media { get; set; }
        public double DesviacionEstandar { get; set; }
        public Generado Generado { get; set; }
        public GeneradorLenguaje Generador { get; set; }

        public Normal()
        {
            Generado = new Generado();
            Generador = new GeneradorLenguaje();
        }

        /// <summary>
        /// Metodo que genera variable de acuerdo a la distribucion normal por el metodo de convolucion
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Generado GenerarVariableAleatoria(int i)
        {
            var sumatoriaRandoms = 0.0;

            for (int j = 0; j < 12; j++)
            {
                sumatoriaRandoms += Generador.GenerarAleatorio(i).NumAleatorio;
            }

            var x = (sumatoriaRandoms - 6) * DesviacionEstandar + Media;

            Generado.NumAleatorio = x;
            Generado.Iteracion = i;

            return Generado;
        }

        public bool VerificarMedia()
        {
            return Media > 0;
        }

        public bool VerificarDesviacion()
        {
            return DesviacionEstandar > 0;
        }

        public override double CalcularFrecuenciaEsperadaEnIntervalo(Intervalo intervalo, int tamanioMuestra, int cantidadIntervalos = 0)
        {
            var distribucion = new NormalDistribution(Media, DesviacionEstandar);

            var probabilidadEsperada = distribucion.LeftProbability(intervalo.LimiteSuperior) -
                                       distribucion.LeftProbability(intervalo.LimiteInferior);

            return probabilidadEsperada * tamanioMuestra;
        }
    }
}
