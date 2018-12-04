using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchfight.Model
{
    public class ResultSearch
    {
  
        public ResultSearch()
        {
        }

        public ResultSearch(string engine, string language, int total)
        {
            Engine = engine;
            Language = language;
            Total = total;
        }

        public string Language { get; set; }
        public long Total { get; set; }
        public string Engine { get; set; }
    }
}
