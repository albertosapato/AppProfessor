using DataEntityFrameWork.Models;
using DataEntityFrameWork.Models.Helps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityFrameWork.Controllers.Interfaces
{
    public interface ILogs
    {
        Task<List<Logs>> GetList();
        Task<List<Logs>> GetList(string param);
        Task<List<Logs>> GetList(int param);
        Task<int> GetCount();
        Task<Response> Insert(Logs models);
        Task<Response> Update(Logs models);
        Task<Response> Delete(Logs models);
    }
}
