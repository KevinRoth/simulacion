using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulacion.Modelos
{
    public class GeneradorMixto 
    {
        public double A { set; get; }
        public double C { set; get; }
        public double M { set; get; }
        public Generado Generado { get; set; }
        public double ProximaSemilla { get; set; }
        public double Semilla { get; set; }

        public GeneradorMixto()
        {
            Generado = new Generado();
        }
        
        /// <summary>
        /// Metodo que permite calcular a
        /// </summary>
        /// <param name="k"></param>
        public void CalcularA(double k)
        {
            A = 1 + 4 * k;
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
            ProximaSemilla = (((A * Semilla) + C) % M);   // = [(a.xi + c) mod m]

            Semilla = ProximaSemilla;

            Generado.NumAleatorio = ProximaSemilla / M;

            Generado.Iteracion = i;

            return Generado;
        }
    }
}
