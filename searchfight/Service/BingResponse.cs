using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchfight.Service
{
    public class BingResponse
    {
        public string _Type { get; set; }

        public WebPageModel WebPages { get; set; }

        public class WebPageModel
        {
            public string WebSearchUrl { get; set; }

            public long TotalEstimatedMatches { get; set; }
        }
    }
}
