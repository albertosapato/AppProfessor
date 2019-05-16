using System;

namespace DataEntityFrameWork.ViewModels
{
    public class LogsViewModels
    {
        public int LogsId { get; set; }
        public DateTime Data { get; set; }
        public string Operacao { get; set; }
        public TimeSpan Hora { get; set; }
        public int UsuariosId { get; set; }
        public virtual UsuariosViewModels Usuarios { get; set; }
    }
}
