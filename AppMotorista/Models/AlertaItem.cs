using System;
using System.Collections.Generic;
using System.Text;

namespace AppMotorista.Models
{
    public class AlertaItem
    {
        public string Titulo { get; set; }
        public string Descricao {  get; set; }
        public string DataHora { get; set; }
        public string Severidade { get; set; }
        public string CorFundo { get; set; }
        public string CorTexto { get; set; }
        public string Origem { get; set; }
    }
}
