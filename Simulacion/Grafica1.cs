using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Simulacion.Modelos;

namespace Simulacion
{
    public partial class Grafica1 : Form
    {
        private readonly List<Generado> lista;
        double chi;
        private readonly int cantidadIntervalos;
        Intervalo[] intervalos; //vector de subintervalos

        public Grafica1(List<Generado> lista, int cantidadIntervalos)
        {
            InitializeComponent();
            this.lista = lista;
            this.cantidadIntervalos = cantidadIntervalos;
            CargarHistograma();
        }

        /// <summary>
        /// Metodo que permite cargar el histograma
        /// </summary>
        private void CargarHistograma()
        {
            //creo los intervalos del histograma
            intervalos = new Intervalo[cantidadIntervalos];

            //A partir de la cantidad de cantidadIntervalos, calculamos sus limites
            //Intervalo [a,b)
            for (var i = 0; i < cantidadIntervalos; i++)
            {
                if (i == 0)
                    intervalos[i] = new Intervalo(0, ((double) 1 / cantidadIntervalos) * (i + 1));
                else
                {
                    intervalos[i] = new Intervalo(intervalos[i - 1].LimiteSuperior,
                        ((double) 1 / cantidadIntervalos) * (i + 1));
                }
            }

            //ahora recorremos la lista para calcular las frecuencias.
            foreach (var t1 in lista)
            {
                foreach (var t in intervalos)
                {
                    if (t1.NumAleatorio >= t.LimiteInferior &&
                        t1.NumAleatorio < t.LimiteSuperior)
                    {
                        t.CantidadObservaciones++;
                    }
                }
            }

            //limpiamos el chart y preparamos el nuevo histograma
            List<int> listaEnteros = new List<int>(); //lista para acumular las cantidades de cada intervalo y luego poder obtener el MAX()
            histogramaGenerado.Series.Clear();
            histogramaGenerado.Series.Add("Frecuecias Observadas");

            //cargamos el histograma con la cantidad de observaciones de cada intervalo
            for (int i = 0; i < cantidadIntervalos; i++)
            {
                listaEnteros.Add(intervalos[i].CantidadObservaciones);
                histogramaGenerado.Series[0].Points.Add(intervalos[i].CantidadObservaciones);
                histogramaGenerado.Series[0].Points[i].AxisLabel =
                    "[" + intervalos[i].LimiteInferior + " - " + intervalos[i].LimiteSuperior + "]";
                histogramaGenerado.Series[0].IsValueShownAsLabel = true;
            }

            //Obtenemos la cantidad total de observaciones
            double cantidadObservaciones = double.Parse(lista.Count.ToString());
            histogramaGenerado.ChartAreas[0].AxisY.Maximum = listaEnteros.Max();

            //Obtenemos la frecuencia esperada de la serie
            double freEsperada = (double) cantidadObservaciones / (double) cantidadIntervalos;
            lblFrecuenciaEsperada.Text = freEsperada.ToString();
            histogramaGenerado.Series["Frecuecias Observadas"].Color = Color.DarkGray;

            //llamada al metodo para cargar la tabla de frecuencias
            CargarTabla();

        }

        /// <summary>
        /// Metodo que permite cargar la tabla de frecuencias
        /// </summary>
        private void CargarTabla()
        {
           foreach (var t in intervalos)
            {
                string subint = t.LimiteInferior + " - " + t.LimiteSuperior;
                double freEsp = lista.Count / cantidadIntervalos;
                var suma = Math.Pow((t.CantidadObservaciones - freEsp), 2) / freEsp;

                dataGridView1.Rows.Add(subint, 
                    t.CantidadObservaciones, 
                    freEsp, 
                    suma);

                //Vamos acumulando chi observado
                chi += suma;
            }

            label1.Text = chi.ToString();
        }

        /// <summary>
        /// Evento que permite comprobar la prueba de bondad de ajuste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_compro_Click_1(object sender, EventArgs e)
        {
            if (chi < double.Parse(txt_chicierto.Text))
            {
                MessageBox.Show("Se acepta la hipotesis nula");
            }
            else
            {
                MessageBox.Show("Se rechaza la hipotesis nula");
            }
        }
    }
}

