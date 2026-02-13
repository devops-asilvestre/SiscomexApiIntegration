namespace SiscomexApiIntegration.Domain.Entity
{
    // ============================
    // LPCO - Licenças, Permissões, Certificados e Outros
    // ============================
    public class LPCORequest
    {
        public string Tipo { get; set; }
        public string Ncm { get; set; }
        public string Descricao { get; set; }
        public decimal ValorEstimado { get; set; }
    }

    public class LPCOResponse
    {
        public string Id { get; set; }
        public string Tipo { get; set; }
        public string Ncm { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
    }

    public class LPCOUpdateRequest
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string Observacao { get; set; }
    }

    public class LPCODeleteRequest
    {
        public string Id { get; set; }
        public string Motivo { get; set; }
    }
}
