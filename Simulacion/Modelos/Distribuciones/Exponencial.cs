using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Generado GenerarVariableAleatoria(int i)
        {
            var x = (-1 / Lambda) * Math.Log10(1 - Generador.GenerarAleatorio(i).NumAleatorio);

            Generado.NumAleatorio = x;
            Generado.Iteracion = i;

            return Generado;
        }

        public override double CalcularFrecuenciaEsperadaEnIntervalo(Intervalo intervalo, int tamanioMuestra, int cantidadIntervalos)
        {
            var probabilidadEsperada = (1 - Math.Pow(Math.E, ((-Lambda) * intervalo.LimiteSuperior))) -
                                       (1 - Math.Pow(Math.E, ((-Lambda) * intervalo.LimiteInferior)));

            return probabilidadEsperada * tamanioMuestra;
        }
    }
}