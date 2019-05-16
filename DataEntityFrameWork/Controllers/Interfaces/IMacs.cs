using DataEntityFrameWork.Models;
using DataEntityFrameWork.Models.Helps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityFrameWork.Controllers.Interfaces
{
    public interface IMacs
    {
        Task<List<Macs>> GetList();
        Task<List<Macs>> GetList(string param);
        Task<List<Macs>> GetList(int param);
        Task<int> GetCount();
        Task<int> GetCount(object value);    
         Task<Response> InsertAll(List<Macs> alunos);
        Task<Response> Insert(List<Macs> alunos);
        Task<Response> Update(List<Macs> alunos);
        Task<Response> Delete(Macs alunos);
        Task<Response> Delete(int alunos);
    }
}
