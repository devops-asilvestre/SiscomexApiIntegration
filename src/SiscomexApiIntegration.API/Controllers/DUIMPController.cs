using Microsoft.AspNetCore.Mvc;
using SiscomexApiIntegration.Domain.Entity;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace SiscomexApiIntegration.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DUIMPController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public DUIMPController()
        {
            var cert = new X509Certificate2(@"C:\certificados\ecnpj.pfx", "senha_certificado");
            var handler = new HttpClientHandler();
            handler.ClientCertificates.Add(cert);
            _httpClient = new HttpClient(handler);
        }

        /// <summary>
        /// Consulta uma DUIMP por ID.
        /// </summary>
        /// <remarks>TODO: Usado para consultar uma Declaração Única de Importação (DUIMP).</remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DUIMPResponse), 200)]
        public async Task<IActionResult> GetDUIMP(string id)
        {
            var response = await _httpClient.GetAsync($"https://api.siscomex.gov.br/pucomex/duimp/{id}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<DUIMPResponse>(content);
            return Ok(result);
        }

        /// <summary>
        /// Registra uma nova DUIMP.
        /// </summary>
        /// <remarks>TODO: Usado para criar uma nova declaração de importação.</remarks>
        [HttpPost]
        [ProducesResponseType(typeof(DUIMPResponse), 201)]
        public async Task<IActionResult> CreateDUIMP([FromBody] DUIMPRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://api.siscomex.gov.br/pucomex/duimp", content);
            var result = await response.Content.ReadAsStringAsync();
            return Content(result, "application/json");
        }

        /// <summary>
        /// Atualiza/retifica uma DUIMP existente.
        /// </summary>
        /// <remarks>TODO: Usado para retificar ou atualizar dados de uma DUIMP já registrada.</remarks>
        [HttpPut]
        [ProducesResponseType(typeof(DUIMPResponse), 200)]
        public async Task<IActionResult> UpdateDUIMP([FromBody] DUIMPUpdateRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("https://api.siscomex.gov.br/pucomex/duimp", content);
            var result = await response.Content.ReadAsStringAsync();
            return Content(result, "application/json");
        }

        /// <summary>
        /// Cancela uma DUIMP existente.
        /// </summary>
        /// <remarks>TODO: Usado para cancelar uma declaração de importação.</remarks>
        [HttpDelete]
        [ProducesResponseType(typeof(DUIMPResponse), 200)]
        public async Task<IActionResult> DeleteDUIMP([FromBody] DUIMPDeleteRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.SendAsync(new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://api.siscomex.gov.br/pucomex/duimp"),
                Content = content
            });
            var result = await response.Content.ReadAsStringAsync();
            return Content(result, "application/json");
        }
    }
}
