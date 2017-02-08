using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopNetMiner
{
    public class SearchArea
    {
        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public List<string> AddtlUrls { get; set; }
        //
        public SearchArea(string name, string url)
        {
            Name = name;
            BaseUrl = url;
        }
    }
}
