using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Response
    {
        public Signal Signal { get; set; }
        public string Message { get; set; }
        public object Objekat { get; set; }
    }

    public enum Signal
    {
        //Cemu sluzi koji i da li fali neki?
        Ok,
        Error,
        KrajServer,
        VecPrijavljen,
        AlreadyLogedIn
    }
}
