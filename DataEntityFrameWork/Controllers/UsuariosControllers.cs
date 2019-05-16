namespace DataEntityFrameWork.Controllers
{
    using DataEntityFrameWork.Controllers.Helps;
    using DataEntityFrameWork.Controllers.Interfaces;
    using DataEntityFrameWork.Models;
    using DataEntityFrameWork.Models.Helps;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UsuariosControllers : IUsuarios
    {
        #region Forma Singliton
        private static UsuariosControllers Instacia;
        public static UsuariosControllers GetInstacia()
        {
            if (Instacia == null)
                return new UsuariosControllers();
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
                return await db.Usuarios.Include(x => x.Grupos).ToListAsync();
            }
        }

        public async Task<List<Usuarios>> GetList(string param)
        {
            using (AppProfessorContext db = new AppProfessorContext())
            {
                return await db.Usuarios
                    
                    .Include(x => x.Grupos)
                    .Where(x => x.Login.ToLower().Contains(param.ToLower()))
                                .ToListAsync();
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


        #region Extensions
        public async Task<int> Actualizar(string User, string Senha, string Senha2)
        {
            var Key = Encriptar.GetMD5Hash(Senha);
            var Key2 = Encriptar.GetMD5Hash(Senha2);

            var item = (await GetList()).Where(x => (x.Login.ToLower() == User.ToLower() || x.Email == User) &&
                                                        (x.Senha == Key || x.Pin == Key))
                                           .FirstOrDefault();
            if (item != null)
            {
                if (item.Estado)
                {
                    item.Senha = Key2;

                    var result = await Update(item);

                    if (result.IsSucess)
                        return 1;
                    else
                        return 0;
                }
                else
                    return 3;
            }
            else
                return 4;
        }

        public async Task<int> Actualizar(string User, DateTime dataValues, string Senha2)
        {
            var Key2 = Encriptar.GetMD5Hash(Senha2);

            var item = (await GetList()).Where(x => (x.Login.ToLower() == User.ToLower() || x.Email == User))
                                           .FirstOrDefault();

            var result = DateTime.Compare(item.DataNascimento.Date, dataValues.Date);

            if (result == 0)
            {
                if (item != null)
                {
                    if (item.Estado)
                    {
                        item.Senha = Key2;

                        var resultr = await Update(item);
                        if (resultr.IsSucess)
                            return 1;
                        else
                            return 0;
                    }
                    else
                        return 3;
                }
                else
                    return 4;
            }
            else
                return 5;
        }
        #endregion
    }
}
