using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Modelos.Distribuciones
{
    public class Poisson : Distribucion
    {
        public double Lambda { get; set; }
        public Generado Generado { get; protected set; }
        public GeneradorLenguaje Generador { get; protected set; }

        public Poisson()
        {
            Generado = new Generado();
            Generador = new GeneradorLenguaje();
        }

        public Generado GenerarVariableAleatoria(int i)
        {
            var P = 1.0;
            var X = -1;
            var A = Math.Exp(-1 * Lambda);

            do
            {
                var random = Generador.GenerarAleatorio(i).NumAleatorio;

                P = P * random;

                X++;

            } while (P >= A);

            Generado.NumAleatorio = X;
            Generado.Iteracion = i;

            return Generado;
        }

        public bool VerificarLambda()
        {
            return Lambda > 0;
        }

        public override double CalcularFrecuenciaEsperadaEnIntervalo(Intervalo intervalo, int tamanioMuestra, int cantidadIntervalos = 0)
        {
            throw new NotImplementedException();
        }
    }
}
