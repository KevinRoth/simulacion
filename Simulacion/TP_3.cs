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
using Simulacion.Modelos.Distribuciones;

namespace Simulacion
{
    public partial class TP_3 : Form
    {
        private List<Generado> ListaUniforme;
        private List<Generado> ListaExponencial;
        private List<Generado> ListaNormal;
        private List<Generado> ListaPoisson;

        public TP_3()
        {
            InitializeComponent();
            InicializarUniforme();
            InicializarExponencial();
            InicializarNormal();
            InicializarPoisson();
        }

        public void InicializarUniforme()
        {
            ListaUniforme = new List<Generado>();
            grilla_uniforme.DataSource = null;
        }

        public void InicializarExponencial()
        {
            ListaExponencial = new List<Generado>();
            grilla_exponencial.DataSource = null;
        }

        public void InicializarNormal()
        {
            ListaNormal = new List<Generado>();
            grilla_normal.DataSource = null;
        }

        public void InicializarPoisson()
        {
            ListaPoisson = new List<Generado>();
            grilla_poisson.DataSource = null;
        }

        /// <summary>
        /// Retorna el numero con la cantidad de digitos despues de la coma indicados por parametro
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public double TruncateFunction(double number, int digits)
        {
            double stepper = (double) (Math.Pow(10.0, (double) digits));
            int temp = (int) (stepper * number);
            return (double) temp / stepper;
        }

        private void btn_uniforme_generar_Click(object sender, EventArgs e)
        {
            try
            {
                var a = Convert.ToDouble(txt_uniforme_a.Text);
                var b = Convert.ToDouble(txt_uniforme_b.Text);
                var cantidad = Convert.ToDouble(txt_uniforme_cantidad_variables.Text);

                var uniforme = new Uniforme();

                uniforme.A = a;
                uniforme.B = b;

                if (!uniforme.CompararAB())
                {
                    MessageBox.Show("A no puede ser mayor a B");
                    return;
                }

                for (int i = 0; i < cantidad; i++)
                {
                    var aleatorio = uniforme.GenerarVariableAleatoria(i + 1);
                    ListaUniforme.Add(new Generado()
                    {
                        NumAleatorio = TruncateFunction(aleatorio.NumAleatorio, 4),
                        Iteracion = aleatorio.Iteracion
                    });
                }

                grilla_uniforme.DataSource = ListaUniforme;
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese los valores obligatorios!!");
            }
        }

        private void btn_exponencial_generar_aleatorio_Click(object sender, EventArgs e)
        {
            try
            {
                var lambda = Convert.ToDouble(txt_exponencial_lambda.Text);
                var cantidad = Convert.ToDouble(txt_exponencial_cantidad_variables.Text);

                var exponencial = new Exponencial();

                exponencial.Lambda = lambda;

                if (!exponencial.VerificarLambda())
                {
                    MessageBox.Show("Lambda no puede ser menor a 0!!");
                    return;
                }

                for (int i = 0; i < cantidad; i++)
                {
                    var aleatorio = exponencial.GenerarVariableAleatoria(i + 1);
                    ListaExponencial.Add(new Generado()
                    {
                        NumAleatorio = TruncateFunction(aleatorio.NumAleatorio, 4),
                        Iteracion = aleatorio.Iteracion
                    });
                }

                grilla_exponencial.DataSource = ListaExponencial;
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese los valores obligatorios!!");
            }
        }

        private void btn_exponencial_generar_variables_Click(object sender, EventArgs e)
        {
            try
            {
                var media = Convert.ToDouble(txt_normal_media.Text);
                var desviacion = Convert.ToDouble(txt_normal_desviacion.Text);
                var cantidad = Convert.ToInt16(txt_normal_cantidad_variables.Text);

                var normal = new Normal();

                normal.Media = media;
                normal.DesviacionEstandar = desviacion;

                if (!normal.VerificarDesviacion())
                {
                    MessageBox.Show("La desviacion estandar tiene que ser mayor a 0!!!");
                    return;
                }

                if (!normal.VerificarMedia())
                {
                    MessageBox.Show("La media debe ser mayor a 0!!");
                    return;
                }

                for (int i = 0; i < cantidad; i++)
                {
                    var aleatorio = normal.GenerarVariableAleatoria(i + 1);
                    ListaNormal.Add(new Generado()
                    {
                        NumAleatorio = TruncateFunction(aleatorio.NumAleatorio, 4),
                        Iteracion = aleatorio.Iteracion
                    });
                }

                grilla_normal.DataSource = ListaNormal;
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese los valores obligatorios!!");
            }
        }

        private void btn_poisson_generar_aleatorios_Click(object sender, EventArgs e)
        {
            try
            {
                var lambda = Convert.ToDouble(txt_poisson_lambda.Text);
                var cantidad = Convert.ToInt16(txt_poisson_cantidad_variables.Text);

                var poisson = new Poisson();

                poisson.Lambda = lambda;

                if (!poisson.VerificarLambda())
                {
                    MessageBox.Show("Lambda tiene que ser mayor a 0!!!");
                    return;
                }

                var cantidadGenerados = 0;

                do
                {
                    var aleatorio = poisson.GenerarVariableAleatoria(cantidadGenerados + 1);

                    cantidadGenerados++;

                    ListaPoisson.Add(new Generado()
                    {
                        NumAleatorio = aleatorio.NumAleatorio,
                        Iteracion = cantidadGenerados
                    });
                } while (cantidadGenerados != cantidad);


                grilla_poisson.DataSource = ListaPoisson;
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese los valores obligatorios!!");
            }
        }

        private void btn_uniforme_grafica_Click(object sender, EventArgs e)
        {
            try
            {
                var lista = ListaUniforme;

                Grafica1 ventana = new Grafica1(lista, int.Parse(txt_uniforme_cantidad_intervalos.Text));
                ventana.Show();
            }
            catch (Exception exception)
            {
                Console.Write(exception);
                MessageBox.Show(
                    "Ingrese la cantidad de intervalos ó genere la lista de aleatorios a mandar previamente!");
            }
        }

        private void btn_exponencial_generar_grafico_Click(object sender, EventArgs e)
        {
            try
            {
                var lista = ListaExponencial;

                Grafica1 ventana = new Grafica1(lista, int.Parse(txt_exponencial_cantidad_intervalos.Text));
                ventana.Show();
            }
            catch (Exception exception)
            {
                Console.Write(exception);
                MessageBox.Show(
                    "Ingrese la cantidad de intervalos ó genere la lista de aleatorios a mandar previamente!");
            }
        }


        private void btn_poisson_generar_grafica_Click(object sender, EventArgs e)
        {
            try
            {
                var lista = ListaPoisson;

                Grafica1 ventana = new Grafica1(lista, int.Parse(txt_poisson_cantidad_intervalos.Text));
                ventana.Show();
            }
            catch (Exception exception)
            {
                Console.Write(exception);
                MessageBox.Show(
                    "Ingrese la cantidad de intervalos ó genere la lista de aleatorios a mandar previamente!");
            }
        }

        private void btn_normal_generar_grafica_Click(object sender, EventArgs e)
        {
            try
            {
                var lista = ListaNormal;

                Grafica1 ventana = new Grafica1(lista, int.Parse(txt_normal_cantidad_intervalos.Text));
                ventana.Show();
            }
            catch (Exception exception)
            {
                Console.Write(exception);
                MessageBox.Show(
                    "Ingrese la cantidad de intervalos ó genere la lista de aleatorios a mandar previamente!");
            }
        }

        private void btn_uniforme_reestablecer_Click(object sender, EventArgs e)
        {
            txt_uniforme_cantidad_intervalos.Text = "";
            txt_uniforme_a.Text = "";
            txt_uniforme_b.Text = "";
            txt_uniforme_cantidad_variables.Text = "";

            InicializarUniforme();
        }

        private void btn_exponencial_reestablecer_Click(object sender, EventArgs e)
        {
            txt_exponencial_cantidad_intervalos.Text = "";
            txt_exponencial_cantidad_variables.Text = "";
            txt_exponencial_lambda.Text = "";

            InicializarExponencial();
        }

        private void btn_normal_reestablecer_Click(object sender, EventArgs e)
        {
            txt_normal_cantidad_intervalos.Text = "";
            txt_normal_cantidad_variables.Text = "";
            txt_normal_desviacion.Text = "";
            txt_normal_media.Text = "";

            InicializarNormal();
        }

        private void btn_poisson_reestablecer_Click(object sender, EventArgs e)
        {
            txt_poisson_cantidad_intervalos.Text = "";
            txt_poisson_cantidad_variables.Text = "";
            txt_poisson_lambda.Text = "";

            InicializarPoisson();
        }
    }
}