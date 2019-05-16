namespace DataEntityFrameWork.Controllers.Interfaces
{
    using DataEntityFrameWork.Models;
    using DataEntityFrameWork.Models.Helps;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITurmas
    {
        Task<List<Turmas>> GetList();
        Task<List<Turmas>> GetList(string param);
        Task<int> GetCount();
        Task<Response> Insert(Turmas models);
        Task<Response> Update(Turmas models);
        Task<Response> Delete(Turmas models);
    }
}
