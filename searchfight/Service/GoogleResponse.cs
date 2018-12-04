using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchfight.Service
{
    public class GoogleResponse
    {
        public string Kind { get; set; }

        public SearchInformationModel SearchInformation { get; set; }


        public class SearchInformationModel
        {
            public double SearchTime { get; set; }
            public long TotalResults { get; set; }
        }
    }
}
