using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityFrameWork.Models
{
    public class Logs
    {
        public int LogsId { get; set; }
        public DateTime Data { get; set; }
        public string Operacao { get; set; }
        public TimeSpan Hora { get; set; }
        public int UsuariosId { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
