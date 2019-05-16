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

    public class ConectionsControllers : IUsuarios
    {
        #region Forma Singliton
        private static ConectionsControllers Instacia;
        public static ConectionsControllers GetInstacia()
        {
            if (Instacia == null)
                return new ConectionsControllers();
            else
                return Instacia;
        }
        #endregion

        #region Metodos
        public async Task<Response> Delete(Usuarios usuarios)
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
                return await db.Usuarios.CountAsync();
            }
        }

        public async Task<List<Usuarios>> GetList()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Usuarios.ToListAsync();
            }
        }

        public async Task<List<Usuarios>> GetList(string param)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Usuarios.Where(x => x.Login.ToLower().Contains(param.ToLower()))
                                .ToListAsync();
            }
        }
        public async Task<Usuarios> GetListFirstOrDefault()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Usuarios
                                .FirstOrDefaultAsync();
            }
        }

        public async Task<Response> Insert(Usuarios usuarios)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoInsert<Usuarios>(usuarios).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = usuarios,
                        Messgems = result.Exception,
                    };
                }
            }
        }



        public async Task<Response> Update(Usuarios usuarios)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoUpdate<Usuarios>(usuarios).EndTransaction();

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
