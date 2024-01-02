
namespace mipBackend.Services
{
    public static class FDate
    {


        private const string _CULTURE_INFO = "es-CL";

        private static DateTime _DATETIME;

        /// <summary>
        /// Start Chronometer
        /// </summary>
        public static void StartChronometer()
        {
            _DATETIME = DateTime.Now;
        }
        /// <summary>
        /// Get delta time of the Chronometer
        /// </summary>
        /// <returns></returns>
        public static string GetChronometer()
        {
            TimeSpan timeSpan = DateTime.Now - _DATETIME;
            return timeSpan.ToString();
        }

        /// <summary>
        /// Convierte de Tipo Date a string de la forma dd-mm-yyyy,
        /// La configuración regional del servidor no le afecta a la función.
        /// Autor: Ing. Eugenio Muñoz
        /// Fecha: 2006-06-16
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static string DateToString(DateTime ObjectDate)
        {
            string day = "00" + ObjectDate.Day.ToString();
            string month = "00" + ObjectDate.Month.ToString();
            string year = "00" + ObjectDate.Year.ToString();
            day = day.Substring(day.Length - 2, 2);
            month = month.Substring(month.Length - 2, 2);
            year = year.Substring(year.Length - 4, 4);
            return day + "-" + month + "-" + year;
        }

        public static String Date2String(DateTime ObjectDate)
        {
            String stx_Fecha;

            stx_Fecha = DateToString(ObjectDate);

            return stx_Fecha;
        }
        /// <summary>
        /// Convierte de fecha string a DataTime
        /// La configuración regional del servidor no le afecta a la función.
        /// Autor: Ing. Eugenio Muñoz
        /// Fecha: 2006-06-16
        /// </summary>
        /// <param name="sFecha"></param>
        /// <returns></returns>
        public static DateTime StringToDate(string StringDate)
        {
            DateTime objDate = new DateTime();
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(_CULTURE_INFO);
            objDate = Convert.ToDateTime(StringDate, culture);
            return objDate;
        }
        /// <summary>
        /// Obtiene la Fecha Actual
        /// Autor: Ing. Eugenio Muñoz
        /// Fecha: 2006-06-20
        /// </summary>
        /// <returns></returns>
        public static string DateNow()
        {
            return DateToString(DateTime.Now);
        }
        /// <summary>
        /// Get month description 
        /// </summary>
        /// <param name="iMonth"></param>
        /// <returns></returns>
        public static string MonthDescription(int iMonth)
        {
            string buffer = "";
            switch (iMonth)
            {
                case 1: buffer = "Enero"; break;
                case 2: buffer = "Febrero"; break;
                case 3: buffer = "Marzo"; break;
                case 4: buffer = "Abril"; break;
                case 5: buffer = "Mayo"; break;
                case 6: buffer = "Junio"; break;
                case 7: buffer = "Julio"; break;
                case 8: buffer = "Agosto"; break;
                case 9: buffer = "Septiembre"; break;
                case 10: buffer = "Octubre"; break;
                case 11: buffer = "Noviembre"; break;
                case 12: buffer = "Diciembre"; break;

            }
            return buffer;
        }
        /// <summary>
        /// Test, is Date?
        /// </summary>
        /// <param name="StringDate"></param>
        /// <returns></returns>
        public static bool IsDate(string StringDate)
        {
            DateTime objDate = new DateTime();
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("fr-FR");
            objDate = Convert.ToDateTime(StringDate, culture);
            return DateTime.TryParse(StringDate, out objDate);
        }

        public static String unformatDate(String fecha)
        {
            try
            {
                if (fecha == "")
                {
                    return "";
                }
                else
                {
                    String[] arrFecha;

                    arrFecha = fecha.Split('-', '/', ' ');

                    String dia, mes, anio, fecha2 = null;
                    dia = arrFecha[0];
                    mes = arrFecha[1];
                    anio = arrFecha[2];

                    if (dia.Length == 1)
                    {
                        dia = "0" + dia;
                    }
                    if (mes.Length == 1)
                    {
                        mes = "0" + mes;
                    }
                    fecha2 = anio + mes + dia;
                    return fecha2;

                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        public static String unformatDate(String fecha, Int16 tipoDevolver)
        {
            try
            {
                if (fecha == "")
                {
                    if (tipoDevolver == 2)
                    {
                        return "NULL";
                    }
                    else
                    {
                        return "";
                    }

                }
                else
                {
                    String[] arrFecha;

                    arrFecha = fecha.Split('-', '/', ' ');

                    String dia, mes, anio, fecha2 = null;
                    dia = arrFecha[0];
                    mes = arrFecha[1];
                    anio = arrFecha[2];

                    if (dia.Length == 1)
                    {
                        dia = "0" + dia;
                    }
                    if (mes.Length == 1)
                    {
                        mes = "0" + mes;
                    }

                    if (tipoDevolver == 2)
                    {
                        fecha2 = anio + mes + dia;
                    }
                    else
                    {
                        fecha2 = anio + mes + dia;
                    }


                    return fecha2;

                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
    }
}
