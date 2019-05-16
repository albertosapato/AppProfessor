namespace DataEntityFrameWork.Controllers.Interfaces
{
    using DataEntityFrameWork.Models;
    using DataEntityFrameWork.Models.Helps;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPeriodos
    {
        Task<List<Periodo>> GetList();
        Task<List<Periodo>> GetList(string param);
        Task<int> GetCount();
        Task<Response> Insert(Periodo models);
        Task<Response> Update(Periodo models);
        Task<Response> Delete(Periodo models);
    }
}
