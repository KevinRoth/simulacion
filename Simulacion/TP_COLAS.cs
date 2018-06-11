using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simulacion.Modelos.Distribuciones;
using Simulacion.Modelos_Colas_2;

namespace Simulacion
{
    public partial class TP_COLAS : Form
    {
        Uniforme distribucionLlegadaAutosContinenteAIslaDe730A12 = new Uniforme(10, 20, 450, 720);
        Uniforme distribucionLlegadaAutosContinenteAIslaDe12A19 = new Uniforme(25, 35, 720, 1140);
        Uniforme distribucionLlegadaCamionesContinenteAIslaDe7A11 = new Uniforme(17, 23, 420, 660);
        Uniforme distribucionLlegadaCamionesContinenteAIslaDe11A1930 = new Uniforme(110, 130, 660, 1170);

        Uniforme distribucionLlegadaCamionesIslaAContinenteDe10A18 = new Uniforme(30, 90, 600, 1080);
        Uniforme distribucionLlegadaAutosIslaAContinenteDe10A18 = new Uniforme(7, 17, 600, 1080);

        Uniforme distribucionCargaAuto = new Uniforme(1, 3);
        Uniforme distribucionCargaCamion = new Uniforme(3, 5);

        DateTime horaInicio = DateTime.Today.AddHours(7);
        DateTime horaFin = DateTime.Today.AddHours(20);

        private Llegada llegadas;

        Transbordador transbordador1;
        Transbordador transbordador2;

        int dias;
        int desde;
        int hasta;

        List<Vehiculo> colaVehiculosContinente = new List<Vehiculo>();
        List<Vehiculo> colaVehiculosIsla = new List<Vehiculo>();


        Llegada llegadaAutoC;
        Llegada llegadaCamionC;
        Llegada llegadaCamionI;
        Llegada llegadaAutoI;


        int dia = 1;


        DateTime reloj;

        public TP_COLAS()
        {
            InitializeComponent();
        }

        private void btn_simular_Click(object sender, EventArgs e)
        {
            llegadas = new Llegada(distribucionLlegadaAutosContinenteAIslaDe730A12,
                distribucionLlegadaAutosIslaAContinenteDe10A18, distribucionLlegadaCamionesContinenteAIslaDe7A11,
                distribucionLlegadaCamionesIslaAContinenteDe10A18, horaInicio, horaFin);

            dias = int.Parse(txt_dias.Text);
            desde = int.Parse(txt_desde.Text);
            hasta = int.Parse(txt_hasta.Text);

            llegadaAutoC = new Llegada(distribucionLlegadaAutosContinenteAIslaDe730A12, "Auto", "Continente");
            llegadaCamionC = new Llegada(distribucionLlegadaCamionesContinenteAIslaDe7A11, "Camion", "Continente");
            llegadaCamionI = new Llegada(distribucionLlegadaCamionesIslaAContinenteDe10A18, "Camion", "Isla");
            llegadaAutoI = new Llegada(distribucionLlegadaAutosIslaAContinenteDe10A18, "Auto", "Isla");
            Transbordador transbordador1 = new Transbordador("Continente", distribucionCargaAuto,
                distribucionCargaCamion, 10,
                "Transbordador 1");
            Transbordador transbordador2 = new Transbordador("Continente", distribucionCargaAuto,
                distribucionCargaCamion, 20,
                "Transbordador 2");

            reloj = horaInicio;

            ObtenerLlegadas(horaInicio, horaFin, reloj, llegadas, llegadaAutoC, llegadaCamionC, llegadaAutoI,
                llegadaCamionI, colaVehiculosContinente, colaVehiculosIsla);

            GuardarEnGrilla(1, reloj, llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI, transbordador1,
                transbordador2, colaVehiculosContinente,colaVehiculosIsla,"Llegada");

            reloj = reloj.AddMinutes(30);


            while (llegadas.EstaCerrado(reloj))
            {
                ObtenerLlegadas(horaInicio, horaFin, reloj, llegadas, llegadaAutoC, llegadaCamionC, llegadaAutoI,
                    llegadaCamionI, colaVehiculosContinente, colaVehiculosIsla);

                if (transbordador1.Ubicacion == "Continente")
                {
                    if (transbordador1.EstaLibre() && colaVehiculosContinente.Any() &&
                        transbordador1.Vehiculos.Count + colaVehiculosContinente.First().Tamanio <= 10)
                    {
                        colaVehiculosContinente = transbordador1.CargarVehiculo(colaVehiculosContinente, reloj);
                    }
                }
                else
                {
                    if (transbordador1.EstaLibre() && colaVehiculosContinente.Any() &&
                        transbordador1.Vehiculos.Count + colaVehiculosIsla.First().Tamanio <= 10)
                    {
                        colaVehiculosIsla = transbordador1.CargarVehiculo(colaVehiculosIsla, reloj);
                    }
                }

                if (transbordador2.Ubicacion == "Continente")
                {
                    if (transbordador2.EstaLibre() && colaVehiculosContinente.Any() &&
                        transbordador2.Vehiculos.Count + colaVehiculosContinente.First().Tamanio <= 10)
                    {
                        colaVehiculosContinente = transbordador2.CargarVehiculo(colaVehiculosContinente, reloj);
                    }
                    else
                    {
                        if (transbordador2.EstaLibre() && colaVehiculosContinente.Any() &&
                            transbordador2.Vehiculos.Count + colaVehiculosIsla.First().Tamanio <= 10)
                        {
                            colaVehiculosIsla = transbordador2.CargarVehiculo(colaVehiculosIsla, reloj);
                        }
                    }
                }

                var eventos = new List<Evento>
                {
                    new Evento("Llegada Auto Continente", llegadaAutoC.ProximaLlegada),
                    new Evento("Llegada Auto Isla", llegadaAutoI.ProximaLlegada),
                    new Evento("Llegada Camion Continente", llegadaCamionC.ProximaLlegada),
                    new Evento("Llegada Camion Isla", llegadaCamionI.ProximaLlegada),
                    new Evento("Cierre", horaFin),
                    new Evento("Carga Vehiculo Transbordador 1", transbordador1.ProximaCarga),
                    new Evento("Carga Vehiculo Transbordador 2", transbordador2.ProximaCarga),
                };

                // ReSharper disable once PossibleInvalidOperationException
                var relojActual = eventos.Where(ev => ev.Hora.HasValue && ev.Hora != new DateTime())
                    .Min(ev => ev.Hora)
                    .Value;
                var eventoActual = eventos.First(ev => ev.Hora.Equals(relojActual)).Nombre;

                reloj = relojActual;

                switch (eventoActual)
                {
                    case "Llegada Auto Continente":
                        GuardarEnGrilla(dia, reloj,
                            llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI,
                            transbordador1, transbordador2,
                            colaVehiculosContinente, colaVehiculosIsla, eventoActual);
                        //Inicializo para que cumpla con la condicion de la clase: 
                        //no tiene que existir una proxima llegada para generar una nueva llegada
                        llegadaAutoC.ProximaLlegada = new DateTime();
                        break;

                    case "Llegada Auto Isla":
                        GuardarEnGrilla(dia, reloj,
                            llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI,
                            transbordador1, transbordador2,
                            colaVehiculosContinente, colaVehiculosIsla, eventoActual);
                        //Inicializo para que cumpla con la condicion de la clase: 
                        //no tiene que existir una proxima llegada para generar una nueva llegada
                        llegadaAutoI.ProximaLlegada = new DateTime();
                        break;

                    case "Llegada Camion Continente":
                        GuardarEnGrilla(dia, reloj,
                            llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI,
                            transbordador1, transbordador2,
                            colaVehiculosContinente, colaVehiculosIsla, eventoActual);
                        //Inicializo para que cumpla con la condicion de la clase: 
                        //no tiene que existir una proxima llegada para generar una nueva llegada
                        llegadaCamionC.ProximaLlegada = new DateTime(); 
                        break;

                    case "Llegada Camion Isla":
                        GuardarEnGrilla(dia, reloj,
                            llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI,
                            transbordador1, transbordador2,
                            colaVehiculosContinente, colaVehiculosIsla, eventoActual);
                        //Inicializo para que cumpla con la condicion de la clase: 
                        //no tiene que existir una proxima llegada para generar una nueva llegada
                        llegadaCamionI.ProximaLlegada = new DateTime();
                        break;

                    case "Carga Vehiculo Transbordador 1":
                        GuardarEnGrilla(dia, reloj,
                            llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI,
                            transbordador1, transbordador2,
                            colaVehiculosContinente, colaVehiculosIsla, eventoActual);
                        //Inicializo para que cumpla con la condicion de la clase: 
                        //no tiene que existir una proxima carga para generar una nueva carga
                        transbordador1.ProximaCarga = new DateTime();
                        break;

                    case "Carga Vehiculo Transbordador 2":
                        GuardarEnGrilla(dia, reloj,
                            llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI,
                            transbordador1, transbordador2,
                            colaVehiculosContinente, colaVehiculosIsla, eventoActual);
                        //Inicializo para que cumpla con la condicion de la clase: 
                        //no tiene que existir una proxima carga para generar una nueva carga
                        transbordador2.ProximaCarga = new DateTime();
                        break;
                }

                //  GuardarEnGrilla(dia, reloj,
                //    llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI,
                //  transbordador1, transbordador2,
                // colaVehiculosContinente, colaVehiculosIsla);
                //  }
            }
        }

        private void GuardarEnGrilla(int dia, DateTime reloj, Llegada llegadaAutoC, Llegada llegadaCamionC,
            Llegada llegadaAutoI, Llegada llegadaCamionI, Transbordador transbordador1,
            Transbordador transbordador2,
            List<Vehiculo> colaContinente, List<Vehiculo> colaIsla, string eventoActual)
        {
            dgv_simulaciones.Rows.Add(
                dia,
                reloj.ToString("HH:mm:ss"),
                eventoActual,
                llegadaAutoC != null ? TruncateFunction(llegadaAutoC.RandomLlegada, 3) : 0,
                llegadaAutoC?.TiempoEntreLlegadas.ToString("HH:mm:ss"),
                llegadaAutoC?.ProximaLlegada.ToString("HH:mm:ss"),
                llegadaAutoC != null ? TruncateFunction(llegadaCamionC.RandomLlegada, 3) : 0,
                llegadaCamionC?.TiempoEntreLlegadas.ToString("HH:mm:ss"),
                llegadaCamionC?.ProximaLlegada.ToString("HH:mm:ss"),
                llegadaAutoI != null ? TruncateFunction(llegadaAutoI.RandomLlegada, 2) : 0,
                llegadaAutoI?.TiempoEntreLlegadas.ToString("HH:mm:ss"),
                llegadaAutoI?.ProximaLlegada.ToString("HH:mm:ss"),
                llegadaCamionI != null ? TruncateFunction(llegadaCamionI.RandomLlegada, 2) : 0,
                llegadaCamionI?.TiempoEntreLlegadas.ToString("HH:mm:ss"),
                llegadaCamionI?.ProximaLlegada.ToString("HH:mm:ss"),
                transbordador1.Ubicacion,
                transbordador1.Estado,
                TruncateFunction(transbordador1.RandomCargas, 3),
                transbordador1.TiempoEntreCargas.ToString("HH:mm:ss"),
                transbordador1.ProximaCarga.ToString("HH:mm:ss"),
                transbordador1.Capacidad,
                transbordador2.Ubicacion,
                transbordador2.Estado,
                TruncateFunction(transbordador2.RandomCargas, 3),
                transbordador2.TiempoEntreCargas.ToString("HH:mm:ss"),
                transbordador2.ProximaCarga.ToString("HH:mm:ss"),
                transbordador2.Capacidad,
                colaContinente.Count,
                "cola maxima cont",
                colaIsla.Count,
                "cola maxima isla"
            );

            Application.DoEvents();
        }

        public void ObtenerLlegadas(DateTime horaInicio, DateTime horaFin, DateTime reloj,
            Llegada llegadas, Llegada llegadaAutoC, Llegada llegadaCamionC, Llegada llegadaAutoI,
            Llegada llegadaCamionI,
            List<Vehiculo> colaVehiculosContinente, List<Vehiculo> colaVehiculosIsla
        )
        {
            Random random = new Random();

            if (llegadaAutoC.DistribucionLlegadasAutosContinente.HoraInicio <= reloj &&
                llegadaAutoC.DistribucionLlegadasAutosContinente.HoraFin > reloj)
            {
                colaVehiculosContinente = llegadaAutoC.ObtenerLlegadaVehiculo("Auto", "Continente", reloj,
                    random.NextDouble(), colaVehiculosContinente);
            }

            if (llegadaCamionC.DistribucionLlegadasCamionesContinente.HoraInicio <= reloj &&
                llegadaCamionC.DistribucionLlegadasCamionesContinente.HoraFin > reloj)
            {
                colaVehiculosContinente = llegadaCamionC.ObtenerLlegadaVehiculo("Camion", "Continente", reloj,
                    random.NextDouble(), colaVehiculosContinente);
            }

            if (llegadaAutoI.DistribucionLlegadasAutosIsla.HoraInicio <= reloj &&
                llegadaAutoI.DistribucionLlegadasAutosIsla.HoraFin > reloj)
            {
                colaVehiculosIsla =
                    llegadaAutoI.ObtenerLlegadaVehiculo("Auto", "Isla", reloj, random.NextDouble(), colaVehiculosIsla);
            }

            if (llegadaCamionI.DistribucionLlegadasCamionesIsla.HoraInicio <= reloj &&
                llegadaCamionI.DistribucionLlegadasCamionesIsla.HoraFin > reloj)
            {
                colaVehiculosIsla = llegadaCamionI.ObtenerLlegadaVehiculo("Camion", "Isla", reloj, random.NextDouble(),
                    colaVehiculosIsla);
            }
        }

        public double TruncateFunction(double number, int digits)
        {
            double stepper = (double) (Math.Pow(10.0, (double) digits));
            int temp = (int) (stepper * number);
            return (double) temp / stepper;
        }
    }
}