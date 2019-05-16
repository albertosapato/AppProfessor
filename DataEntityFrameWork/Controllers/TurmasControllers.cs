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

    public class TurmasControllers : ITurmas
    {
        #region Forma Singliton
        private static TurmasControllers Instacia;
        public static TurmasControllers GetInstacia()
        {
            if (Instacia == null)
                return new TurmasControllers();
            else
                return Instacia;
        }
        #endregion

        #region Metodos
        public async Task<Response> Delete(Turmas turmas)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoDelete<Turmas>(turmas).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = turmas,
                        Messgems = result.Exception,
                    };
                }
            }      
        }
        public async Task<Response> Delete(int turmas)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoDelete<Turmas>(turmas).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = turmas,
                        Messgems = result.Exception,
                    };
                }
            }
        }
        public async Task<int> GetCount()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Turmas.CountAsync();
            }
        }

        public async Task<int> GetCount(string nome, int classe1, int periodo, int cursos)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Turmas.Where(x => x.TurmasNome.ToUpper() == nome.ToUpper() &&
                                                  x.ClassesID == classe1 &&
                                                  x.PeriodoID == periodo &&
                                                  x.CursosID == cursos).CountAsync();
            }
        }

        public async Task<List<Turmas>> GetList()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Turmas
                    .Include(x => x.Periodo)
                    .Include(x => x.Classes)
                    .Include(x => x.Cursos)
                    .ToListAsync();
            }
        }

        public async Task<List<Turmas>> GetList(string param)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Turmas
                               .Include(x => x.Periodo)
                               .Include(x => x.Classes)
                               .Include(x => x.Cursos)
                               .Where(x => x.Descricao.ToLower().Contains(param.ToLower()))
                               .ToListAsync();
            }
        }

        public async Task<Response> Insert(Turmas turmas)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoInsert<Turmas>(turmas).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = turmas,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<Response> Update(Turmas turmas)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result  = await db.DoUpdate<Turmas>(turmas).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = turmas,
                        Messgems = result.Exception,
                    };
                }
            }
        }
        #endregion
    }
}
