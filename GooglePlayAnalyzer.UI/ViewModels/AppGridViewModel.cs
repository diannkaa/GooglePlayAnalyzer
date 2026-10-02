using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlayAnalyzer.UI.ViewModels
{
    public class AppGridViewModel
    {
        public string App { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public double? Rating { get; set; }
        public int? Reviews { get; set; }
        public string Size { get; set; } = string.Empty;
        public long? Installs { get; set; }
        public string Type { get; set; } = string.Empty;
        public double? Price { get; set; }
        public string ContentRating { get; set; } = string.Empty;
        public string Genres { get; set; } = string.Empty;
        public string LastUpdated { get; set; } = string.Empty;
        public string CurrentVer { get; set; } = string.Empty;
        public string AndroidVer { get; set; } = string.Empty;
    }
}
