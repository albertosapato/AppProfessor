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

    public class AlunosControllers : IAlunos
    {
        #region Forma Singliton
        private static AlunosControllers Instacia;
        public static AlunosControllers GetInstacia()
        {
            if (Instacia == null)
                return new AlunosControllers();
            else
                return Instacia;
        }
        #endregion

        #region Metodos
        public async Task<Response> Delete(Alunos alunos)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoDelete(alunos).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = alunos,
                        Messgems = result.Exception,
                    };
                }
            }      
        }
        public async Task<Response> Delete(int alunos)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoDelete<Alunos>(alunos).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = alunos,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<int> GetCount()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Alunos.CountAsync();
            }
        }
        public async Task<int> GetCount(object value)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Alunos.Where(x => x.Nome == value.ToString())
                    .CountAsync();
            }
        }
        public async Task<List<Alunos>> GetList()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Alunos.Include(x => x.Turmas)
                                       .Include(x => x.Faltas)
                                .OrderBy(x => x.Nome)
                                .ToListAsync();
            }
        }

        public async Task<List<Alunos>> GetList(string param)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Alunos.Where(x => x.Nome.ToLower().Contains(param.ToLower()))
                                .ToListAsync();
            }
        }

        public async Task<Response> Insert(Alunos alunos)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoInsert<Alunos>(alunos).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = alunos,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<Response> Update(Alunos alunos)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoUpdate<Alunos>(alunos).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = alunos,
                        Messgems = result.Exception,
                    };
                }
            }
        }
        #endregion
    }
}
