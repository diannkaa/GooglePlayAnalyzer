using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlayAnalyzer.Domain.Entities
{
    public class App
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new Category();
        public string CategoryName
        {
            get { return Category?.Name ?? string.Empty; }
        }
        public double? Rating { get; set; }
        public int? ReviewsCount { get; set; }
        public string Size { get; set; } = string.Empty;
        public long? Installs { get; set; }
        public string Type { get; set; } = string.Empty;
        public double? Price { get; set; }
        public string ContentRating { get; set; } = string.Empty;
        public string Genres { get; set; } = string.Empty;
        public DateTime? LastUpdated { get; set; }
        public string CurrentVer { get; set; } = string.Empty;
        public string AndroidVer { get; set; } = string.Empty;
        public override string ToString()
        {
            return $"{Name} - {Category.Name} (${Price ?? 0})";
        }
    }
}


