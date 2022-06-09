using Newtonsoft.Json;

namespace DesafioConversorDeMoeda
{
    public class ConvertResponse
    {
        [JsonProperty("info")]
        public Info Info { get; set; }
       
       [JsonProperty("result")]
        public double Result { get; set; }
    }
}
