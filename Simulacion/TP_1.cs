using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Simulacion.Modelos;

namespace Simulacion
{
    public partial class TP_1 : Form
    {
        private GeneradorMixto aleatorioMixtos { get; set; }
        private GeneradorMultiplicativo aleatorioMultiplicativo { get; set; }
        private GeneradorLenguaje aleatorioLenguaje { get; set; }
        private List<Generado> listaAleatoriosMultiplicativos { get; set; }
        private List<Generado> listaAleatoriosMixtos{ get; set; }
        private List<Generado> listaAleatoriosLenguaje { get; set; }

        public TP_1()
        {
            InitializeComponent();
            aleatorioMixtos= new GeneradorMixto();
            aleatorioMultiplicativo = new GeneradorMultiplicativo();
            aleatorioLenguaje = new GeneradorLenguaje();

            btn_generar_aleatorio_mixto.Enabled = false;
            btn_generar_aleatorio_multiplicativo.Enabled = false;
        }

        /// <summary>
        /// Metodo que inicializa las dos listas y las dos grillas
        /// </summary>
        public void inicializarGrilla()
        {
            listaAleatoriosMixtos = new List<Generado>();
            listaAleatoriosMultiplicativos = new List<Generado>();
            listaAleatoriosLenguaje = new List<Generado>();

            grilla_multiplicativo.Rows.Clear();
            grilla_mixto.DataSource = null;
            grilla_aleatorios_lenguaje.Rows.Clear();

            aleatorioMixtos = new GeneradorMixto();
            aleatorioMultiplicativo = new GeneradorMultiplicativo();
            aleatorioLenguaje = new GeneradorLenguaje();
        }

        /// <summary>
        /// Evento que genera 20 nros aleatorios por el metodo congruencial mixto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_generar_aleatorios_Click(object sender, EventArgs e)
        {
            inicializarGrilla();

            try
            {
                aleatorioMixtos.Semilla = double.Parse(txt_semilla.Text);
                aleatorioMixtos.C = double.Parse(txt_c.Text);
                aleatorioMixtos.A = double.Parse(txt_a.Text);
                aleatorioMixtos.M = double.Parse(txt_m.Text);

                //Pregunto si el textbox de cantidad de aleatorios mixtos tiene una cantidad, si es asi establesco la cantidad
                //sino por defecto establezco que es 20
                var contador = txt_cantidad_aleatorios_mixto.Text != string.Empty
                    ? int.Parse(txt_cantidad_aleatorios_mixto.Text)
                    : 20;


                for (int i = 0; i < contador; i++)
                {
                    aleatorioMixtos.GenerarAleatorio(i);

                    listaAleatoriosMixtos.Add(new Generado()
                    {
                        NumAleatorio = aleatorioMixtos.Generado.NumAleatorio,
                        Iteracion = aleatorioMixtos.Generado.Iteracion
                    });

                }

                //Bindeo la lista
                grilla_mixto.DataSource = listaAleatoriosMixtos;

                

                btn_generar_aleatorio_mixto.Enabled = true;
            }
            catch (Exception)
            {

                MessageBox.Show("Ingrese los valores obligatorios!!");
            }


        }

        /// <summary>
        /// Retorna el numero con la cantidad de digitos despues de la coma indicados por parametro
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public double TruncateFunction(double number, int digits)
        {
            double stepper = (double)(Math.Pow(10.0, (double)digits));
            int temp = (int)(stepper * number);
            return (double)temp / stepper;
        }

        /// <summary>
        /// A partir del campo g, genera el valor m para el metodo congruencial mixto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_k_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var k = double.Parse(this.txt_k.Text);
                aleatorioMixtos.CalcularA(k);

                txt_a.Text = aleatorioMixtos.A.ToString();
                txt_a.Enabled = false;

            }
            catch (Exception)
            {
                txt_a.Text = "";
                Console.Write(e.ToString());
            }

        }

        /// <summary>
        /// A partir del campo g, genera el valor m para el metodo congruencial mixto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_g_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var g = double.Parse(this.txt_g.Text);
                aleatorioMixtos.CalcularM(g);

                txt_m.Text = aleatorioMixtos.M.ToString();
                txt_m.Enabled = false;
            }
            catch (Exception)
            {
                txt_m.Text = "";
                Console.Write(e.ToString());
            }
            
        }

        /// <summary>
        /// Reestablece los campos y la grilla del apartado del congruencial mixto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reestablecer_panel_multiplicativo_Click(object sender, EventArgs e)
        {
            txt_a.Text = "";
            txt_c.Text = "";
            txt_g.Text = "";
            txt_k.Text = "";
            txt_m.Text = "";
            txt_semilla.Text = "";
            txt_cantidad_aleatorios_mixto.Text = "";

            txt_a.Enabled = true;
            txt_m.Enabled = true;

            btn_generar_aleatorio_mixto.Enabled = false;

            inicializarGrilla();
        }

        /// <summary>
        /// A partir de k genera el valor a para el metodo congruencial multiplicativo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_k_multiplicativo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var k = double.Parse(this.txt_k_multiplicativo.Text);
                aleatorioMultiplicativo.CalcularA(k);

                txt_a_multiplicativo.Text = aleatorioMultiplicativo.A.ToString();
                txt_a_multiplicativo.Enabled = false;

            }
            catch (Exception)
            {
                txt_a_multiplicativo.Text = "";
                Console.Write(e.ToString());
            }
        }

        /// <summary>
        /// A partir del campo g, genera el valor m para el metodo congruencial multiplicativo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_g_multiplicativo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var g = double.Parse(this.txt_g_multiplicativo.Text);
                aleatorioMultiplicativo.CalcularM(g);

                txt_m_multiplicativo.Text = aleatorioMultiplicativo.M.ToString();
                txt_m_multiplicativo.Enabled = false;
            }
            catch (Exception)
            {
                txt_m_multiplicativo.Text = "";
                Console.Write(e.ToString());
            }
        }

        /// <summary>
        /// Reestablece los campos y la grilla del apartado del congruencial multiplicativo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reestablecer_multiplicativo_Click(object sender, EventArgs e)
        {
            txt_a_multiplicativo.Text = "";
            txt_g_multiplicativo.Text = "";
            txt_k_multiplicativo.Text = "";
            txt_m_multiplicativo.Text = "";
            txt_semilla_multiplicativo.Text = "";
            txt_cantidad_aleatorios_multiplicativo.Text = "";

            txt_a_multiplicativo.Enabled = true;
            txt_m_multiplicativo.Enabled = true;

            btn_generar_aleatorio_multiplicativo.Enabled = false;

            inicializarGrilla();
        }


        /// <summary>
        /// Evento que genera 20 nros aleatorios por el metodo congruencial multiplicativo 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_generar_aleatorios_multiplicativo_Click(object sender, EventArgs e)
        {
            inicializarGrilla();

            try
            {
                aleatorioMultiplicativo.Semilla = double.Parse(txt_semilla_multiplicativo.Text);
                aleatorioMultiplicativo.A = double.Parse(txt_a_multiplicativo.Text);
                aleatorioMultiplicativo.M = double.Parse(txt_m_multiplicativo.Text);

                //Agrego a la grilla la semilla
                grilla_multiplicativo.Rows.Add(0,
                                           aleatorioMultiplicativo.Semilla,
                                           0);

                //Pregunto si el textbox de cantidad de aleatorios multiplicativos tiene una cantidad, si es asi establesco la cantidad
                //sino por defecto establezco que es 20
                var contador = txt_cantidad_aleatorios_multiplicativo.Text != string.Empty
                    ? int.Parse(txt_cantidad_aleatorios_multiplicativo.Text)
                    : 20;

                for (int i = 0; i < contador; i++)
                {
                    aleatorioMultiplicativo.generarAleatorio();

                    listaAleatoriosMultiplicativos.Add(new Generado()
                    {
                        NumAleatorio = aleatorioMultiplicativo.Generado.NumAleatorio,
                        Iteracion = aleatorioMultiplicativo.Generado.Iteracion
                    });

                    grilla_multiplicativo.Rows.Add(1,
                        aleatorioMultiplicativo.Semilla,
                        TruncateFunction(aleatorioMultiplicativo.Generado.NumAleatorio, 4));
                }

               

                btn_generar_aleatorio_multiplicativo.Enabled = true;

            }
            catch (Exception)
            {

                MessageBox.Show("Ingrese los valores obligatorios!!");
            }

        }


        /// <summary>
        /// Evento que permite obtener un aleatorio mixto a la vez
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_generar_aleatorio_1_Click(object sender, EventArgs e)
        {
            var aleatorio = aleatorioMixtos.GenerarAleatorio(1);

            listaAleatoriosMixtos.Add(new Generado()
            {
                NumAleatorio = aleatorio.NumAleatorio,
                Iteracion = listaAleatoriosMixtos.Count -1
            });


            var ultimo = grilla_mixto.Rows.Count;

            grilla_mixto.Rows.Add(ultimo - 1, 
                                  aleatorioMixtos.Semilla,
                TruncateFunction(aleatorioMixtos.Generado.NumAleatorio, 4));
        }

        /// <summary>
        /// Evento que permite obtener un aleatorio multiplicativo a la vez
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_generar_aleatorio_multiplicativo_Click(object sender, EventArgs e)
        {
            listaAleatoriosMultiplicativos.Add(new Generado()
            {
                NumAleatorio = aleatorioMultiplicativo.Generado.NumAleatorio,
                Iteracion=  aleatorioMultiplicativo.Generado.Iteracion
            });

            var ultimo = grilla_multiplicativo.Rows.Count;

            grilla_multiplicativo.Rows.Add(ultimo - 1,
                aleatorioMultiplicativo.Semilla,
                TruncateFunction(aleatorioMultiplicativo.Generado.NumAleatorio, 4));
        }

        /// <summary>
        /// Evento que llama al form Grafico1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_graficar_mixto_Click(object sender, EventArgs e)
        {
            try
            {
                var lista = listaAleatoriosMixtos;

              /*  var lista = new List<Generado>();

                lista.Add(new Generado(0.15));
                lista.Add(new Generado(0.22));
                lista.Add(new Generado(0.41));
                lista.Add(new Generado(0.65));
                lista.Add(new Generado(0.84));
                lista.Add(new Generado(0.81));
                lista.Add(new Generado(0.62));
                lista.Add(new Generado(0.45));
                lista.Add(new Generado(0.32));
                lista.Add(new Generado(0.07));
                lista.Add(new Generado(0.11));
                lista.Add(new Generado(0.29));
                lista.Add(new Generado(0.58));
                lista.Add(new Generado(0.73));
                lista.Add(new Generado(0.93));
                lista.Add(new Generado(0.97));
                lista.Add(new Generado(0.79));
                lista.Add(new Generado(0.55));
                lista.Add(new Generado(0.35));
                lista.Add(new Generado(0.09));
                lista.Add(new Generado(0.99));
                lista.Add(new Generado(0.51));
                lista.Add(new Generado(0.35));
                lista.Add(new Generado(0.02));
                lista.Add(new Generado(0.19));
                lista.Add(new Generado(0.24));
                lista.Add(new Generado(0.98));
                lista.Add(new Generado(0.10));
                lista.Add(new Generado(0.31));
                lista.Add(new Generado(0.17));
                */

                Grafica1 ventana = new Grafica1(lista, int.Parse(txt_cantidad_intervalos_mixto.Text));
                ventana.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese la cantidad de intervalos ó genere la lista de aleatorios a mandar previamente!");
            }
            
        }

        /// <summary>
        /// Evento que llama al form Grafico1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_graficar_multiplicativo_Click(object sender, EventArgs e)
        {
            try
            {
                var lista = listaAleatoriosMultiplicativos;

                Grafica1 ventana = new Grafica1(lista, int.Parse(txt_cantidad_intervalos_multiplicativo.Text));
                ventana.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese la cantidad de intervalos ó genere la lista de aleatorios a mandar previamente!");
            }
        }

        /// <summary>
        /// Evento que genera x cantidad de aleatorios, de acuerdo a la cantidad que ingrese el usuario
        /// por el metodo provisto por el lenguaje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_generar_aleatorios_lenguaje_Click(object sender, EventArgs e)
        {
            inicializarGrilla();

            try
            {
               //Pregunto si el textbox de cantidad de aleatorios multiplicativos tiene una cantidad, si es asi establesco la cantidad
                //sino por defecto establezco que es 20
                var contador = int.Parse(txt_cantidad_aleatorios_lenguaje.Text);

                for (int i = 0; i < contador; i++)
                {

                    aleatorioLenguaje.generarAleatorio();

                    listaAleatoriosLenguaje.Add(new Generado()
                    {
                        NumAleatorio = aleatorioLenguaje.Generado.NumAleatorio
                    });

                   /* grilla_aleatorios_lenguaje.Rows.Add(i + 1,
                        TruncateFunction(aleatorioLenguaje.Generado.NumAleatorio, 4));*/
                }

                grilla_aleatorios_lenguaje.DataSource = listaAleatoriosLenguaje;
            }
            catch (Exception)
            {

                MessageBox.Show("Ingrese la cantidad de aleatorios a generar!!");
            }
        }

        /// <summary>
        /// Evento que llama al form Grafica1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_generar_grafica_lenguaje_Click(object sender, EventArgs e)
        {
            try
            {
                var lista = listaAleatoriosLenguaje;

                Grafica1 ventana = new Grafica1(lista, int.Parse(txt_cantidad_intervalos_lenguaje.Text));
                ventana.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese la cantidad de intervalos ó genere la lista de aleatorios a mandar previamente!");
            }
        }

        /// <summary>
        /// Reestablece los campos y la grilla del apartado del generador propio del lenguaje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reestablecer_lenguaje_Click(object sender, EventArgs e)
        { 
            txt_cantidad_aleatorios_lenguaje.Text = "";
            txt_cantidad_intervalos_lenguaje.Text = "";

            inicializarGrilla();
        }
    }
}
