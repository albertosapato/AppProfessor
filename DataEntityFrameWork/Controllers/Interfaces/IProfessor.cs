using DataEntityFrameWork.Models;
using DataEntityFrameWork.Models.Helps;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataEntityFrameWork.Controllers.Interfaces
{
    public interface IProfessor
    {
        Task<List<Professor>> GetList();
        Task<List<Professor>> GetList(string param);
        Task<int> GetCount();
        Task<int> GetCount(string param, string Bi);
        Task<Response> Insert(Professor models);
        Task<Response> Update(Professor models);
        Task<Response> Delete(Professor models);
        Task<Response> Delete(int models);
    }
}
