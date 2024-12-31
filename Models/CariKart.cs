using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace diaTest.Models
{
    public class CariKart
    {
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("_key")]
        public int Key { get; set; }

        [JsonPropertyName("unvan")]
        public string Unvan { get; set; }

        [JsonPropertyName("verginumarasi")]
        public string VergiNumarasi { get; set; }
    }
}