using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuttiBot
{
    class SearchIds
    {
        public SearchIds(string searchTerm, List<int> ids)
        {
            this.searchTerm = searchTerm;
            this.ids = ids;
        }

        public string searchTerm { get; set; }
        public List<int> ids { get; set; }


    }
}
