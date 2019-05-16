using DataEntityFrameWork.Models;
using DataEntityFrameWork.Models.Helps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityFrameWork.Controllers.Interfaces
{
    public interface IGrupos
    {
        Task<List<Grupos>> GetList();
        Task<List<Grupos>> GetList(string param);
        Task<List<Grupos>> GetList(int param);
        Task<int> GetCount();
        Task<Response> Insert(Grupos models);
        Task<Response> Update(Grupos models);
        Task<Response> Delete(Grupos models);
    }
}
