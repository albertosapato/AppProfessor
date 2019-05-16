namespace DataEntityFrameWork.Controllers.Interfaces
{
    using DataEntityFrameWork.Models;
    using DataEntityFrameWork.Models.Helps;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IAlunos
    {
        Task<List<Alunos>> GetList();
        Task<List<Alunos>> GetList(string param);
        Task<int> GetCount();
        Task<int> GetCount(object param);
        Task<Response> Insert(Alunos models);
        Task<Response> Update(Alunos models);
        Task<Response> Delete(Alunos models);
        Task<Response> Delete(int param);
    }
}
