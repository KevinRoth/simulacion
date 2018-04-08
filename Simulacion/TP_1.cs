using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Simulacion.Modelos;

namespace Simulacion
{
    public partial class TP_1 : Form
    {
        private GeneradorMixto AleatorioMixtos { get; set; }
        private GeneradorMultiplicativo AleatorioMultiplicativo { get; set; }
        private GeneradorLenguaje AleatorioLenguaje { get; set; }
        private List<Generado> ListaAleatoriosMultiplicativos { get; set; }
        private List<Generado> ListaAleatoriosMixtos{ get; set; }
        private List<Generado> ListaAleatoriosLenguaje { get; set; }

        public TP_1()
        {
            InitializeComponent();
            AleatorioMixtos= new GeneradorMixto();
            AleatorioMultiplicativo = new GeneradorMultiplicativo();
            AleatorioLenguaje = new GeneradorLenguaje();

            btn_generar_aleatorio_mixto.Enabled = false;
            btn_generar_aleatorio_multiplicativo.Enabled = false;
        }

        /// <summary>
        /// Metodo que inicializa las dos listas y las dos grillas
        /// </summary>
        public void InicializarGrilla()
        {
            ListaAleatoriosMixtos = new List<Generado>();
            ListaAleatoriosMultiplicativos = new List<Generado>();
            ListaAleatoriosLenguaje = new List<Generado>();

            grilla_multiplicativo.DataSource = null;
            grilla_mixto.DataSource = null;
            grilla_aleatorios_lenguaje.DataSource = null;

            AleatorioMixtos = new GeneradorMixto();
            AleatorioMultiplicativo = new GeneradorMultiplicativo();
            AleatorioLenguaje = new GeneradorLenguaje();
        }

        /// <summary>
        /// Evento que genera 20 nros aleatorios por el metodo congruencial mixto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_generar_aleatorios_Click(object sender, EventArgs e)
        {
            InicializarGrilla();

            try
            {
                AleatorioMixtos.Semilla = double.Parse(txt_semilla.Text);
                AleatorioMixtos.C = double.Parse(txt_c.Text);
                AleatorioMixtos.A = double.Parse(txt_a.Text);
                AleatorioMixtos.M = double.Parse(txt_m.Text);

                //Pregunto si el textbox de cantidad de aleatorios mixtos tiene una cantidad, si es asi establesco la cantidad
                //sino por defecto establezco que es 20
                var contador = txt_cantidad_aleatorios_mixto.Text != string.Empty
                    ? int.Parse(txt_cantidad_aleatorios_mixto.Text)
                    : 20;


                for (var i = 0; i < contador; i++)
                {
                    AleatorioMixtos.GenerarAleatorio(i);

                    ListaAleatoriosMixtos.Add(new Generado()
                    {
                        NumAleatorio = TruncateFunction(AleatorioMixtos.Generado.NumAleatorio, 4),
                        Iteracion = AleatorioMixtos.Generado.Iteracion
                    });

                }

                //Bindeo la lista
                grilla_mixto.DataSource = ListaAleatoriosMixtos;
                
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
                AleatorioMixtos.CalcularA(k);

                txt_a.Text = AleatorioMixtos.A.ToString();
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
                AleatorioMixtos.CalcularM(g);

                txt_m.Text = AleatorioMixtos.M.ToString();
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

            InicializarGrilla();
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
                AleatorioMultiplicativo.CalcularA(k);

                txt_a_multiplicativo.Text = AleatorioMultiplicativo.A.ToString();
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
                AleatorioMultiplicativo.CalcularM(g);

                txt_m_multiplicativo.Text = AleatorioMultiplicativo.M.ToString();
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

            InicializarGrilla();
        }


        /// <summary>
        /// Evento que genera 20 nros aleatorios por el metodo congruencial multiplicativo 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_generar_aleatorios_multiplicativo_Click(object sender, EventArgs e)
        {
            InicializarGrilla();

            try
            {
                AleatorioMultiplicativo.Semilla = double.Parse(txt_semilla_multiplicativo.Text);
                AleatorioMultiplicativo.A = double.Parse(txt_a_multiplicativo.Text);
                AleatorioMultiplicativo.M = double.Parse(txt_m_multiplicativo.Text);

                //Pregunto si el textbox de cantidad de aleatorios multiplicativos tiene una cantidad, si es asi establesco la cantidad
                //sino por defecto establezco que es 20
                var contador = txt_cantidad_aleatorios_multiplicativo.Text != string.Empty
                    ? int.Parse(txt_cantidad_aleatorios_multiplicativo.Text)
                    : 20;

                for (var i = 0; i < contador; i++)
                {
                    AleatorioMultiplicativo.GenerarAleatorio(i);

                    ListaAleatoriosMultiplicativos.Add(new Generado()
                    {
                        NumAleatorio = TruncateFunction(AleatorioMultiplicativo.Generado.NumAleatorio, 4),
                        Iteracion = AleatorioMultiplicativo.Generado.Iteracion
                    });
                }

                //bindeo la grilla con la lista
                grilla_multiplicativo.DataSource = ListaAleatoriosMultiplicativos;

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
            var aleatorio = AleatorioMixtos.GenerarAleatorio(ListaAleatoriosMixtos.Count);

            ListaAleatoriosMixtos.Add(new Generado()
            {
                NumAleatorio = TruncateFunction(aleatorio.NumAleatorio, 4),
                Iteracion = aleatorio.Iteracion
            });

            //Limpio el bindeo y luego bindeo nuevamente la grilla con la lista
            grilla_mixto.DataSource = null;
            grilla_mixto.DataSource = ListaAleatoriosMixtos;
        }

        /// <summary>
        /// Evento que permite obtener un aleatorio multiplicativo a la vez
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_generar_aleatorio_multiplicativo_Click(object sender, EventArgs e)
        {
            var aleatorio = AleatorioMultiplicativo.GenerarAleatorio(ListaAleatoriosMultiplicativos.Count);

            ListaAleatoriosMultiplicativos.Add(new Generado()
            {
                NumAleatorio = TruncateFunction(aleatorio.NumAleatorio, 4),
                Iteracion= aleatorio.Iteracion
            });
            
            grilla_multiplicativo.DataSource = null;
            grilla_multiplicativo.DataSource = ListaAleatoriosMultiplicativos;
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
               var lista = ListaAleatoriosMixtos;

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
                var lista = ListaAleatoriosMultiplicativos;

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
            InicializarGrilla();

            try
            {
               //Pregunto si el textbox de cantidad de aleatorios multiplicativos tiene una cantidad, si es asi establesco la cantidad
                //sino por defecto establezco que es 20
                var contador = int.Parse(txt_cantidad_aleatorios_lenguaje.Text);

                for (int i = 0; i < contador; i++)
                {

                    AleatorioLenguaje.GenerarAleatorio(i + 1);

                    ListaAleatoriosLenguaje.Add(new Generado()
                    {
                        NumAleatorio = TruncateFunction(AleatorioLenguaje.Generado.NumAleatorio, 4),
                        Iteracion = AleatorioLenguaje.Generado.Iteracion
                    });
                }

                grilla_aleatorios_lenguaje.DataSource = ListaAleatoriosLenguaje;
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
                var lista = ListaAleatoriosLenguaje;

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

            InicializarGrilla();
        }
    }
}
