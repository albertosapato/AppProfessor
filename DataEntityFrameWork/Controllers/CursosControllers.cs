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

    public class CursosControllers : ICursos
    {
        #region Forma Singliton
        private static CursosControllers Instacia;
        public static CursosControllers GetInstacia()
        {
            if (Instacia == null)
                return new CursosControllers();
            else
                return Instacia;
        }
        #endregion

        #region Metodos
        public async Task<Response> Delete(Cursos cursos)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoDelete<Cursos>(cursos).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = cursos,
                        Messgems = result.Exception,
                    };
                }
            }      
        }

        public async Task<Response> Delete(int cursos)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoDelete<Cursos>(cursos).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = cursos,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<int> GetCount()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Cursos.CountAsync();
            }
        }
        public async Task<int> GetCount(string nome)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Cursos
                               .Where(x => x.CursosNome.ToUpper() == nome.ToUpper()).CountAsync();
            }
        }

        public async Task<List<Cursos>> GetList()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Cursos.ToListAsync();
            }
        }

        public async Task<List<Cursos>> GetList(string param)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Cursos.Where(x => x.CursosNome.ToLower().Contains(param.ToLower()))
                                .ToListAsync();
            }
        }

        public async Task<Response> Insert(Cursos cursos)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoInsert<Cursos>(cursos).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = cursos,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<Response> Update(Cursos cursos)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoUpdate<Cursos>(cursos).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = cursos,
                        Messgems = result.Exception,
                    };
                }
            }
        }
        #endregion
    }
}
