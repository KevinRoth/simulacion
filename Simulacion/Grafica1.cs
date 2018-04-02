using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simulacion.Modelos;
using LinqStatistics;
using LinqStatistics.NaN;

namespace Simulacion
{
    public partial class Grafica1 : Form
    {
        List<Generado> lista;
        double chi;
        int intervalos;
        Subintervalos[] sub_intervalos; //vector de subintervalos

        public Grafica1(List<Generado> lista, int intervalos)
        {
            InitializeComponent();
            this.lista = lista;
            this.intervalos = intervalos;
            cargarHistograma();
        }

        /// <summary>
        /// Metodo que permite cargar el histograma
        /// </summary>
        private void cargarHistograma()
        {
            //creo los subintervalos del histograma
            sub_intervalos = new Subintervalos[intervalos];

            //A partir de la cantidad de intervalos, calculamos sus limites
            for (int i = 0; i < intervalos; i++)
            {
                if (i == 0)
                    sub_intervalos[i] = new Subintervalos(0, ((float) 1 / intervalos) * (i + 1));
                else
                {
                    sub_intervalos[i] = new Subintervalos(sub_intervalos[i - 1].LimiteSuperior,
                        ((float) 1 / intervalos) * (i + 1));
                }
            }

            //ahora recorremos la lista para calcular las frecuencias.
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 0; j < sub_intervalos.Length; j++)
                {
                    if (lista[i].NumAleatorio >= sub_intervalos[j].LimiteInferior &&
                        lista[i].NumAleatorio <= sub_intervalos[j].LimiteSuperior)
                    {
                        sub_intervalos[j].CantidadObservaciones++;
                    }

                }
            }

            //limpiamos el chart y preparamos el nuevo histograma
            List<int> listaEnteros = new List<int>(); //lista para acumular las cantidades de cada intervalo y luego poder obtener el MAX()
            histogramaGenerado.Series.Clear();
            histogramaGenerado.Series.Add("Frecuecias Observadas");

            //cargamos el histograma con la cantidad de observaciones de cada intervalo
            for (int i = 0; i < intervalos; i++)
            {
                listaEnteros.Add(sub_intervalos[i].CantidadObservaciones);
                histogramaGenerado.Series[0].Points.Add(sub_intervalos[i].CantidadObservaciones);
                histogramaGenerado.Series[0].Points[i].AxisLabel =
                    "[" + sub_intervalos[i].LimiteInferior + " - " + sub_intervalos[i].LimiteSuperior + "]";
                histogramaGenerado.Series[0].IsValueShownAsLabel = true;
            }

            //Obtenemos la cantidad total de observaciones
            double cantidadObservaciones = double.Parse(lista.Count.ToString());
            histogramaGenerado.ChartAreas[0].AxisY.Maximum = listaEnteros.Max();

            //Obtenemos la frecuencia esperada de la serie
            double freEsperada = (double) cantidadObservaciones / (double) intervalos;
            lblFrecuenciaEsperada.Text = freEsperada.ToString();
            histogramaGenerado.Series["Frecuecias Observadas"].Color = Color.DarkGray;

            //llamada al metodo para cargar la tabla de frecuencias
            cargarTabla();

        }

        private void cargarTabla()
        {
            List<double> list = new List<double>();
            List<double> esp = new List<double>();


            for (int i = 0; i < sub_intervalos.Length; i++)
            {
                string subint = sub_intervalos[i].LimiteInferior + " - " + sub_intervalos[i].LimiteSuperior;
                double freEsp = lista.Count / intervalos;
                var suma = Math.Pow((sub_intervalos[i].CantidadObservaciones - freEsp), 2) / freEsp;

                dataGridView1.Rows.Add(subint, 
                                       sub_intervalos[i].CantidadObservaciones, 
                                       freEsp, 
                                       suma );

                chi += Math.Pow(sub_intervalos[i].CantidadObservaciones - freEsp, 2) / freEsp;

            }

            label1.Text = Convert.ToString(chi);
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

