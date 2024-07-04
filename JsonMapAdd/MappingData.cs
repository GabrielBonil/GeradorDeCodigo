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
        public string TipoTraduzido { get; set; }


        public static Dictionary<int,string> Type = new Dictionary<int, string>
        {
            { 1,"Atributo"},
            { 2,"Elemento"},
            { 3,"Server"},
            { 4,"Direct"}
        };


    }
}
