using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulacion.Modelos;

namespace Simulacion.Modelos
{
    public class GeneradorMultiplicativo 
    {
        public double A { set; get; }
        public double M { set; get; }
        public Generado Generado { get; set; }
        public double Semilla { get; set; }
        public double ProximaSemilla { get; set; }

        public GeneradorMultiplicativo()
        {
            Generado = new Generado();
        }

        /// <summary>
        /// Metodo que permite calcular a
        /// </summary>
        /// <param name="k"></param>
        public void CalcularA(double k)
        {
            A = 3 + 8 * k;
        }

        /// <summary>
        /// Metodo que permite calcular m
        /// </summary>
        /// <param name="g"></param>
        public void CalcularM(double g)
        {
            M = Math.Pow(2, g);
        }

        /// <summary>
        /// Metodo que genera un aleatorio y la semilla para la iteracion siguiente
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Generado GenerarAleatorio(int i)
        {
            ProximaSemilla = (((A * Semilla)) % M);   // = [(a.xi) mod m]

            Semilla = ProximaSemilla;

            Generado.NumAleatorio = ProximaSemilla / M;

            Generado.Iteracion = i;

            return Generado;
        }
    }
}
