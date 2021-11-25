using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTextGUI.Model;

namespace WPFTextGUI.Data
{
    public class Data
    {
        public static List<StatsResult> Results { get; set; } = new List<StatsResult>();

#if DEBUG
        public static string APIUrl = "https://localhost:7264";
#else
        public static string APIUrl = "http://demo.vakutech.cz";
#endif
    }
}
