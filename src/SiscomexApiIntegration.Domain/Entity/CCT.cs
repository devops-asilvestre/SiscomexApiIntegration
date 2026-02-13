namespace SiscomexApiIntegration.Domain.Entity
{
    // ============================
    // CCT - Controle de Carga e Trânsito
    // ============================

    public class CCTRequest
    {
        public string Manifesto { get; set; }
        public string Transportadora { get; set; }
        public string Status { get; set; }
        public DateTime DataRegistro { get; set; }
    }

    public class CCTResponse
    {
        public string Id { get; set; }
        public string Manifesto { get; set; }
        public string Transportadora { get; set; }
        public string Status { get; set; }
        public DateTime DataRegistro { get; set; }
    }

    public class CCTUpdateRequest
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string Observacao { get; set; }
    }

    public class CCTDeleteRequest
    {
        public string Id { get; set; }
        public string Motivo { get; set; }
    }
}
