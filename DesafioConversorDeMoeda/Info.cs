using Newtonsoft.Json;

namespace DesafioConversorDeMoeda
{
    public class Info
    {
        [JsonProperty("rate")]
        public double Rate { get;  set; }
    }
}
