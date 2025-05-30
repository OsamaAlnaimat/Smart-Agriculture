using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Recommendations.Models
{

    public class RecommendationResponse
    {
        public string status { get; set; }
        public string userId { get; set; }
        public RecommendationList[] recommendations { get; set; }
        public bool cached { get; set; }
    }

    public class RecommendationList
    {
        public string parameter { get; set; }
        public string value { get; set; }
        public string status { get; set; }
        public string advice { get; set; }
    }

}
