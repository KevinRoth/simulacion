using Montecarlo.TablaDistribucion;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Simulacion
{
    public partial class TP_4 : Form
    {

        private readonly DistribucionAleatoria _cantidadAutosVendidos;
        private readonly DistribucionAleatoria _tipoAuto;
        private readonly DistribucionAleatoria _comisionCompacto;
        private readonly DistribucionAleatoria _comisionMediano;
        private readonly DistribucionAleatoria _comisionLujo;
        private double _comisionPromedioSemanal;



        public TP_4()
        {
            InitializeComponent();

            txt_promedio_semanal.Enabled = false;

            _comisionPromedioSemanal = 0;

            //Inicializo tabla de distribucion de autos vendidos
            _cantidadAutosVendidos = new DistribucionAleatoria(new List<Probabilidad>(){
                new Probabilidad(0, 0.20),
                new Probabilidad(1, 0.30),
                new Probabilidad(2, 0.30),
                new Probabilidad(3, 0.15),
                new Probabilidad(4, 0.05)
            });

            //Inicializo tabla de distribucion de tipo de autos
            _tipoAuto = new DistribucionAleatoria(new List<Probabilidad>()
            {
                new Probabilidad(1, 0.50), //compacto
                new Probabilidad(2, 0.35), //mediano
                new Probabilidad(3, 0.15) //lujo
            });

            //Inicializo tabla de distribucion de comision de autos compactos
            _comisionCompacto = new DistribucionAleatoria(new List<Probabilidad>()
            {
                new Probabilidad(250, 1)
            });

            //Inicializo tabla de distribucion de comision de autos medianos
            _comisionMediano = new DistribucionAleatoria(new List<Probabilidad>()
            {
                new Probabilidad(400, 0.40),
                new Probabilidad(500, 0.60)
            });

            //Inicializo tabla de distribucion de comision de autos de lujo
            _comisionLujo = new DistribucionAleatoria(new List<Probabilidad>()
            {
                new Probabilidad(2000, 0.25),
                new Probabilidad(1500, 0.40),
                new Probabilidad(1000, 0.35),
            });
        }

        private void btn_simular_Click(object sender, EventArgs e)
        {
            var cantidadSemanas = int.Parse(txt_cantidad_semanas.Text);
            var random = new Random();

            var mostrarDesde = int.Parse(txt_desde.Text);
            var mostrarHasta = int.Parse(txt_hasta.Text);

            var acumuladoPromedioPorSemana = 0.0;
            var reloj = 0;

            for (int i = 0; i < cantidadSemanas; i++)
            {

                reloj = i + 1;

                
                var randomCantidadVendida1 = random.NextDouble();
                var cantidadVendida1 = ObtenerCantidadVendidaPorSemana(randomCantidadVendida1);
                var randomTipoAuto1 = cantidadVendida1 != 0 ? random.NextDouble() : 0;
                var tipoAuto1 = cantidadVendida1 != 0 ? ObtenerTiposAutoVendido(randomTipoAuto1) : 0;
                var randomComision1 = cantidadVendida1 != 0 ? random.NextDouble() : 0;
                var comisionAuto1 = cantidadVendida1 != 0 ? ObtenerComisionDeAutos(randomComision1, tipoAuto1, cantidadVendida1) : 0;

                var randomCantidadVendida2 = random.NextDouble();
                var cantidadVendida2 = ObtenerCantidadVendidaPorSemana(randomCantidadVendida2);
                var randomTipoAuto2 = cantidadVendida2 != 0 ? random.NextDouble() : 0;
                var tipoAuto2 = cantidadVendida2 != 0 ? ObtenerTiposAutoVendido(randomTipoAuto2) : 0;
                var randomComision2 = cantidadVendida2 != 0 ? random.NextDouble() : 0;
                var comisionAuto2 = cantidadVendida2 != 0 ? ObtenerComisionDeAutos(randomComision2, tipoAuto2, cantidadVendida2) : 0;

                var randomCantidadVendida3 = random.NextDouble();
                var cantidadVendida3 = ObtenerCantidadVendidaPorSemana(randomCantidadVendida3);
                var randomTipoAuto3 = cantidadVendida3 != 0 ? random.NextDouble() : 0;
                var tipoAuto3 = cantidadVendida3 != 0 ? ObtenerTiposAutoVendido(randomTipoAuto3) : 0;
                var randomComision3 = cantidadVendida3 != 0 ? random.NextDouble() : 0;
                var comisionAuto3 = cantidadVendida3 != 0 ? ObtenerComisionDeAutos(randomComision3, tipoAuto3, cantidadVendida3) : 0;

                var randomCantidadVendida4 = random.NextDouble();
                var cantidadVendida4 = ObtenerCantidadVendidaPorSemana(randomCantidadVendida4);
                var randomTipoAuto4 = cantidadVendida4 != 0 ? random.NextDouble() : 0;
                var tipoAuto4 = cantidadVendida4 != 0 ? ObtenerTiposAutoVendido(randomTipoAuto4) : 0;
                var randomComision4 = cantidadVendida4 != 0 ? random.NextDouble() : 0;
                var comisionAuto4 = cantidadVendida4 != 0 ? ObtenerComisionDeAutos(randomComision4, tipoAuto4, cantidadVendida4) : 0;

                var randomCantidadVendida5 = random.NextDouble();
                var cantidadVendida5 = ObtenerCantidadVendidaPorSemana(randomCantidadVendida5);
                var randomTipoAuto5 = cantidadVendida5 != 0 ? random.NextDouble() : 0;
                var tipoAuto5 = cantidadVendida5 != 0 ? ObtenerTiposAutoVendido(randomTipoAuto5) : 0;
                var randomComision5 = cantidadVendida5 != 0 ? random.NextDouble() : 0;
                var comisionAuto5 = cantidadVendida5 != 0 ? ObtenerComisionDeAutos(randomComision5, tipoAuto5, cantidadVendida5) : 0;

                var promedioComisionPorSemana = (comisionAuto1 + comisionAuto2 + comisionAuto3 + comisionAuto4 + comisionAuto5) / 5;
                
                acumuladoPromedioPorSemana += promedioComisionPorSemana;

                _comisionPromedioSemanal = acumuladoPromedioPorSemana / reloj;

                //Tabla
                if (reloj >= mostrarDesde && reloj <= mostrarHasta)
                {
                    dgv_simulaciones.Rows.Add(reloj,
                        TruncateFunction(randomCantidadVendida1, 2),
                        cantidadVendida1,
                        TruncateFunction(randomTipoAuto1, 2),
                        ObtenerTipoAuto(tipoAuto1),
                        TruncateFunction(randomComision1, 2),
                        comisionAuto1,
                        TruncateFunction(randomCantidadVendida2, 2),
                        cantidadVendida2,
                        TruncateFunction(randomTipoAuto2, 2),
                        ObtenerTipoAuto(tipoAuto2),
                        TruncateFunction(randomComision2, 2),
                        comisionAuto2,
                        TruncateFunction(randomCantidadVendida3, 2),
                        cantidadVendida3,
                        TruncateFunction(randomTipoAuto3, 2),
                        ObtenerTipoAuto(tipoAuto3),
                        TruncateFunction(randomComision3, 2),
                        comisionAuto3,
                        TruncateFunction(randomCantidadVendida4, 2),
                        cantidadVendida4,
                        TruncateFunction(randomTipoAuto4, 2),
                        ObtenerTipoAuto(tipoAuto4),
                        TruncateFunction(randomComision4, 2),
                        comisionAuto4,
                        TruncateFunction(randomCantidadVendida5, 2),
                        cantidadVendida5,
                        TruncateFunction(randomTipoAuto5, 2),
                        ObtenerTipoAuto(tipoAuto5),
                        TruncateFunction(randomComision5, 2),
                        comisionAuto5,
                        TruncateFunction(promedioComisionPorSemana, 2),
                        TruncateFunction(_comisionPromedioSemanal, 2)
                        );

                    Application.DoEvents();
                }

               
   
            }

            txt_promedio_semanal.Text = TruncateFunction(_comisionPromedioSemanal, 2).ToString();

        }
        
        public double TruncateFunction(double number, int digits)
        {
            double stepper = (double)(Math.Pow(10.0, (double)digits));
            int temp = (int)(stepper * number);
            return (double)temp / stepper;
        }

        private double ObtenerCantidadVendidaPorSemana(double randomCantidadVendida)
        {
            return _cantidadAutosVendidos.ObtenerValor(randomCantidadVendida);
        }

        private double ObtenerTiposAutoVendido(double randomTipoAuto)
        {
            return _tipoAuto.ObtenerValor(randomTipoAuto);
        }

        private string ObtenerTipoAuto(double tipoAuto)
        {
            if (tipoAuto == 1) //compacto
            {
                return "C";
            }
            if (tipoAuto == 2)//mediano
            {
                return "M";
            }
            //lujo
            return "L";
        }

        private double ObtenerComisionDeAutos(double randomComision, double tipoAuto, double cantidadAutosVendidos)
        {
            if(tipoAuto == 1) //compacto
            {
                return _comisionCompacto.ObtenerValor(randomComision) * cantidadAutosVendidos;
            }
            if(tipoAuto == 2)//mediano
            {
                return _comisionMediano.ObtenerValor(randomComision) * cantidadAutosVendidos;
            }
            //lujo
            return _comisionLujo.ObtenerValor(randomComision) * cantidadAutosVendidos;

        }

        private void btn_reestablecer_Click(object sender, EventArgs e)
        {
            dgv_simulaciones.Rows.Clear();
            txt_promedio_semanal.Text = "0";
            _comisionPromedioSemanal = 0;

            txt_cantidad_semanas.Text = "20";
            txt_desde.Text = "0";
            txt_hasta.Text = "20";
        }
    }
}
