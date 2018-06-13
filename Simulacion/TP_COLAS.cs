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
        private Uniforme distribucionCruceAgua = new Uniforme(55, 65);

        Uniforme distribucionCargaAuto = new Uniforme(1, 3);
        Uniforme distribucionCargaCamion = new Uniforme(3, 5);

        DateTime horaInicio = DateTime.Today.AddHours(7);
        DateTime horaFin = DateTime.Today.AddHours(20);

        private Llegada llegadas;

        Transbordador transbordador1;
        Transbordador transbordador2;

        private DateTime proximaSalidaTransbordador1;
        private DateTime proximaSalidaTransbordador2;

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

        private int maximaColaContinente = 0;
        private int maximaColaIsla = 0;


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

            var inicioAtencionTransbordadores = DateTime.Today.AddHours(8);

            var sumatoriaAutosTrasladadosDelContinentePorDia = 0;
            var sumatoriaCamionesTrasladadosDelContinentePorDia = 0;
            var sumatoriaAutosTrasladadosDeIslaPorDia = 0;
            var sumatoriaCamionesTrasladadosDeIslaPorDia = 0;

            var sumatoriaVehiculosNoAtendidosContinentePorDia = 0;
            var sumatoriaVehiculosNoAtendidosIslaPorDia = 0;

            llegadaAutoC = new Llegada(distribucionLlegadaAutosContinenteAIslaDe730A12, "Auto", "Continente");
            llegadaCamionC = new Llegada(distribucionLlegadaCamionesContinenteAIslaDe7A11, "Camion", "Continente");
            llegadaCamionI = new Llegada(distribucionLlegadaCamionesIslaAContinenteDe10A18, "Camion", "Isla");
            llegadaAutoI = new Llegada(distribucionLlegadaAutosIslaAContinenteDe10A18, "Auto", "Isla");
            Transbordador transbordador1 = new Transbordador("Continente", distribucionCargaAuto,
                distribucionCargaCamion, 10,
                "Transbordador 1", distribucionCruceAgua, 5);
            Transbordador transbordador2 = new Transbordador("Continente", distribucionCargaAuto,
                distribucionCargaCamion, 20,
                "Transbordador 2", distribucionCruceAgua, 10);

            proximaSalidaTransbordador1 = DateTime.Today.AddHours(9);
            proximaSalidaTransbordador2 = DateTime.Today.AddHours(10);

            //  for (int dia = 1; dia <= dias; dia++)
            //{
            reloj = horaInicio;

            ObtenerLlegadas(horaInicio, horaFin, reloj, llegadas, llegadaAutoC, llegadaCamionC, llegadaAutoI,
                llegadaCamionI, colaVehiculosContinente, colaVehiculosIsla);

            GuardarEnGrilla(1, reloj, llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI, transbordador1,
                transbordador2, colaVehiculosContinente, colaVehiculosIsla, "Llegada", maximaColaContinente,
                maximaColaIsla,
                sumatoriaAutosTrasladadosDelContinentePorDia, sumatoriaCamionesTrasladadosDelContinentePorDia,
                sumatoriaAutosTrasladadosDeIslaPorDia, sumatoriaCamionesTrasladadosDeIslaPorDia,
                sumatoriaVehiculosNoAtendidosContinentePorDia, sumatoriaVehiculosNoAtendidosIslaPorDia);

            reloj = reloj.AddMinutes(30);

            var terminarDia = false;


            do
            {
                //Mantenimiento de transbordadores
                transbordador1.Mantenimiento = transbordador1.Mantenimiento--;
                transbordador2.Mantenimiento = transbordador2.Mantenimiento--;


                if (transbordador1.EstaParaMantenimiento())
                {
                    transbordador1.Estado = "En mantenimiento";
                    transbordador1.ProximoFinMantenimiento = inicioAtencionTransbordadores.AddHours(5);
                }

                if (transbordador2.EstaParaMantenimiento())
                {
                    transbordador2.Estado = "En mantenimiento";
                    transbordador2.ProximoFinMantenimiento = inicioAtencionTransbordadores.AddHours(5);
                }

                if (reloj >= horaFin)
                {
                    break;
                }

                //Llegada de vehiculos
                if (llegadaAutoC.DistribucionLlegadasAutosContinente.HoraFin < reloj)
                {
                    llegadaAutoC.SetDistribucionLlegadaAutosContinente(
                        distribucionLlegadaAutosContinenteAIslaDe12A19);
                }

                if (llegadaCamionC.DistribucionLlegadasCamionesContinente.HoraFin < reloj)
                {
                    llegadaCamionC.SetDistribucionLlegadaCamionesContinente(
                        distribucionLlegadaCamionesContinenteAIslaDe11A1930);
                }

                ObtenerLlegadas(horaInicio, horaFin, reloj, llegadas, llegadaAutoC, llegadaCamionC, llegadaAutoI,
                    llegadaCamionI, colaVehiculosContinente, colaVehiculosIsla);


                //Carga de vehiculos y cruce de agua T1
                if (transbordador1.Ubicacion == "Continente")
                {
                    if (transbordador1.EstaLibre() && colaVehiculosContinente.Any() &&
                        inicioAtencionTransbordadores <= reloj &&
                        transbordador1.Vehiculos.Count + colaVehiculosContinente.First().Tamanio <= 10)
                    {
                        colaVehiculosContinente = transbordador1.CargarVehiculo(colaVehiculosContinente, reloj);
                    }

                    if (proximaSalidaTransbordador1 <= reloj && (transbordador1.Capacidad == 0 ||
                                                                 !colaVehiculosContinente.Any())
                                                             && transbordador1.EstaLibre())
                    {
                        transbordador1.ObtenerCruceAgua(reloj);

                        if (transbordador1.Ubicacion == "Isla")
                        {
                            sumatoriaAutosTrasladadosDeIslaPorDia += transbordador1.Vehiculos
                                .Where(vehiculo => vehiculo.TipoVehiculo == "Auto").ToList().Count;

                            sumatoriaCamionesTrasladadosDeIslaPorDia += transbordador1.Vehiculos
                                .Where(vehiculo => vehiculo.TipoVehiculo == "Camion").ToList().Count;
                        }
                        else
                        {
                            sumatoriaAutosTrasladadosDelContinentePorDia += transbordador1.Vehiculos
                                .Where(vehiculo => vehiculo.TipoVehiculo == "Auto").ToList().Count;

                            sumatoriaCamionesTrasladadosDelContinentePorDia += transbordador1.Vehiculos
                                .Where(vehiculo => vehiculo.TipoVehiculo == "Camion").ToList().Count;
                        }
                    }
                    else if (proximaSalidaTransbordador1 < reloj && colaVehiculosContinente.Any()
                                                                 && !transbordador1.EstaCruzandoAgua()
                                                                 && !transbordador1.EstaDescargando()
                                                                 && !transbordador1.EstaOcupado()
                                                                 && !transbordador1.EstaParaMantenimiento())
                    {
                        proximaSalidaTransbordador1 = reloj;
                    }
                }
                else
                {
                    if (transbordador1.EstaLibre() && colaVehiculosIsla.Any() &&
                        transbordador1.Vehiculos.Count + colaVehiculosIsla.First().Tamanio <= 10)
                    {
                        colaVehiculosIsla = transbordador1.CargarVehiculo(colaVehiculosIsla, reloj);
                    }

                    if (proximaSalidaTransbordador1 <= reloj && (transbordador1.Capacidad == 0 ||
                                                                 !colaVehiculosIsla.Any())
                                                             && transbordador1.EstaLibre())
                    {
                        transbordador1.ObtenerCruceAgua(reloj);
                    }
                    else if (proximaSalidaTransbordador1 < reloj && colaVehiculosIsla.Any()
                                                                 && !transbordador1.EstaCruzandoAgua()
                                                                 && !transbordador1.EstaDescargando()
                                                                 && !transbordador1.EstaOcupado()
                                                                 && !transbordador1.EstaParaMantenimiento())
                    {
                        proximaSalidaTransbordador1 = reloj;
                    }
                }

                //Carga de vehiculos y cruce de agua T2
                if (transbordador2.Ubicacion == "Continente")
                {
                    if (transbordador2.EstaLibre() && colaVehiculosContinente.Any() &&
                        inicioAtencionTransbordadores <= reloj &&
                        transbordador2.Vehiculos.Count + colaVehiculosContinente.First().Tamanio <= 20)
                    {
                        colaVehiculosContinente = transbordador2.CargarVehiculo(colaVehiculosContinente, reloj);
                    }

                    if (proximaSalidaTransbordador2 <= reloj && (transbordador2.Capacidad == 0 ||
                                                                 !colaVehiculosContinente.Any())
                                                             && transbordador2.EstaLibre())
                    {
                        transbordador2.ObtenerCruceAgua(reloj);

                        if (transbordador2.Ubicacion == "Isla")
                        {
                            sumatoriaAutosTrasladadosDeIslaPorDia += transbordador2.Vehiculos
                                .Where(vehiculo => vehiculo.TipoVehiculo == "Auto").ToList().Count;

                            sumatoriaCamionesTrasladadosDeIslaPorDia += transbordador2.Vehiculos
                                .Where(vehiculo => vehiculo.TipoVehiculo == "Camion").ToList().Count;
                        }
                        else
                        {
                            sumatoriaAutosTrasladadosDelContinentePorDia += transbordador2.Vehiculos
                                .Where(vehiculo => vehiculo.TipoVehiculo == "Auto").ToList().Count;

                            sumatoriaCamionesTrasladadosDelContinentePorDia += transbordador2.Vehiculos
                                .Where(vehiculo => vehiculo.TipoVehiculo == "Camion").ToList().Count;
                        }
                    }
                    else if (proximaSalidaTransbordador2 < reloj && colaVehiculosContinente.Any()
                                                                 && !transbordador2.EstaCruzandoAgua()
                                                                 && !transbordador2.EstaDescargando()
                                                                 && !transbordador2.EstaOcupado()
                                                                 && !transbordador2.EstaParaMantenimiento())
                    {
                        proximaSalidaTransbordador2 = reloj;
                    }
                }
                else
                {
                    if (transbordador2.EstaLibre() && colaVehiculosIsla.Any() &&
                        transbordador2.Vehiculos.Count + colaVehiculosIsla.First().Tamanio <= 20)
                    {
                        colaVehiculosIsla = transbordador2.CargarVehiculo(colaVehiculosIsla, reloj);
                    }

                    if (proximaSalidaTransbordador2 <= reloj && (transbordador2.Capacidad == 0 ||
                                                                 !colaVehiculosIsla.Any())
                                                             && transbordador2.EstaLibre())
                    {
                        transbordador2.ObtenerCruceAgua(reloj);
                    }
                    else if (proximaSalidaTransbordador2 < reloj && colaVehiculosIsla.Any()
                                                                 && !transbordador2.EstaCruzandoAgua()
                                                                 && !transbordador2.EstaDescargando()
                                                                 && !transbordador2.EstaOcupado()
                                                                 && !transbordador2.EstaParaMantenimiento())
                    {
                        proximaSalidaTransbordador2 = reloj;
                    }
                }

                //Descarga de vehiculos
                if (transbordador1.EstaDescargando())
                {
                    transbordador1.DescargarVehiculo(reloj);
                }

                if (transbordador2.EstaDescargando())
                {
                    transbordador2.DescargarVehiculo(reloj);
                }

                maximaColaContinente = maximaColaContinente < colaVehiculosContinente.Count
                    ? maximaColaContinente = colaVehiculosContinente.Count
                    : maximaColaContinente;

                maximaColaIsla = maximaColaIsla < colaVehiculosIsla.Count
                    ? maximaColaIsla = colaVehiculosIsla.Count
                    : maximaColaIsla;


                var eventos = new List<Evento>
                {
                    new Evento("Llegada Auto Continente", llegadaAutoC.ProximaLlegada),
                    new Evento("Llegada Auto Isla", llegadaAutoI.ProximaLlegada),
                    new Evento("Llegada Camion Continente", llegadaCamionC.ProximaLlegada),
                    new Evento("Llegada Camion Isla", llegadaCamionI.ProximaLlegada),
                    new Evento("Cierre", horaFin),
                    new Evento("Fin Carga Vehiculo Transbordador 1", transbordador1.ProximaCarga),
                    new Evento("Fin Carga Vehiculo Transbordador 2", transbordador2.ProximaCarga),
                    new Evento("Fin Cruce Agua Transbordador 1", transbordador1.ProximaLlegadaTierra),
                    new Evento("Fin Cruce Agua Transbordador 2", transbordador2.ProximaLlegadaTierra),
                    new Evento("Fin Descarga Vehiculo Transbordador 1", transbordador1.ProximaDescarga),
                    new Evento("Fin Descarga Vehiculo Transbordador 2", transbordador2.ProximaDescarga),
                    new Evento("Fin Mantenimiento Transbordador 1", transbordador1.ProximoFinMantenimiento),
                    new Evento("Fin Mantenimiento Transbordador 2", transbordador2.ProximoFinMantenimiento)
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
                            colaVehiculosContinente, colaVehiculosIsla, eventoActual,
                            maximaColaContinente, maximaColaIsla, sumatoriaAutosTrasladadosDelContinentePorDia,
                            sumatoriaCamionesTrasladadosDelContinentePorDia,
                            sumatoriaAutosTrasladadosDeIslaPorDia, sumatoriaCamionesTrasladadosDeIslaPorDia,
                            sumatoriaVehiculosNoAtendidosContinentePorDia, sumatoriaVehiculosNoAtendidosIslaPorDia);

                        //Inicializo para que cumpla con la condicion de la clase: 
                        //no tiene que existir una proxima llegada para generar una nueva llegada
                        llegadaAutoC.ProximaLlegada = new DateTime();

                        break;

                    case "Llegada Auto Isla":


                        GuardarEnGrilla(dia, reloj,
                            llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI,
                            transbordador1, transbordador2,
                            colaVehiculosContinente, colaVehiculosIsla, eventoActual,
                            maximaColaContinente, maximaColaIsla, sumatoriaAutosTrasladadosDelContinentePorDia,
                            sumatoriaCamionesTrasladadosDelContinentePorDia,
                            sumatoriaAutosTrasladadosDeIslaPorDia, sumatoriaCamionesTrasladadosDeIslaPorDia,
                            sumatoriaVehiculosNoAtendidosContinentePorDia, sumatoriaVehiculosNoAtendidosIslaPorDia);

                        //Inicializo para que cumpla con la condicion de la clase: 
                        //no tiene que existir una proxima llegada para generar una nueva llegada
                        llegadaAutoI.ProximaLlegada = new DateTime();

                        break;

                    case "Llegada Camion Continente":


                        GuardarEnGrilla(dia, reloj,
                            llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI,
                            transbordador1, transbordador2,
                            colaVehiculosContinente, colaVehiculosIsla, eventoActual,
                            maximaColaContinente, maximaColaIsla, sumatoriaAutosTrasladadosDelContinentePorDia,
                            sumatoriaCamionesTrasladadosDelContinentePorDia,
                            sumatoriaAutosTrasladadosDeIslaPorDia, sumatoriaCamionesTrasladadosDeIslaPorDia,
                            sumatoriaVehiculosNoAtendidosContinentePorDia, sumatoriaVehiculosNoAtendidosIslaPorDia);

                        //Inicializo para que cumpla con la condicion de la clase: 
                        //no tiene que existir una proxima llegada para generar una nueva llegada
                        llegadaCamionC.ProximaLlegada = new DateTime();

                        break;

                    case "Llegada Camion Isla":


                        GuardarEnGrilla(dia, reloj,
                            llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI,
                            transbordador1, transbordador2,
                            colaVehiculosContinente, colaVehiculosIsla, eventoActual,
                            maximaColaContinente, maximaColaIsla, sumatoriaAutosTrasladadosDelContinentePorDia,
                            sumatoriaCamionesTrasladadosDelContinentePorDia,
                            sumatoriaAutosTrasladadosDeIslaPorDia, sumatoriaCamionesTrasladadosDeIslaPorDia,
                            sumatoriaVehiculosNoAtendidosContinentePorDia, sumatoriaVehiculosNoAtendidosIslaPorDia);

                        //Inicializo para que cumpla con la condicion de la clase: 
                        //no tiene que existir una proxima llegada para generar una nueva llegada
                        llegadaCamionI.ProximaLlegada = new DateTime();

                        break;

                    case "Fin Carga Vehiculo Transbordador 1":

                        GuardarEnGrilla(dia, reloj,
                            llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI,
                            transbordador1, transbordador2,
                            colaVehiculosContinente, colaVehiculosIsla, eventoActual,
                            maximaColaContinente, maximaColaIsla, sumatoriaAutosTrasladadosDelContinentePorDia,
                            sumatoriaCamionesTrasladadosDelContinentePorDia,
                            sumatoriaAutosTrasladadosDeIslaPorDia, sumatoriaCamionesTrasladadosDeIslaPorDia,
                            sumatoriaVehiculosNoAtendidosContinentePorDia, sumatoriaVehiculosNoAtendidosIslaPorDia);

                        //Inicializo para que cumpla con la condicion de la clase: 
                        //no tiene que existir una proxima carga para generar una nueva carga
                        transbordador1.Estado = "Libre";
                        transbordador1.ProximaCarga = new DateTime();

                        break;

                    case "Fin Carga Vehiculo Transbordador 2":


                        GuardarEnGrilla(dia, reloj,
                            llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI,
                            transbordador1, transbordador2,
                            colaVehiculosContinente, colaVehiculosIsla, eventoActual,
                            maximaColaContinente, maximaColaIsla, sumatoriaAutosTrasladadosDelContinentePorDia,
                            sumatoriaCamionesTrasladadosDelContinentePorDia,
                            sumatoriaAutosTrasladadosDeIslaPorDia, sumatoriaCamionesTrasladadosDeIslaPorDia,
                            sumatoriaVehiculosNoAtendidosContinentePorDia, sumatoriaVehiculosNoAtendidosIslaPorDia);

                        //Inicializo para que cumpla con la condicion de la clase: 
                        //no tiene que existir una proxima carga para generar una nueva carga
                        transbordador2.Estado = "Libre";
                        transbordador2.ProximaCarga = new DateTime();

                        break;

                    case "Fin Cruce Agua Transbordador 1":

                        GuardarEnGrilla(dia, reloj,
                            llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI,
                            transbordador1, transbordador2,
                            colaVehiculosContinente, colaVehiculosIsla, eventoActual,
                            maximaColaContinente, maximaColaIsla, sumatoriaAutosTrasladadosDelContinentePorDia,
                            sumatoriaCamionesTrasladadosDelContinentePorDia,
                            sumatoriaAutosTrasladadosDeIslaPorDia, sumatoriaCamionesTrasladadosDeIslaPorDia,
                            sumatoriaVehiculosNoAtendidosContinentePorDia, sumatoriaVehiculosNoAtendidosIslaPorDia);


                        //Inicializo para que cumpla con la condicion de la clase: 
                        //no tiene que existir una proxima llegada tierra para generar un nuevo cruce agua

                        transbordador1.Ubicacion = transbordador1.Ubicacion == "Continente" ? "Isla" : "Continente";

                        transbordador1.Estado = "Descargando";
                        transbordador1.ProximaLlegadaTierra = new DateTime();
                        break;

                    case "Fin Cruce Agua Transbordador 2":

                        GuardarEnGrilla(dia, reloj,
                            llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI,
                            transbordador1, transbordador2,
                            colaVehiculosContinente, colaVehiculosIsla, eventoActual,
                            maximaColaContinente, maximaColaIsla, sumatoriaAutosTrasladadosDelContinentePorDia,
                            sumatoriaCamionesTrasladadosDelContinentePorDia,
                            sumatoriaAutosTrasladadosDeIslaPorDia, sumatoriaCamionesTrasladadosDeIslaPorDia,
                            sumatoriaVehiculosNoAtendidosContinentePorDia, sumatoriaVehiculosNoAtendidosIslaPorDia);


                        //Inicializo para que cumpla con la condicion de la clase: 
                        //no tiene que existir una proxima llegada tierra para generar un nuevo cruce agua
                        transbordador2.Ubicacion = transbordador2.Ubicacion == "Continente" ? "Isla" : "Continente";

                        transbordador2.Estado = "Descargando";
                        transbordador2.ProximaLlegadaTierra = new DateTime();
                        break;

                    case "Fin Descarga Vehiculo Transbordador 1":

                        GuardarEnGrilla(dia, reloj,
                            llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI,
                            transbordador1, transbordador2,
                            colaVehiculosContinente, colaVehiculosIsla, eventoActual,
                            maximaColaContinente, maximaColaIsla, sumatoriaAutosTrasladadosDelContinentePorDia,
                            sumatoriaCamionesTrasladadosDelContinentePorDia,
                            sumatoriaAutosTrasladadosDeIslaPorDia, sumatoriaCamionesTrasladadosDeIslaPorDia,
                            sumatoriaVehiculosNoAtendidosContinentePorDia, sumatoriaVehiculosNoAtendidosIslaPorDia);

                        transbordador1.ProximaDescarga = new DateTime();
                        proximaSalidaTransbordador1 = proximaSalidaTransbordador1.AddHours(1);

                        break;

                    case "Fin Descarga Vehiculo Transbordador 2":

                        GuardarEnGrilla(dia, reloj,
                            llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI,
                            transbordador1, transbordador2,
                            colaVehiculosContinente, colaVehiculosIsla, eventoActual,
                            maximaColaContinente, maximaColaIsla, sumatoriaAutosTrasladadosDelContinentePorDia,
                            sumatoriaCamionesTrasladadosDelContinentePorDia,
                            sumatoriaAutosTrasladadosDeIslaPorDia, sumatoriaCamionesTrasladadosDeIslaPorDia,
                            sumatoriaVehiculosNoAtendidosContinentePorDia, sumatoriaVehiculosNoAtendidosIslaPorDia);

                        transbordador2.ProximaDescarga = new DateTime();
                        proximaSalidaTransbordador2 = proximaSalidaTransbordador2.AddHours(1);

                        break;

                    case "Fin Mantenimiento Transbordador 1":

                        GuardarEnGrilla(dia, reloj,
                            llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI,
                            transbordador1, transbordador2,
                            colaVehiculosContinente, colaVehiculosIsla, eventoActual,
                            maximaColaContinente, maximaColaIsla, sumatoriaAutosTrasladadosDelContinentePorDia,
                            sumatoriaCamionesTrasladadosDelContinentePorDia,
                            sumatoriaAutosTrasladadosDeIslaPorDia, sumatoriaCamionesTrasladadosDeIslaPorDia,
                            sumatoriaVehiculosNoAtendidosContinentePorDia, sumatoriaVehiculosNoAtendidosIslaPorDia);

                        transbordador1.Estado = "Libre";
                        transbordador1.Mantenimiento = 10;
                        transbordador1.ProximoFinMantenimiento = new DateTime();

                        break;

                    case "Fin Mantenimiento Transbordador 2":

                        GuardarEnGrilla(dia, reloj,
                            llegadaAutoC, llegadaCamionC, llegadaAutoI, llegadaCamionI,
                            transbordador1, transbordador2,
                            colaVehiculosContinente, colaVehiculosIsla, eventoActual,
                            maximaColaContinente, maximaColaIsla, sumatoriaAutosTrasladadosDelContinentePorDia,
                            sumatoriaCamionesTrasladadosDelContinentePorDia,
                            sumatoriaAutosTrasladadosDeIslaPorDia, sumatoriaCamionesTrasladadosDeIslaPorDia,
                            sumatoriaVehiculosNoAtendidosContinentePorDia, sumatoriaVehiculosNoAtendidosIslaPorDia);

                        transbordador2.Estado = "Libre";
                        transbordador2.Mantenimiento = 10;
                        transbordador2.ProximoFinMantenimiento = new DateTime();

                        break;

                    /*     case "Cierre":
 
 
                             if (reloj <= horaFin &&
                                 transbordador1.Ubicacion == "Continente" && transbordador2.Ubicacion == "Continente")
                             {
 
                             }
 
                             break;*/
                }
            } while (reloj <= horaFin);

            //}
        }

        private void GuardarEnGrilla(int dia, DateTime reloj, Llegada llegadaAutoC, Llegada llegadaCamionC,
            Llegada llegadaAutoI, Llegada llegadaCamionI, Transbordador transbordador1,
            Transbordador transbordador2,
            List<Vehiculo> colaContinente, List<Vehiculo> colaIsla, string eventoActual,
            int maximaColaContinente, int maximaColaIsla,
            int sumatoriaAutosTrasladadosDelContinentePorDia, int sumatoriaCamionesTrasladadosDelContinentePorDia,
            int sumatoriaAutosTrasladadosDeIslaPorDia, int sumatoriaCamionesTrasladadosDeIslaPorDia,
            int sumatoriaVehiculosNoAtendidosContinentePorDia, int sumatoriaVehiculosNoAtendidosIslaPorDia)
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
                maximaColaContinente,
                colaIsla.Count,
                maximaColaIsla,
                TruncateFunction(transbordador1.RandomCruceAgua, 3),
                transbordador1.TiempoCruce.ToString("HH:mm:ss"),
                transbordador1.ProximaLlegadaTierra.ToString("HH:mm:ss"),
                TruncateFunction(transbordador2.RandomCruceAgua, 3),
                transbordador2.TiempoCruce.ToString("HH:mm:ss"),
                transbordador2.ProximaLlegadaTierra.ToString("HH:mm:ss"),
                transbordador1.Descarga.ToString("HH:mm:ss"),
                transbordador1.ProximaDescarga.ToString("HH:mm:ss"),
                transbordador2.Descarga.ToString("HH:mm:ss"),
                transbordador2.ProximaDescarga.ToString("HH:mm:ss"),
                transbordador1.ProximoFinMantenimiento != new DateTime() ? "Si" : "No",
                transbordador1.ProximoFinMantenimiento.ToString("HH:mm:ss"),
                transbordador2.ProximoFinMantenimiento != new DateTime() ? "Si" : "No",
                transbordador2.ProximoFinMantenimiento.ToString("HH:mm:ss"),
                TruncateFunction(sumatoriaAutosTrasladadosDelContinentePorDia / dia, 3),
                TruncateFunction(sumatoriaCamionesTrasladadosDelContinentePorDia / dia, 3),
                TruncateFunction(sumatoriaAutosTrasladadosDeIslaPorDia / dia, 3),
                TruncateFunction(sumatoriaCamionesTrasladadosDeIslaPorDia / dia, 3),
                TruncateFunction(sumatoriaVehiculosNoAtendidosContinentePorDia / dia, 3),
                TruncateFunction(sumatoriaVehiculosNoAtendidosIslaPorDia / dia, 3)
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