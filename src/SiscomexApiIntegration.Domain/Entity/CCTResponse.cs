using System;

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
