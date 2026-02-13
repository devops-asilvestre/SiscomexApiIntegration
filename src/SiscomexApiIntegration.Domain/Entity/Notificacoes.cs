namespace SiscomexApiIntegration.Domain.Entity
{
    // ============================
    // Notificações - Eventos Push
    // ============================

    public class NotificacaoRequest
    {
        public string Evento { get; set; }
        public string IdDocumento { get; set; }
        public DateTime DataEvento { get; set; }
        public string Mensagem { get; set; }
    }

    public class NotificacaoResponse
    {
        public string Id { get; set; }
        public string Evento { get; set; }
        public string IdDocumento { get; set; }
        public DateTime DataEvento { get; set; }
        public string Mensagem { get; set; }
    }

    public class NotificacaoUpdateRequest
    {
        public string Id { get; set; }
        public string Mensagem { get; set; }
    }

    public class NotificacaoDeleteRequest
    {
        public string Id { get; set; }
        public string Motivo { get; set; }
    }
}
