namespace SiscomexApiIntegration.Domain.Entity
{
    // ============================
    // DUIMP - Declaração Única de Importação
    // ============================

    public class DUIMPRequest
    {
        public string CnpjImportador { get; set; }
        public string Ncm { get; set; }
        public string Descricao { get; set; }
        public decimal ValorFOB { get; set; }
        public string PaisOrigem { get; set; }
        public DateTime DataEmbarque { get; set; }
    }

    public class DUIMPResponse
    {
        public string Id { get; set; }
        public string CnpjImportador { get; set; }
        public string Ncm { get; set; }
        public string Descricao { get; set; }
        public decimal ValorFOB { get; set; }
        public string PaisOrigem { get; set; }
        public string Situacao { get; set; }
        public DateTime DataRegistro { get; set; }
    }

    public class DUIMPUpdateRequest
    {
        public string Id { get; set; }
        public string Situacao { get; set; }
        public string Observacao { get; set; }
        public decimal? ValorFOB { get; set; }
    }

    public class DUIMPDeleteRequest
    {
        public string Id { get; set; }
        public string Motivo { get; set; }
    }
}
