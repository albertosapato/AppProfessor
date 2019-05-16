using DataEntityFrameWork.Controllers.Helps;
using DataEntityFrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataEntityFrameWork.Controllers
{
    public class LoginControllers
    {
        public int IDGrupos { get; set; }
        public static LoginControllers Instacia;
        public static LoginControllers GetInstancia()
        {
            if (Instacia == null)
                Instacia = new LoginControllers();
            return Instacia;
        }
        public async Task<List<Usuarios>> Testar()
        {
            return await UsuariosControllers.GetInstacia().GetList();
        }
        public async Task<int> GetLogin(string Usuer, string Senha)
        {
            var PinEncrip = Encriptar.GetMD5Hash(Senha);

            var cursoes = (await Testar()).Where(x => (x.Login.ToLower() == Usuer.ToLower() || x.Email == Usuer)
                                                   && (x.Senha == PinEncrip || x.Pin == PinEncrip))
                                                   .ToList();
            if (cursoes.Count > 0)
            {
                foreach (var item in cursoes)
                {
                    IDGrupos = item.GrupoId;
                    if (item.Estado == false)
                        return 2;
                    else
                    {
                        var logs = new Logs
                        {
                            Data = DateTime.Now,
                            Operacao = "Cabou de fazer login via ON-LINE!...",
                            Hora = TimeSpan.Parse(FormatosTempos.HorasMinutosSegundos),
                            UsuariosId = item.UsuariosId
                        };
                        await LogsControllers.GetInstacia().Insert(logs);
                        return 3;
                    }
                }
            }
            else
                return 1;
            return 4;
        }
    }
}
