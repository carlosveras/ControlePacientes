using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class resposta<T>
    {
        public bool estado { get; set; }
        public string valor { get; set; }
        public T objeto { get; set; }
    }
}
