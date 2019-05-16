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

    public class TrimestresControllers : ITrimestres
    {
        #region Forma Singliton
        private static TrimestresControllers Instacia;
        public static TrimestresControllers GetInstacia()
        {
            if (Instacia == null)
                return new TrimestresControllers();
            else
                return Instacia;
        }
        #endregion

        #region Metodos
        public async Task<Response> Delete(Trimestres trimestres)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoDelete<Trimestres>(trimestres).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = trimestres,
                        Messgems = result.Exception,
                    };
                }
            }      
        }
        public async Task<Response> Delete(int trimestres)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoDelete<Trimestres>(trimestres).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = trimestres,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<int> GetCount()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Trimestres.CountAsync();
            }
        }
        public async Task<int> GetCount(string nome)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Trimestres
                               .Where(x => x.TrimestreNome.ToUpper() == nome.ToUpper())
                               .CountAsync();
            }
        }

        public async Task<List<Trimestres>> GetList()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Trimestres.ToListAsync();
            }
        }

        public async Task<List<Trimestres>> GetList(string param)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Trimestres.Where(x => x.TrimestreNome.ToLower().Contains(param.ToLower()))
                                .ToListAsync();
            }
        }

        public async Task<Response> Insert(Trimestres trimestres)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoInsert<Trimestres>(trimestres).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = trimestres,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<Response> Update(Trimestres trimestres)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoUpdate<Trimestres>(trimestres).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = trimestres,
                        Messgems = result.Exception,
                    };
                }
            }
        }
        #endregion
    }
}
