namespace DataEntityFrameWork.Controllers.Helps
{
    using System;
    public class FormatosTempos
    {
        public static string HorasMinutosSegundos
        {
            get
            {
                return string.Format("{0}:{1}:{2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            }
        }
        public static string HorasMinutos
        {
            get
            {
                return string.Format("{0}:{1}", DateTime.Now.Hour, DateTime.Now.Minute);
            }
        }
        public static object HorasMinuto
        {
            get
            {
                return string.Format("{0}:{1}", DateTime.Now.Hour, DateTime.Now.Minute);
            }
        }

        public static string DataHoras
        {
            get
            {
                return string.Format("{0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
            }
        }
    }
}
