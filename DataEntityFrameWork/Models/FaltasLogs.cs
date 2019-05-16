namespace DataEntityFrameWork.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FaltasLogs
    {
        [Key]
        public int FaltasLogsID { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
    }
}
