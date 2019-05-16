using DataEntityFrameWork.Controllers.Helps;
using DataEntityFrameWork.Controllers.Interfaces;
using DataEntityFrameWork.Models;
using DataEntityFrameWork.Models.Helps;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataEntityFrameWork.Controllers
{
    public class DisciplinaControllers: IDisciplina
    {
        #region Forma Singliton
        private static DisciplinaControllers Instacia;
        public static DisciplinaControllers GetInstacia()
        {
            if (Instacia == null)
                return new DisciplinaControllers();
            else
                return Instacia;
        }
        #endregion

        #region Metodos
        public async Task<Response> Delete(Disciplina models)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoDelete(models).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = models,
                        Messgems = result.Exception,
                    };
                }
            }
        }
        public async Task<Response> Delete(int models)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoDelete<Disciplina>(models).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = models,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<int> GetCount()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Disciplina.CountAsync();
            }
        }
        public async Task<int> GetCount(object value)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Disciplina.Where(x => x.Designacao == value.ToString())
                    .CountAsync();
            }
        }
        public async Task<List<Disciplina>> GetList()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Disciplina
                                .OrderBy(x => x.Designacao)
                                .ToListAsync();
            }
        }

        public async Task<List<Disciplina>> GetList(string param)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Disciplina.Where(x => x.Designacao.ToLower().Contains(param.ToLower()))
                                .ToListAsync();
            }
        }

        public async Task<Response> Insert(Disciplina models)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoInsert<Disciplina>(models).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = models,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<Response> Update(Disciplina models)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoUpdate<Disciplina>(models).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = models,
                        Messgems = result.Exception,
                    };
                }
            }
        }
        #endregion
    }
}
