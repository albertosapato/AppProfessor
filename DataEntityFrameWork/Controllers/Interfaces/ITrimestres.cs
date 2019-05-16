namespace DataEntityFrameWork.Controllers.Interfaces
{
    using DataEntityFrameWork.Models;
    using DataEntityFrameWork.Models.Helps;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITrimestres
    {
        Task<List<Trimestres>> GetList();
        Task<List<Trimestres>> GetList(string param);
        Task<int> GetCount();
        Task<Response> Insert(Trimestres models);
        Task<Response> Update(Trimestres models);
        Task<Response> Delete(Trimestres models);
    }
}
