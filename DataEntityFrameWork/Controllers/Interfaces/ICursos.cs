namespace DataEntityFrameWork.Controllers.Interfaces
{
    using DataEntityFrameWork.Models;
    using DataEntityFrameWork.Models.Helps;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICursos
    {
        Task<List<Cursos>> GetList();
        Task<List<Cursos>> GetList(string param);
        Task<int> GetCount();
        Task<Response> Insert(Cursos models);
        Task<Response> Update(Cursos models);
       Task<Response> Delete(Cursos models);
    }
}
