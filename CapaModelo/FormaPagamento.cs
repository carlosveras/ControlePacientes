using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class FormaPagamento
    {
        public int IdFormaPagto { get; set; }
        public string Descricao { get; set; }

        public int QtParcelas { get; set; }

        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
