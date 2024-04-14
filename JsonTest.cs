using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Test
{
    class JsonTest
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("Apellido")]
        public string Apellido { get; set; }

        [JsonProperty("identificacion")]
        public string Identificacion { get; set; }

        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        [JsonProperty("validar")]
        public string Validar { get; set; }

    }
}
