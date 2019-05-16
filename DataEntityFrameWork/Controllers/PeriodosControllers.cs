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

    public class PeriodosControllers : IPeriodos
    {
        #region Forma Singliton
        private static PeriodosControllers Instacia;
        public static PeriodosControllers GetInstacia()
        {
            if (Instacia == null)
                return new PeriodosControllers();
            else
                return Instacia;
        }
        #endregion

        #region Metodos
        public async Task<Response> Delete(Periodo periodo)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoDelete<Periodo>(periodo).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = periodo,
                        Messgems = result.Exception,
                    };
                }
            }      
        }

        public async Task<Response> Delete(int periodo)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoDelete<Periodo>(periodo).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = periodo,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<int> GetCount()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Periodo.CountAsync();
            }
        }
        public async Task<int> GetCount(string id)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Periodo.Where(x => x.PeriodoNome.ToUpper() == id.ToUpper()).CountAsync();
            }
        }

        public async Task<List<Periodo>> GetList()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Periodo.ToListAsync();
            }
        }

        public async Task<List<Periodo>> GetList(string param)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Periodo.Where(x => x.PeriodoNome.ToLower().Contains(param.ToLower()))
                                .ToListAsync();
            }
        }

        public async Task<Response> Insert(Periodo periodo)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoInsert<Periodo>(periodo).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = periodo,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<Response> Update(Periodo periodo)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoUpdate<Periodo>(periodo).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = periodo,
                        Messgems = result.Exception,
                    };
                }
            }
        }
        #endregion
    }
}
