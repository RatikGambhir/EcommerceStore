using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class NFLNews
    {
        public string header { get; set; }
        public Link link { get; set; }
        public List<Article> articles { get; set; }
    }

    public class Link
    {
        public string language { get; set; }
        public List<string> rel { get; set; }
        public string href { get; set; }
        public string text { get; set; }
        public string shortText { get; set; }
        public bool isExternal { get; set; }
        public bool isPremium { get; set; }
    }

    public class Image
    {
        public string name { get; set; }
        public int width { get; set; }
        public string alt { get; set; }
        public string caption { get; set; }
        public string url { get; set; }
        public int height { get; set; }
        public int? id { get; set; }
        public string credit { get; set; }
        public string type { get; set; }
    }
  
    public class Category
    {
        public int id { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public int sportId { get; set; }
        public int leagueId { get; set; }
    
        public string uid { get; set; }
        public DateTime createDate { get; set; }
        public int? teamId { get; set; }
   
        public int? athleteId { get; set; }
       
        public string guid { get; set; }
        public int? topicId { get; set; }
    }

    public class Article
    {
        public List<Image> images { get; set; }
        public string description { get; set; }
        public DateTime published { get; set; }
        public string type { get; set; }
        public bool premium { get; set; }

        public DateTime lastModified { get; set; }
        public List<Category> categories { get; set; }
        public string headline { get; set; }
        public string byline { get; set; }
    }

    
}