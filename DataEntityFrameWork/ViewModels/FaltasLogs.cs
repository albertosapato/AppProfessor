namespace DataEntityFrameWork.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FaltasLogsViewModels
    {
        public int FaltasLogsID { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
    }
}
