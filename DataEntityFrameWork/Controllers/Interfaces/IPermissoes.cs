using DataEntityFrameWork.Models;
using DataEntityFrameWork.Models.Helps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityFrameWork.Controllers.Interfaces
{
    public interface IPermissoes
    {
        Task<List<Permissoes>> GetList();
        Task<List<Permissoes>> GetList(string param);
        Task<int> GetCount();
        Task<Response> Insert(Permissoes models);
        Task<Response> Update(Permissoes models);
        Task<Response> Delete(Permissoes models);
    }
}
