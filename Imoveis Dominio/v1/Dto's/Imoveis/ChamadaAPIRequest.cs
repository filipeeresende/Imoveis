using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imoveis_Dominio.v1.Dto_s.Imoveis
{
    public class ChamadaAPIRequest
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }
        public string ddd { get; set; }
        public string siafi { get; set; }

    }
}
