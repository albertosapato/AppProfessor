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

    public class FaltasLogsControllers : IFaltasLogs
    {
        #region Forma Singliton
        private static FaltasLogsControllers Instacia;
        public static FaltasLogsControllers GetInstacia()
        {
            if (Instacia == null)
                return new FaltasLogsControllers();
            else
                return Instacia;
        }
        #endregion

        #region Metodos
        public async Task<Response> Delete(FaltasLogs 
             faltasLogs)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoDelete<FaltasLogs>(faltasLogs).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = faltasLogs,
                        Messgems = result.Exception,
                    };
                }
            }      
        }

        public async Task<int> GetCount()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.FaltasLogs.CountAsync();
            }
        }

        public async Task<List<FaltasLogs>> GetList()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.FaltasLogs.ToListAsync();
            }
        }

        public async Task<List<FaltasLogs>> GetList(string param)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.FaltasLogs.Where(x => x.Descricao.ToLower().Contains(param.ToLower()))
                                .ToListAsync();
            }
        }

        public async Task<Response> Insert(FaltasLogs faltasLogs)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoInsert<FaltasLogs>(faltasLogs).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = faltasLogs,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<Response> Update(FaltasLogs faltasLogs)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoUpdate<FaltasLogs>(faltasLogs).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = faltasLogs,
                        Messgems = result.Exception,
                    };
                }
            }
        }
        #endregion
    }
}
