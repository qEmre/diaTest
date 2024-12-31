using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace diaTest.Models
{
    public class CariKartAdresi
    {
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("_key")]
        public int Key { get; set; }

        [JsonPropertyName("adres1")]
        public string Adres1 { get; set; }

        [JsonPropertyName("ilce")]
        public string Ilce { get; set; }

        [JsonPropertyName("telefon1")]
        public string Telefon { get; set; }
    }
}