namespace DataEntityFrameWork.Controllers.Interfaces
{
    using DataEntityFrameWork.Models;
    using DataEntityFrameWork.Models.Helps;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUsuarios
    {
        Task<List<Usuarios>> GetList();
        Task<List<Usuarios>> GetList(string param);
        Task<int> GetCount();
        Task<Response> Insert(Usuarios models);
        Task<Response> Update(Usuarios models);
        Task<Response> Delete(Usuarios models);
    }
}
