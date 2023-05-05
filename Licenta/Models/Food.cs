using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class Food
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Details { get; set; }
        public string Ingredients { get; set; }
        public string FeedingRecommendation { get; set; }
        public string Price { get; set; }
        public string Rating { get; set; }
    }
}
