using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Modelos.Distribuciones
{
    public class Uniforme : Distribucion
    {
        public double A { get; set; }
        public double B { get; set; }
        public Generado Generado { get; protected set; }
        public GeneradorLenguaje Generador { get; protected set; }

        public Uniforme()
        {
            Generado = new Generado();
            Generador = new GeneradorLenguaje();

        }

        public Uniforme(double a, double b)
        {
            A = a;
            B = b;
        }

        /// <summary>
        /// Metodo que permite conocer si B es mayor a A
        /// Devuelve true si B > A
        /// </summary>
        /// <returns></returns>
        public bool CompararAB()
        {
            return B > A;
        }

        /// <summary>
        /// Genera una variable aleatoria del tipo de distribucion 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Generado GenerarVariableAleatoria(int i = 0)
        {
            var x = A + Generador.GenerarAleatorio(i).NumAleatorio * (B - A);

            Generado.NumAleatorio = x;
            Generado.Iteracion = i;
            

            return Generado;
        }
        public Generado GenerarVariableAleatoria(double random)
        {
            var x = A + random * (B - A);
            Generado = new Generado();

            Generado.NumAleatorio = x;
            Generado.Iteracion = 0;


            return Generado;
        }

        public double GenerarVariableAleatoria()
        {
            return A + Generador.GenerarAleatorio(0).NumAleatorio * (B - A);
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
            return tamanioMuestra / cantidadIntervalos;
        }
    }
}
