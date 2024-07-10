using System;
using System.Collections.Generic;
using System.Text;

namespace JsonMapAdd
{
    public class MappingData
    {
        public int Tipo { get; set; }
        public List<string> Filtro { get; set; }
        public string Mudar { get; set; }
        public string Chave { get; set; }
        public enum typeAction
        {
            Atributo,
            Elemento,
            Server,
            Direct
        }
    }
}
