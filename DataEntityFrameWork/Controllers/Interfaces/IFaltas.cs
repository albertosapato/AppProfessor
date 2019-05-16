namespace DataEntityFrameWork.Controllers.Interfaces
{
    using DataEntityFrameWork.Models;
    using DataEntityFrameWork.Models.Helps;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFaltas
    {
        Task<List<Faltas>> GetList();
        Task<List<Faltas>> GetList(string param);
        Task<int> GetCount();
        Task<Response> Insert(Faltas models);
        Task<Response> Update(Faltas models);
        Task<Response> Delete(Faltas models);
    }
}
