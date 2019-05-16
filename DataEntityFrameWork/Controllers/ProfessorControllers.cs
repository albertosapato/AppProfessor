using DataEntityFrameWork.Controllers.Helps;
using DataEntityFrameWork.Controllers.Interfaces;
using DataEntityFrameWork.Models;
using DataEntityFrameWork.Models.Helps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityFrameWork.Controllers
{
    public class ProfessorControllers: IProfessor
    {
        #region Forma Singliton
        private static ProfessorControllers Instacia;
        public static ProfessorControllers GetInstacia()
        {
            if (Instacia == null)
                return new ProfessorControllers();
            else
                return Instacia;
        }
        #endregion

        #region Metodos
        public async Task<Response> Delete(Professor models)
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
                    var result = await db.DoDelete<Alunos>(models).EndTransaction();

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
                return await db.Professor.CountAsync();
            }
        }
        public async Task<int> GetCount(string value, string Bi)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Professor.Where(x => x.Nome == value.ToString() 
                                                  && x.Bi == Bi)
                    .CountAsync();
            }
        }
        public async Task<List<Professor>> GetList()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Professor
                                .OrderBy(x => x.Nome)
                                .ToListAsync();
            }
        }

        public async Task<List<Professor>> GetList(string param)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Professor.Where(x => x.Nome.ToLower().Contains(param.ToLower()))
                                .ToListAsync();
            }
        }

        public async Task<Response> Insert(Professor models)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoInsert<Professor>(models).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = models,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<Response> Update(Professor models)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoUpdate<Professor>(models).EndTransaction();

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
