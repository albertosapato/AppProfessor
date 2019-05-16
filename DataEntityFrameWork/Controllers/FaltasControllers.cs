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

    public class FaltasControllers : IFaltas
    {
        #region Forma Singliton
        private static FaltasControllers Instacia;
        public static FaltasControllers GetInstacia()
        {
            if (Instacia == null)
                return new FaltasControllers();
            else
                return Instacia;
        }
        #endregion

        #region Metodos
        public async Task<Response> Delete(Faltas faltas)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoDelete<Faltas>(faltas).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = faltas,
                        Messgems = result.Exception,
                    };
                }
            }      
        }

        public async Task<int> GetCount()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Faltas.CountAsync();
            }
        }

        public async Task<List<Faltas>> GetList()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Faltas.Include(x => x.Alunos)
                                .ToListAsync();
            }
        }

        public async Task<List<Faltas>> GetList(string param)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Faltas.Include(x => x.Alunos)
                                .Where(x => x.Alunos.Nome.ToLower().Contains(param.ToLower()))
                                .ToListAsync();
            }
        }

        public async Task<Response> Insert(Faltas faltas)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoInsert<Faltas>(faltas).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = faltas,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<Response> Update(Faltas faltas)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoUpdate<Faltas>(faltas).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = faltas,
                        Messgems = result.Exception,
                    };
                }
            }
        }
        #endregion
    }
}
