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

    public class ProfessorDisciplinaControllers: IProfessorDisciplina
    {
        #region Forma Singliton
        private static ProfessorDisciplinaControllers Instacia;
        public static ProfessorDisciplinaControllers GetInstacia()
        {
            if (Instacia == null)
                return new ProfessorDisciplinaControllers();
            else
                return Instacia;
        }
        #endregion

        #region Metodos
        public async Task<Response> Delete(Professor_Disciplina models)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoDelete(models).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = models,
                        Messgems = result.Exception,
                    };
                }
            }
        }
        public async Task<Response> Delete(int models)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoDelete<Professor_Disciplina>(models).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = models,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<int> GetCount()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.professor_Disciplina.CountAsync();
            }
        }
        public async Task<int> GetCount(int professor, int disciplina)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.professor_Disciplina.Where(x => x.DisciplinaID == disciplina
                                                       &&       x.ProfessorID  == professor)
                                                    .CountAsync();
            }
        }
        public async Task<List<Professor_Disciplina>> GetList()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.professor_Disciplina.Include(x => x.Professor)
                                                    .Include(x => x.Disciplina)
                                .OrderBy(x => x.Professor.Nome)
                                .ToListAsync();
            }
        }

        public async Task<List<Professor_Disciplina>> GetList(string param)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.professor_Disciplina.Include(x => x.Professor)
                                                    .Include(x => x.Disciplina)
                                                    .Where(x => x.Professor.Nome.ToUpper() == param.ToUpper()
                                                          &&    x.Disciplina.Designacao.ToUpper() == param.ToUpper())
                                .OrderBy(x => x.Professor.Nome)
                                .ToListAsync();
            }
        }

        public async Task<ProfessorViewModelsAdapter> GetList(int param)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
               var result = await db.professor_Disciplina.Include(x => x.Professor)
                                                    .Include(x => x.Disciplina)
                                    .Where(x => x.ProfessorID == param)
                                    .OrderBy(x => x.Professor.Nome)
                                    .ToListAsync();

                var listresult = new ProfessorViewModelsAdapter();
                result.ForEach(x => 
                {
                    var list = new ProfessorViewModelsAdapter
                    {
                        Descricao = x.Descricao,
                        ProfessorDisciplinaID = x.ProfessorDisciplinaID,
                        ProfessorID = x.ProfessorID,
                        Professor = new ProfessorViewModels
                        {
                            ProfessorID = x.Professor.ProfessorID,
                            Bi = x.Professor.Bi,
                            DataNascimento = x.Professor.DataNascimento,
                            Escolaridade = x.Professor.Escolaridade,
                            Nome = x.Professor.Nome,
                            Sexo = x.Professor.Sexo,
                        },
                        Disciplina = result.Select(k => new DisciplinaViewModels
                        {
                            Designacao = k.Disciplina.Designacao,
                            DisciplinaID = k.Disciplina.DisciplinaID,
                            Sigla = k.Disciplina.Sigla,
                        }).ToList(),
                    };
                    listresult = list;
                    return;
                });
                return listresult;
            }
        }

        public async Task<Response> Insert(Professor_Disciplina models)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoInsert<Professor_Disciplina>(models).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = models,
                        Messgems = result.Exception,
                    };
                }
            }
        }
        public async Task<Response> Insert(ProfessorViewModelsAdapter models)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {


                    var result = await db.DoInsertIfNotExists( x => x.ProfessorDisciplinaID,
                                                                      models).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = models,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<Response> Update(Professor_Disciplina models)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoUpdate<Professor_Disciplina>(models).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = models,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<Response> Insert(ProfessorViewModelsAdapter Enviar, ProfessorViewModelsAdapter DaseDados)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    // Verificando na Dase de Dados
                    foreach (var itemEnviar in Enviar.Disciplina)
                    {
                        foreach (var itemBase in DaseDados.Disciplina)
                        {
                            if (itemEnviar.Designacao.ToUpper() == itemBase.Designacao.ToUpper())
                            {
                                db.DoUpdate<DisciplinaViewModels>(itemBase);
                            }
                            else
                            {
                                db.DoInsert<DisciplinaViewModels>(itemBase);
                            }
                        }
                    }
                    // Verificando Inversa Enviar / Base de Dados
                    foreach (var itemBase in DaseDados.Disciplina)
                    {
                        foreach (var itemEnviar in Enviar.Disciplina)
                        {
                            if (itemEnviar.Designacao.ToUpper() == itemBase.Designacao.ToUpper())
                            {
                                db.DoUpdate<DisciplinaViewModels>(itemBase);
                            }
                            else
                            {
                                db.DoInsert<DisciplinaViewModels>(itemBase);
                            }
                        }
                    }
                    //var result = await db.DoSincronizar<ProfessorViewModelsAdapter>(x =>x.ProfessorID, Enviar, DaseDados).EndTransaction();

                    return new Response
                    {
                        //IsSucess = result.estado,
                        //list = models,
                        //Messgems = result.Exception,
                    };
                }
            }
        }
        #endregion
    }
}
