namespace DataEntityFrameWork.Controllers.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DataEntityFrameWork.Models;
    using DataEntityFrameWork.Models.Helps;

    public interface IEscola
    {
        Task<List<Escola>> GetList();
        Task<List<Escola>> GetList(string param);
        Task<int> GetCount(string nome);
        Task<Response> Insert(Escola models);
        Task<Response> Update(Escola models);
       Task<Response> Delete(Escola models);
    }
}
