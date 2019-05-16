using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityFrameWork.Models.Helps
{
    public class Response
    {
        public bool IsSucess { get; set; }
        public Exception Messgems { get; set; }
        public object list { get; set; }
    }
}
