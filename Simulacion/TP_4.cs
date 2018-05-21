using Montecarlo.TablaDistribucion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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



        public TP_4()
        {
            InitializeComponent();

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
                new Probabilidad(1, 1)
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
    }
}
