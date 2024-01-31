using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Request
    {
        public Operation Operation { get; set; }
        public object Objekat { get; set; }
    }
}
