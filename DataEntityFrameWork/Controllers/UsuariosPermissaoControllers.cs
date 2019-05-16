namespace DataEntityFrameWork.Controllers
{
    using DataEntityFrameWork.Controllers.Helps;
    using DataEntityFrameWork.Models;
    using DataEntityFrameWork.Models.Helps;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class PermissoesPermissaoControllers
    {
        #region Forma Singliton
        private static PermissoesPermissaoControllers Instacia;
        public static PermissoesPermissaoControllers GetInstacia()
        {
            if (Instacia == null)
                return new PermissoesPermissaoControllers();
            else
                return Instacia;
        }
        #endregion

        #region Metodos
        public async Task<Response> Delete(Permissoes usuarios)
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
                return await db.Permissoes.CountAsync();
            }
        }

        public async Task<List<Permissoes>> GetList()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Permissoes.Include(x => x.Grupo)
                                          .ToListAsync();
            }
        }

        public async Task<List<Permissoes>> GetList(string param)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Permissoes.Include(x => x.Grupo)
                               .Where(x => x.Grupo.GrupoNome.ToLower().Contains(param.ToLower()))
                                .ToListAsync();
            }
        }
        public async Task<Permissoes> GetList(int param)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Permissoes.Include(x => x.Grupo)
                               .Where(x => x.GrupoId == param)
                                .FirstOrDefaultAsync();
            }
        }

        public async Task<Response> Insert(Permissoes usuarios)
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

        public async Task<Response> Update(Permissoes usuarios)
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
