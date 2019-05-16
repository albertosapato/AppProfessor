namespace DataEntityFrameWork.Controllers.Interfaces
{
    using DataEntityFrameWork.Models;
    using DataEntityFrameWork.Models.Helps;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IClasses
    {
        Task<List<Classes>> GetList();
        Task<List<Classes>> GetList(string param);
        Task<int> GetCount(string Nome);
        Task<Response> Insert(Classes models);
        Task<Response> Update(Classes models);
        Task<Response> Delete(Classes models);
    }
}
