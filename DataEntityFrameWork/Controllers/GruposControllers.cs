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

    public class GruposControllers : IGrupos
    {
        #region Forma Singliton
        private static GruposControllers Instacia;
        public static GruposControllers GetInstacia()
        {
            if (Instacia == null)
                return new GruposControllers();
            else
                return Instacia;
        }
        #endregion

        #region Metodos
        public async Task<Response> Delete(Grupos usuarios)
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
        public async Task<Response> Delete(int usuarios)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoDelete<Grupos>(usuarios).EndTransaction();

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
                return await db.Grupos.CountAsync();
            }
        }
        public async Task<int> GetCount(string nome)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Grupos.Where(x => x.GrupoNome.ToUpper() == nome.ToUpper())
                               .CountAsync();
            }
        }

        public async Task<List<Grupos>> GetList()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Grupos.ToListAsync();
            }
        }

        public async Task<List<Grupos>> GetList(string param)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Grupos.Where(x => x.GrupoNome.ToLower().Contains(param.ToLower()))
                                .ToListAsync();
            }
        }
       public async Task<List<Grupos>> GetList(int param)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Grupos.Where(x => x.GrupoId == param)
                                .ToListAsync();
            }
        }

        public async Task<Response> Insert(Grupos usuarios)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoInsert<Grupos>(usuarios).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = usuarios,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<Response> Update(Grupos usuarios)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoUpdate<Grupos>(usuarios).EndTransaction();

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
