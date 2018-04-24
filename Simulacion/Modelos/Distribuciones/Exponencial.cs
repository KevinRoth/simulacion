using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meta.Numerics.Statistics.Distributions;

namespace Simulacion.Modelos.Distribuciones
{
    public class Exponencial : Distribucion
    {
        public double Lambda { get; set; }
        public Generado Generado { get; protected set; }
        public GeneradorLenguaje Generador { get; protected set; }

        public Exponencial()
        {
            Generado = new Generado();
            Generador = new GeneradorLenguaje();
        }

        public bool VerificarLambda()
        {
            return Lambda > 0;
        }

        /// <summary>
        /// Genera una variable aleatoria del tipo de distribucion Poisson
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Generado GenerarVariableAleatoria(int i)
        {
            var x = (-1 / Lambda) * Math.Log(1 - Generador.GenerarAleatorio(i).NumAleatorio);

            Generado.NumAleatorio = x;
            Generado.Iteracion = i;

            return Generado;
        }

        /// <summary>
        /// Metodo que calcula la frecuencia esperada en un intervalo
        /// </summary>
        /// <param name="intervalo"></param>
        /// <param name="tamanioMuestra"></param>
        /// <param name="cantidadIntervalos"></param>
        /// <returns></returns>
        public override double CalcularFrecuenciaEsperadaEnIntervalo(Intervalo intervalo, int tamanioMuestra, int cantidadIntervalos)
        {
            var distribucion = new ExponentialDistribution(1 / Lambda);

            var probabilidadEsperada = distribucion.LeftProbability(intervalo.LimiteSuperior) -
                                       distribucion.LeftProbability(intervalo.LimiteInferior);

            return probabilidadEsperada * tamanioMuestra;
        }
    }
}