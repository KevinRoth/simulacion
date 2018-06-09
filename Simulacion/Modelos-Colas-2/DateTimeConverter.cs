using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Modelos_Colas_2
{
    public class DateTimeConverter
    {
        public static double EnSegundos(DateTime tiempo)
        {
            return tiempo.Hour * 3600 + tiempo.Minute * 60 + tiempo.Second;
        }
        public static double EnSegundos(string tiempo)
        {
            var valores = tiempo.Split(':');

            int horas;
            int minutos;
            int segundos;

            if (!int.TryParse(valores[0], out horas)
                || !int.TryParse(valores[1], out minutos)
                || !int.TryParse(valores[2], out segundos))
                throw new NotSupportedException("El formato requerido es HH:mm:ss");

            return horas * 3600 + minutos * 60 + segundos;
        }

        public static double EnMinutos(DateTime tiempo)
        {
            return EnSegundos(tiempo) / 60;
        }

        public static double EnMinutos(string tiempo)
        {
            return EnSegundos(tiempo) / 60;
        }

        public static double EnHoras(DateTime tiempo)
        {
            return EnSegundos(tiempo) / 3600;
        }

        public static double EnHoras(string tiempo)
        {
            return EnSegundos(tiempo) / 3600;
        }

        public static string DesdeSegundos(decimal segundos)
        {
            return DesdeMinutos(segundos / 60);
        }

        public static string DesdeMinutos(decimal minutos)
        {
            var hh = (int)(minutos / 60);

            var mm = (int)(minutos % 60);

            var ss = (int)(minutos % 1 * 60);

            return $"{hh}:{mm.ToString().PadLeft(2, '0')}:{ss.ToString().PadLeft(2, '0')}";
        }

        public static string DesdeHoras(decimal horas)
        {
            return DesdeMinutos(horas * 60);
        }
    }
}

