using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class FeedbackDto
    {
        public string Name { get; set; }

      public string FavoritePart { get; set; }

      public string LeastFavoritePart { get; set; }
      public string WhatDidWeDoWell { get; set; }

      public string WhatWeDidNotDoWell { get; set; }

      public string AnotherProject { get; set; }

      public string FinalThoughts { get; set; }
    
    }
}