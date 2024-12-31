using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace diaTest.Models
{
    public class CariTablo
    {
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("_key")]
        public string Key { get; set; } // _key

        [JsonPropertyName("unvan")]
        public string CariAdi { get; set; } // unvan

        [JsonPropertyName("ulke")]
        public string Ulke { get; set; } // ulke

        [JsonPropertyName("dovizturu")]
        public string DovizTuru { get; set; } // dovizturu

        [JsonPropertyName("firmaadi")]
        public string FirmaAdi { get; set; } // firmaadi

        [JsonPropertyName("adresbilgi")]
        public string Adres { get; set; }

        [JsonPropertyName("eposta")]
        public string Eposta { get; set; }

        [JsonPropertyName("vergidairesi")]
        public string VergiDairesi { get; set; }

        [JsonPropertyName("verginumarasi")]
        public string VergiNumarasi { get; set; }
    }
}