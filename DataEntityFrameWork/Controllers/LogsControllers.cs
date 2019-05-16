namespace DataEntityFrameWork.Controllers
{
    using DataEntityFrameWork.Controllers.Helps;
    using DataEntityFrameWork.Controllers.Interfaces;
    using DataEntityFrameWork.Models;
    using DataEntityFrameWork.Models.Helps;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class LogsControllers : ILogs
    {
        #region Forma Singliton
        private static LogsControllers Instacia;
        public static LogsControllers GetInstacia()
        {
            if (Instacia == null)
                return new LogsControllers();
            else
                return Instacia;
        }
        #endregion

        #region Metodos
        public async Task<Response> Delete(Logs usuarios)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoDelete(usuarios).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = usuarios,
                        Messgems = result.Exception,
                    };
                }
            }      
        }

        public async Task<int> GetCount()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Logs.CountAsync();
            }
        }

        public async Task<List<Logs>> GetList()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Logs.ToListAsync();
            }
        }
        public async Task<List<Logs>> GetList(int UserID)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Logs.Include(x => x.Usuarios).Where(x => x.UsuariosId == UserID).ToListAsync();
            }
        }

        public async Task<List<Logs>> GetList(string param)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Logs.Where(x => x.Operacao.ToLower().Contains(param.ToLower()))
                                    .ToListAsync();
            }
        }

        public async Task<Response> Insert(Logs usuarios)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoInsert(usuarios).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = usuarios,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<Response> Update(Logs usuarios)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoUpdate(usuarios).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = usuarios,
                        Messgems = result.Exception,
                    };
                }
            }
        }
        #endregion
    }
}
