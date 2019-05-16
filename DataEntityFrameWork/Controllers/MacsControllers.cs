namespace DataEntityFrameWork.Controllers
{
    using DataEntityFrameWork.Controllers.Helps;
    using DataEntityFrameWork.Controllers.Interfaces;
    using DataEntityFrameWork.Models;
    using DataEntityFrameWork.Models.Helps;
    using DataEntityFrameWork.ViewModels;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MacsControllers : IMacs
    {
        #region Forma Singliton
        private static MacsControllers Instacia;
        public static MacsControllers GetInstacia()
        {
            if (Instacia == null)
                return new MacsControllers();
            else
                return Instacia;
        }
        #endregion

        #region Metodos
        public async Task<Response> Delete(Macs alunos)
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
                    var result = await db.DoDelete<Macs>(alunos).EndTransaction();

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
                return await db.Macs1.CountAsync();
            }
        }
        public async Task<int> GetCount(object value)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Macs1.Where(x => x.TrimestreID == (int) value)
                    .CountAsync();
            }
        }
        public async Task<List<MacsViewModels>> GetList(int trimestre, int? turma)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                var result = await db.Macs1.Include(x => x.Alunos)
                                           .Include(x => x.Trimestres)
                                           .Where(x => x.TrimestreID == trimestre)
                                           .OrderBy(x => x.Alunos.Nome)
                                           .ToListAsync();

                var resultTurmasInclud = turma == null ? (await db.Alunos.ToListAsync()) : (await db.Alunos.Where(x => x.TurmasID == turma).ToListAsync());

                List<MacsViewModels> macsViewModels = new List<MacsViewModels>();

                if (result.Count > 0)
                {
                    // Colocar tudo
                    result.ForEach(x =>
                    {
                        var models = new MacsViewModels()
                        {
                            Alunos = new Alunos
                            {
                                AlunosID = x.Alunos.AlunosID,
                                Nome = x.Alunos.Nome,
                            },
                            Trimestres = new Trimestres
                            {
                                Descricao = x.Trimestres.Descricao,
                                Inicio = x.Trimestres.Inicio,
                                TrimestreID = x.TrimestreID,
                                Termino = x.Trimestres.Termino,
                                TrimestreNome = x.Trimestres.TrimestreNome,
                            },
                            AlunosID = x.AlunosID,
                            MacsID = x.MacsID,
                            nota1 = x.nota1,
                            nota2 = x.nota2,
                            nota3 = x.nota3,
                            nota4 = x.nota4,
                            nota5 = x.nota5,
                            nota6 = x.nota6,
                            nota7 = x.nota7,
                            nota8 = x.nota8,
                            TrimestreID = x.TrimestreID,
                        };
                        macsViewModels.Add(models);
                    });
                }
                else
                {                 
                    resultTurmasInclud.ForEach(x =>
                    {
                        var models = new MacsViewModels()
                        {                    
                            AlunosID = x.AlunosID,
                            nota1 = 0,
                            nota2 = 0,
                            nota3 = 0,
                            nota4 = 0,
                            nota5 = 0,
                            nota6 = 0,
                            nota7 = 0,
                            nota8 = 0,
                            TrimestreID = trimestre,
                            MacsID = 0,
                            // Falta o <trimestre

                            Alunos = new Alunos
                            {
                                AlunosID = x.AlunosID,
                                Nome = x.Nome,
                            },
                            Trimestres = new Trimestres
                            {
                                TrimestreID = trimestre,
                            },
                        };
                        macsViewModels.Add(models);
                    });
                }
                return macsViewModels;
            }
        }

        public async Task<List<Macs>> GetList(string param)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Macs1.Include(x => x.Alunos)
                                     .Include(x => x.Trimestres)
                                     .Where(x => x.Alunos.Nome.ToLower().Contains(param.ToLower()))
                                     .ToListAsync();
            }
        }
        public async Task<List<Macs>> GetList(int turma)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Macs1.Include(x => x.Alunos)
                                     .Include(x => x.Trimestres)
                                     .Where(x => x.Alunos.TurmasID == turma)
                                     .ToListAsync();
            }
        }

        public async Task<Response> InsertAll(List<Macs> models)
        {
            var result = models.FirstOrDefault(x => x.MacsID == 0);
            if (result != null)
                return await Insert(models);
            else
                return await Update(models);
        }

        public async Task<Response> Insert(List<Macs> models)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoInsertRange(models).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = models,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<Response> Update(List<Macs> models)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoUpdateRange(models).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = models,
                        Messgems = result.Exception,
                    };
                }
            }
        }
        Task<List<Macs>> IMacs.GetList()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
