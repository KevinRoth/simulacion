using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var marcaClase = (intervalo.LimiteSuperior + intervalo.LimiteInferior) / 2;
            var primero = Math.Pow((marcaClase - Media) / DesviacionEstandar, 2);
            var segundo = DesviacionEstandar * (Math.Sqrt(Math.PI * 2));
            var calculo1 = Math.Pow(Math.E, -0.5 * primero);
            var res = calculo1 / segundo;
            var probEsperada = res * (intervalo.LimiteSuperior - intervalo.LimiteInferior);

            return probEsperada * tamanioMuestra;
        }
    }
}
