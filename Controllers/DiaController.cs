using diaTest.DataLayer;
using diaTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace diaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaController : ControllerBase
    {
        private readonly ProjectDbContext _projectDbContext;
        private readonly HttpClient _httpClient;

        public DiaController(ProjectDbContext projectDbContext, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _projectDbContext = projectDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Login()
        {
            string apiUrl = "https://diademo.ws.dia.com.tr/api/v3/";

            var login = new
            {
                login = new
                {
                    username = "ws",
                    password = "ws",
                    disconnect_same_user = true,
                    lang = "tr",
                    apikey = "773f9085-9dc8-4f50-b34d-f7b56da33b5f" // API key
                }
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(login), Encoding.UTF8, "application/json");

            HttpResponseMessage loginResponse = await _httpClient.PostAsync(apiUrl + "sis/json", jsonContent);

            var loginContent = await loginResponse.Content.ReadAsStringAsync();

            var loginResult = JsonSerializer.Deserialize<Dictionary<string, object>>(loginContent);

            // sessionid, dönen yanıtta msg içinde olacaktır
            string sessionId = loginResult["msg"].ToString();

            return Ok(new { SessionID = sessionId });
        }

        [HttpPost("list-current")]
        public async Task<IActionResult> ListCurrent(string sessionId)
        {
            string apiUrl = "https://diademo.ws.dia.com.tr/api/v3/";

            var current = new
            {
                scf_carikart_listele = new
                {
                    session_id = sessionId, // zorunlu
                    firma_kodu = 34, // zorunlu
                    donem_kodu = 7,
                    filters = "",
                    limit = 500,
                    offset = 0
                }
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(current), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(apiUrl + "scf/json", jsonContent);

            var responseContent = await response.Content.ReadAsStringAsync();

            var currentResult = JsonSerializer.Deserialize<Dictionary<string, object>>(responseContent);

            var currentList = JsonSerializer.Deserialize<List<CariTablo>>(currentResult["result"].ToString());

            foreach (var c in currentList)
            {
                if (!_projectDbContext.CariTablo.Any(c => c.Key == c.Key))
                {
                    var cari = new CariTablo
                    {
                        Key = c.Key,
                        CariAdi = c.CariAdi,
                        Ulke = c.Ulke,
                        DovizTuru = c.DovizTuru,
                        FirmaAdi = c.FirmaAdi,
                        Adres = c.Adres,
                        Eposta = c.Eposta,
                        VergiDairesi = c.VergiDairesi,
                        VergiNumarasi = c.VergiNumarasi
                    };
                    _projectDbContext.CariTablo.Add(cari);
                }
            }
            await _projectDbContext.SaveChangesAsync();

            return Ok(currentResult);
        }

        [HttpPost("list-invoices")]
        public async Task<IActionResult> ListInvoice(string sessionId)
        {
            string apiUrl = "https://diademo.ws.dia.com.tr/api/v3/";

            var invoices = new
            {
                scf_fatura_listele = new
                {
                    session_id = sessionId, // zorunlu
                    firma_kodu = 34, // zorunlu
                    donem_kodu = 7,
                    filters = "",
                    sorts = "",
                    limit = 500,
                    offset = 0
                }
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(invoices), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(apiUrl + "scf/json", jsonContent);

            var responseContent = await response.Content.ReadAsStringAsync();

            var invoiceResult = JsonSerializer.Deserialize<Dictionary<string, object>>(responseContent);

            var invoiceList = JsonSerializer.Deserialize<List<FaturaTablo>>(invoiceResult["result"].ToString());

            foreach (var f in invoiceList)
            {
                if (!_projectDbContext.FaturaTablo.Any(f => f.FaturaSecretKey == f.FaturaSecretKey))
                {
                    var fatura = new FaturaTablo
                    {
                        FaturaId = f.FaturaId,
                        FaturaSecretKey = f.FaturaSecretKey,
                        FirmaAdi = f.FirmaAdi,
                        DovizTuru = f.DovizTuru,
                        CariVergiNo = f.CariVergiNo,
                        CariVergiDairesi = f.CariVergiDairesi,
                        CariFirma = f.CariFirma,
                        SevkAdresi = f.SevkAdresi,
                        ToplamMiktar = f.ToplamMiktar,
                        Toplam = f.Toplam,
                        Tarih = f.Tarih,
                        ToplamKdv = f.ToplamKdv,
                        DovizKuru = f.DovizKuru,
                        FisNo = f.FisNo,
                        ToplamDoviz = f.ToplamDoviz,
                        NetDoviz = f.NetDoviz,
                        BekleyenTutar = f.BekleyenTutar,
                        ToplamPara = f.ToplamPara,
                        ToplamParaDoviz = f.ToplamParaDoviz,
                        KalanTaksitTutar = f.KalanTaksitTutar,
                        CariId = f.CariId
                    };
                    _projectDbContext.FaturaTablo.Add(fatura);
                }
            }
            await _projectDbContext.SaveChangesAsync();

            return Ok(invoiceResult);
        }

        [HttpPost("get-invoice")]
        public async Task<IActionResult> GetInvoice(string sessionId)
        {
            string apiUrl = "https://diademo.ws.dia.com.tr/api/v3/";

            var current = new
            {
                scf_fatura_getir = new
                {
                    session_id = sessionId,
                    firma_kodu = 34,
                    donem_kodu = 0,
                    key = 180096
                }
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(current), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(apiUrl + "scf/json", jsonContent);

            var responseContent = await response.Content.ReadAsStringAsync();

            // json yanıtı liste haline dönüştürülüyor
            var getInvoiceResult = JsonSerializer.Deserialize<Dictionary<string, object>>(responseContent);

            // tekrardan okunabilir hale getiriliyor
            var resultJson = JsonSerializer.Serialize(getInvoiceResult["result"]);

            // resultı faturaya deserialize ediyoruz
            var invoice = JsonSerializer.Deserialize<Fatura>(resultJson);

            if (!_projectDbContext.Fatura.Any(f => f.Key == invoice.Key))
            {
                var fatura = new Fatura
                {
                    Key = invoice.Key,
                    Tarih = invoice.Tarih,
                    Toplam = invoice.Toplam,
                    ToplamKdv = invoice.ToplamKdv,
                    CariKart = invoice.CariKart,
                    CariKartAdresi = invoice.CariKartAdresi
                };
                _projectDbContext.Fatura.Add(fatura);
            }

            if (!_projectDbContext.CariKart.Any(c => c.Key == invoice.CariKart.Key))
            {
                var cariKart = new CariKart
                {
                    Key = invoice.CariKart.Key,
                    Unvan = invoice.CariKart.Unvan,
                    VergiNumarasi = invoice.CariKart.VergiNumarasi
                };
                _projectDbContext.CariKart.Add(cariKart);
            }

            if (!_projectDbContext.CariKartAdresi.Any(c => c.Key == invoice.CariKartAdresi.Key))
            {
                var cariKartAdresi = new CariKartAdresi
                {
                    Key = invoice.CariKartAdresi.Key,
                    Adres1 = invoice.CariKartAdresi.Adres1,
                    Ilce = invoice.CariKartAdresi.Ilce,
                    Telefon = invoice.CariKartAdresi.Telefon
                };
                _projectDbContext.CariKartAdresi.Add(cariKartAdresi);
            }
            await _projectDbContext.SaveChangesAsync();

            return Ok(getInvoiceResult);
        }
    }
}