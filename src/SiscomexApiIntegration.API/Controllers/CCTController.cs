using Microsoft.AspNetCore.Mvc;
using SiscomexApiIntegration.Domain.Entity;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace SiscomexApiIntegration.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CCTController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public CCTController()
        {
            var cert = new X509Certificate2(@"C:\certificados\ecnpj.pfx", "senha_certificado");
            var handler = new HttpClientHandler();
            handler.ClientCertificates.Add(cert);
            _httpClient = new HttpClient(handler);
        }

        /// <summary>Consulta um CCT por ID.</summary>
        /// <remarks>TODO: Usado para consultar informações de Controle de Carga e Trânsito.</remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CCTResponse), 200)]
        public async Task<IActionResult> GetCCT(string id)
        {
            var response = await _httpClient.GetAsync($"https://api.siscomex.gov.br/pucomex/cct/{id}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<CCTResponse>(content);
            return Ok(result);
        }

        /// <summary>Cria um novo CCT.</summary>
        /// <remarks>TODO: Usado para registrar um novo controle de carga e trânsito.</remarks>
        [HttpPost]
        [ProducesResponseType(typeof(CCTResponse), 201)]
        public async Task<IActionResult> CreateCCT([FromBody] CCTRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://api.siscomex.gov.br/pucomex/cct", content);
            var result = await response.Content.ReadAsStringAsync();
            return Content(result, "application/json");
        }

        /// <summary>Atualiza um CCT existente.</summary>
        /// <remarks>TODO: Usado para atualizar dados de um controle de carga e trânsito.</remarks>
        [HttpPut]
        [ProducesResponseType(typeof(CCTResponse), 200)]
        public async Task<IActionResult> UpdateCCT([FromBody] CCTUpdateRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("https://api.siscomex.gov.br/pucomex/cct", content);
            var result = await response.Content.ReadAsStringAsync();
            return Content(result, "application/json");
        }

        /// <summary>Cancela um CCT existente.</summary>
        /// <remarks>TODO: Usado para cancelar um registro de controle de carga e trânsito.</remarks>
        [HttpDelete]
        [ProducesResponseType(typeof(CCTResponse), 200)]
        public async Task<IActionResult> DeleteCCT([FromBody] CCTDeleteRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.SendAsync(new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://api.siscomex.gov.br/pucomex/cct"),
                Content = content
            });
            var result = await response.Content.ReadAsStringAsync();
            return Content(result, "application/json");
        }
    }
}
