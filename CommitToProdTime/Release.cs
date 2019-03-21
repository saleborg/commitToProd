using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitToProdTime
{
    class Release
    {
        public string id { get; set; }
        public string name { get; set; }
        public IDictionary<string, Environment> environments = new Dictionary<string, Environment>();
        public string buildId { get; set; }


        public override bool Equals(object obj)
        {
            var s = obj.ToString();
            return s.Equals(id);
        }


    }
}
