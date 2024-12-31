using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace diaTest.Models
{
    public class FaturaTablo
    {
        [Key]
        public int FaturaId { get; set; }

        [JsonPropertyName("firmaadi")]
        public string FirmaAdi { get; set; } // firmaadi

        [JsonPropertyName("dovizturu")]
        public string DovizTuru { get; set; } // dovizturu

        [JsonPropertyName("__cariverginumarasi")]
        public string CariVergiNo { get; set; } // __cariverginumarasi

        [JsonPropertyName("__carivergidairesi")]
        public string CariVergiDairesi { get; set; } // __carivergidairesi

        [JsonPropertyName("__carifirma")]
        public string CariFirma { get; set; } // __carifirma

        [JsonPropertyName("sevkadresi")]
        public string SevkAdresi { get; set; } // sevkadresi

        [JsonPropertyName("toplammiktar")]
        public string ToplamMiktar { get; set; } // toplammiktar

        [JsonPropertyName("toplam")]
        public string Toplam { get; set; } // toplam

        [JsonPropertyName("tarih")]
        public DateTime Tarih { get; set; } // tarih

        [JsonPropertyName("toplamkdv")]
        public string ToplamKdv { get; set; } // toplamkdv

        [JsonPropertyName("dovizkuru")]
        public string DovizKuru { get; set; } // dovizkuru

        [JsonPropertyName("fisno")]
        public string FisNo { get; set; } // fisno

        [JsonPropertyName("toplamdvz")]
        public string ToplamDoviz { get; set; } // toplamdvz

        [JsonPropertyName("netdvz")]
        public string NetDoviz { get; set; } // netdvz

        [JsonPropertyName("bekleyentutar")]
        public string BekleyenTutar { get; set; } // bekleyentutar

        [JsonPropertyName("toplamara")]
        public string ToplamPara { get; set; } // toplamara

        [JsonPropertyName("toplamaradvz")]
        public string ToplamParaDoviz { get; set; } // toplamaradvz

        [JsonPropertyName("kalantutar_taksit")]
        public string KalanTaksitTutar { get; set; } // kalantutar_taksit

        [JsonPropertyName("faturasecretkey")]
        public string FaturaSecretKey { get; set; } // faturasecretkey

        [JsonPropertyName("_key_scf_carikart")]
        public string? CariId { get; set; }
    }
}