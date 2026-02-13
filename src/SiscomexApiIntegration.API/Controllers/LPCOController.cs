using Microsoft.AspNetCore.Mvc;
using SiscomexApiIntegration.Domain.Entity;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace SiscomexApiIntegration.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LPCOController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public LPCOController()
        {
            var cert = new X509Certificate2(@"C:\certificados\ecnpj.pfx", "senha_certificado");
            var handler = new HttpClientHandler();
            handler.ClientCertificates.Add(cert);
            _httpClient = new HttpClient(handler);
        }

        /// <summary>Consulta um LPCO por ID.</summary>
        /// <remarks>TODO: Usado para consultar uma licença ou certificado.</remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LPCOResponse), 200)]
        public async Task<IActionResult> GetLPCO(string id)
        {
            var response = await _httpClient.GetAsync($"https://api.siscomex.gov.br/pucomex/lpco/{id}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<LPCOResponse>(content);
            return Ok(result);
        }

        /// <summary>Cria um novo LPCO.</summary>
        /// <remarks>TODO: Usado para registrar uma nova licença ou certificado.</remarks>
        [HttpPost]
        [ProducesResponseType(typeof(LPCOResponse), 201)]
        public async Task<IActionResult> CreateLPCO([FromBody] LPCORequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://api.siscomex.gov.br/pucomex/lpco", content);
            var result = await response.Content.ReadAsStringAsync();
            return Content(result, "application/json");
        }

        /// <summary>Atualiza um LPCO existente.</summary>
        /// <remarks>TODO: Usado para atualizar dados de uma licença ou certificado.</remarks>
        [HttpPut]
        [ProducesResponseType(typeof(LPCOResponse), 200)]
        public async Task<IActionResult> UpdateLPCO([FromBody] LPCOUpdateRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("https://api.siscomex.gov.br/pucomex/lpco", content);
            var result = await response.Content.ReadAsStringAsync();
            return Content(result, "application/json");
        }

        /// <summary>Cancela um LPCO existente.</summary>
        /// <remarks>TODO: Usado para cancelar uma licença ou certificado.</remarks>
        [HttpDelete]
        [ProducesResponseType(typeof(LPCOResponse), 200)]
        public async Task<IActionResult> DeleteLPCO([FromBody] LPCODeleteRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.SendAsync(new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://api.siscomex.gov.br/pucomex/lpco"),
                Content = content
            });
            var result = await response.Content.ReadAsStringAsync();
            return Content(result, "application/json");
        }
    }
}
