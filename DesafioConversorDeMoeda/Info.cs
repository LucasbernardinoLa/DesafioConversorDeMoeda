using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioConversorDeMoeda
{
    public class Info
    {
        [JsonProperty("rate")]
        public double Rate { get;  set; }
    }
}
