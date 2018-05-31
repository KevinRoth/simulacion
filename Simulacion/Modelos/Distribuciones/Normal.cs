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

            //Hacemos la sumatoria de randoms
            for (int j = 0; j < 12; j++)
            {
                sumatoriaRandoms += Generador.GenerarAleatorio(i).NumAleatorio;
            }

            //Aplicamos la formula
            var x = (sumatoriaRandoms - 6) * DesviacionEstandar + Media;

            Generado.NumAleatorio = x;
            Generado.Iteracion = i;

            return Generado;
        }

        /// <summary>
        /// Metodo que verifica que la Desviacion sea mayor a 0
        /// </summary>
        /// <returns></returns>
        public bool VerificarDesviacion()
        {
            return DesviacionEstandar > 0;
        }

        /// <summary>
        /// Metodo que calcula la frecuencia esperada en un intervalo
        /// </summary>
        /// <param name="intervalo"></param>
        /// <param name="tamanioMuestra"></param>
        /// <param name="cantidadIntervalos"></param>
        /// <returns></returns>
        public override double CalcularFrecuenciaEsperadaEnIntervalo(Intervalo intervalo, int tamanioMuestra, int cantidadIntervalos = 0)
        {
            var distribucion = new NormalDistribution(Media, DesviacionEstandar);

            var probabilidadEsperada = distribucion.LeftProbability(intervalo.LimiteSuperior) -
                                       distribucion.LeftProbability(intervalo.LimiteInferior);

            return probabilidadEsperada * tamanioMuestra;
        }
    }
}
