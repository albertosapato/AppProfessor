namespace DataEntityFrameWork.Controllers.Interfaces
{
    using DataEntityFrameWork.Models;
    using DataEntityFrameWork.Models.Helps;
    using DataEntityFrameWork.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IProfessorDisciplina
    {
        Task<List<Professor_Disciplina>> GetList();
        Task<List<Professor_Disciplina>> GetList(string param);
        Task<ProfessorViewModelsAdapter> GetList(int param);
        Task<int> GetCount();
        Task<int> GetCount(int prof, int Disc);
        Task<Response> Insert(Professor_Disciplina models);
        Task<Response> Update(Professor_Disciplina models);
        Task<Response> Delete(Professor_Disciplina models);
        Task<Response> Delete(int param);
    }
}
