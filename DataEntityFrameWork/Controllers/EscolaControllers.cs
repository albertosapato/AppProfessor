namespace DataEntityFrameWork.Controllers
{
    using DataEntityFrameWork.Controllers.Helps;
    using DataEntityFrameWork.Controllers.Interfaces;
    using DataEntityFrameWork.Models;
    using DataEntityFrameWork.Models.Helps;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EscolaControllers : IEscola
    {
        #region Forma Singliton
        private static EscolaControllers Instacia;
        public static EscolaControllers GetInstacia()
        {
            if (Instacia == null)
                return new EscolaControllers();
            else
                return Instacia;
        }
        #endregion

        #region Metodos
        public async Task<Response> Delete(Escola escola)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoDelete<Escola>(escola).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = escola,
                        Messgems = result.Exception,
                    };
                }
            }      
        }

        public async Task<int> GetCount(string nome)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Escola.CountAsync();
            }
        }
        public async Task<int> GetCount(string nome, string republica, string ministerio)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Escola.Where(x => x.Nome.ToUpper() == nome.ToUpper() &&
                                                  x.republica.ToUpper() == republica.ToUpper() &&
                                                  x.Ministerio.ToUpper() == ministerio.ToUpper()).CountAsync();
            }
        }

        public async Task<List<Escola>> GetList()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Escola.ToListAsync();
            }
        }

        public async Task<List<Escola>> GetList(string param)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Escola.Where(x => x.Nome.ToLower().Contains(param.ToLower()))
                                .ToListAsync();
            }
        }

        public async Task<Response> Insert(Escola escola)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoInsert<Escola>(escola).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = escola,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<Response> Update(Escola  escola)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoUpdate<Escola>(escola).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = escola,
                        Messgems = result.Exception,
                    };
                }
            }
        }
        #endregion
    }
}
