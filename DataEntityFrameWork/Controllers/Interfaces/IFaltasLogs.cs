using DataEntityFrameWork.Models;
using DataEntityFrameWork.Models.Helps;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataEntityFrameWork.Controllers.Interfaces
{
    public interface IFaltasLogs
    {
        Task<List<FaltasLogs>> GetList();
        Task<List<FaltasLogs>> GetList(string param);
        Task<int> GetCount();
        Task<Response> Insert(FaltasLogs models);
        Task<Response> Update(FaltasLogs models);
        Task<Response> Delete(FaltasLogs models);
    }
}
