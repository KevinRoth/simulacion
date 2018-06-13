using System;

namespace Colas
{
    public class DateTimeConverter
    {
        public static decimal EnSegundos(DateTime tiempo)
        {
            return tiempo.Hour * 3600 + tiempo.Minute * 60 + tiempo.Second;
        }
        public static decimal EnSegundos(string tiempo)
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

        public static decimal EnMinutos(DateTime tiempo)
        {
            return EnSegundos(tiempo) / 60;
        }

        public static decimal EnMinutos(string tiempo)
        {
            return EnSegundos(tiempo) / 60;
        }

        public static decimal EnHoras(DateTime tiempo)
        {
            return EnSegundos(tiempo) / 3600;
        }

        public static decimal EnHoras(string tiempo)
        {
            return EnSegundos(tiempo) / 3600;
        }

        public static string DesdeSegundos(decimal segundos)
        {
            return DesdeMinutos(segundos / 60);
        }

        public static string DesdeMinutos(decimal minutos)
        {
            var hh = (int) (minutos / 60);

            var mm = (int) (minutos % 60);

            var ss = (int) (minutos % 1 * 60);

            return $"{hh}:{mm.ToString().PadLeft(2,'0')}:{ss.ToString().PadLeft(2, '0')}";
        }

        public static string DesdeHoras(decimal horas)
        {
            return DesdeMinutos(horas * 60);
        }
    }
}
