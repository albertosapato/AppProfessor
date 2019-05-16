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

    public class ClasseControllers : IClasses
    {
        #region Forma Singliton
        private static ClasseControllers Instacia;
        public static ClasseControllers GetInstacia()
        {
            if (Instacia == null)
                return new ClasseControllers();
            else
                return Instacia;
        }
        #endregion

        #region Metodos
        public async Task<Response> Delete(Classes classes)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoDelete<Classes>(classes).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = classes,
                        Messgems = result.Exception,
                    };
                }
            }      
        }

        public async Task<Response> Delete(int classes)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoDelete<Classes>(classes).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = classes,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<int> GetCount(string nome)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Classes.Where(x => x.ClassesNome.ToUpper() == nome.ToUpper()).CountAsync();
            }
        }

        public async Task<List<Classes>> GetList()
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Classes.ToListAsync();
            }
        }

        public async Task<List<Classes>> GetList(string param)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Classes.Where(x => x.ClassesNome.ToLower().Contains(param.ToLower()))
                                .ToListAsync();
            }
        }

        public async Task<Response> Insert(Classes classes)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoInsert<Classes>(classes).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = classes,
                        Messgems = result.Exception,
                    };
                }
            }
        }

        public async Task<Response> Update(Classes classes)
        {
            using (AppProfessorContext context = new AppProfessorContext())
            {
                using (Transation_Scoper db = new Transation_Scoper(context))
                {
                    var result = await db.DoUpdate<Classes>(classes).EndTransaction();

                    return new Response
                    {
                        IsSucess = result.estado,
                        list = classes,
                        Messgems = result.Exception,
                    };
                }
            }
        }
        #endregion
    }
}
