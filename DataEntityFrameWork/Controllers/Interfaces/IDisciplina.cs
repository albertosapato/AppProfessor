namespace DataEntityFrameWork.Controllers.Interfaces
{
    using DataEntityFrameWork.Models;
    using DataEntityFrameWork.Models.Helps;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDisciplina
    {
        Task<List<Disciplina>> GetList();
        Task<List<Disciplina>> GetList(string param);
        Task<int> GetCount();
        Task<int> GetCount(object param);
        Task<Response> Insert(Disciplina models);
        Task<Response> Update(Disciplina models);
        Task<Response> Delete(Disciplina models);
        Task<Response> Delete(int models);
    }
}