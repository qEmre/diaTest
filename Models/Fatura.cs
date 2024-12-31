using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace diaTest.Models
{
    public class Fatura
    {
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("_key")]
        public int Key { get; set; }

        [JsonPropertyName("_date")]
        public DateTime Tarih { get; set; }

        [JsonPropertyName("toplam")]
        public string Toplam { get; set; }

        [JsonPropertyName("toplamkdv")]
        public string ToplamKdv { get; set; }

        [JsonPropertyName("_key_scf_carikart")]
        public CariKart CariKart { get; set; }

        [JsonPropertyName("_key_scf_carikart_adresleri")]
        public CariKartAdresi CariKartAdresi { get; set; }
    }
}