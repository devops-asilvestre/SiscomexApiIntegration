using Microsoft.AspNetCore.Mvc;
using SiscomexApiIntegration.Domain.Entity;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace SiscomexApiIntegration.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class NotificacoesController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public NotificacoesController()
        {
            var cert = new X509Certificate2(@"C:\certificados\ecnpj.pfx", "senha_certificado");
            var handler = new HttpClientHandler();
            handler.ClientCertificates.Add(cert);
            _httpClient = new HttpClient(handler);
        }

        /// <summary>Consulta uma notificação por ID.</summary>
        /// <remarks>TODO: Usado para consultar notificações push de eventos do Siscomex.</remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(NotificacaoResponse), 200)]
        public async Task<IActionResult> GetNotificacao(string id)
        {
            var response = await _httpClient.GetAsync($"https://api.siscomex.gov.br/pucomex/notificacoes/{id}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<NotificacaoResponse>(content);
            return Ok(result);
        }

        /// <summary>Cria uma nova notificação.</summary>
        /// <remarks>TODO: Usado para registrar uma notificação de evento.</remarks>
        [HttpPost]
        [ProducesResponseType(typeof(NotificacaoResponse), 201)]
        public async Task<IActionResult> CreateNotificacao([FromBody] NotificacaoRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://api.siscomex.gov.br/pucomex/notificacoes", content);
            var result = await response.Content.ReadAsStringAsync();
            return Content(result, "application/json");
        }

        /// <summary>Atualiza uma notificação existente.</summary>
        /// <remarks>TODO: Usado para atualizar dados de uma notificação de evento.</remarks>
        [HttpPut]
        [ProducesResponseType(typeof(NotificacaoResponse), 200)]
        public async Task<IActionResult> UpdateNotificacao([FromBody] NotificacaoUpdateRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("https://api.siscomex.gov.br/pucomex/notificacoes", content);
            var result = await response.Content.ReadAsStringAsync();
            return Content(result, "application/json");
        }

        /// <summary>Cancela uma notificação existente.</summary>
        /// <remarks>TODO: Usado para cancelar uma notificação de evento.</remarks>
        [HttpDelete]
        [ProducesResponseType(typeof(NotificacaoResponse), 200)]
        public async Task<IActionResult> DeleteNotificacao([FromBody] NotificacaoDeleteRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.SendAsync(new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://api.siscomex.gov.br/pucomex/notificacoes"),
                Content = content
            });
            var result = await response.Content.ReadAsStringAsync();
            return Content(result, "application/json");
        }
    }
}
