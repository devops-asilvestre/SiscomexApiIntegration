Aqui está um **README.md detalhado** para o seu projeto **SiscomexApiIntegration**. Ele explica o propósito, arquitetura, módulos (DUIMP, CCT, LPCO, Notificações), eventos e a model.  

---

# SiscomexApiIntegration

## 📌 Visão Geral
SiscomexApiIntegration é uma solução desenvolvida em **.NET 9** baseada em **Clean Architecture** e princípios **SOLID**, que integra sistemas corporativos com o **Portal Único Siscomex (PUCOMEX)**.  
O projeto fornece **CRUD completo** para os módulos **DUIMP, CCT, LPCO e Notificações**, utilizando **certificado digital (e-CNPJ)** para autenticação mTLS.  
Inclui documentação interativa via **Swagger/OpenAPI**, além de **testes unitários e de integração**.

---

## 🏗️ Arquitetura
- **Domain** → Entidades e regras de negócio puras.  
- **Application** → Casos de uso, validações e orquestração.  
- **Infrastructure** → Persistência (EF Core), HttpClient com certificado digital.  
- **Contracts** → DTOs (Request/Response) e contratos de comunicação.  
- **API** → Controllers RESTful (DUIMP, CCT, LPCO, Notificações) + Swagger/OpenAPI.  

---
A Declaração Única de Importação (DUIMP) é um documento eletrônico criado pelo Governo Federal como parte do Novo Processo de Importação (NPI). Ela foi desenvolvida para simplificar, agilizar e integrar os trâmites de importação no Brasil.

📌 Principais características
* Substitui a antiga Declaração de Importação (DI) e a Declaração Simplificada de Importação (DSI).
* Centraliza em um único documento todas as informações necessárias:
 * Aduaneiras
 * Administrativas
 * Comerciais
 * Financeiras
 * Fiscais
 * Logísticas

Permite que o processo de importação seja iniciado antes da chegada da mercadoria, trazendo mais previsibilidade.

Facilita a integração entre Receita Federal, órgãos anuentes e importadores.

📌 Benefícios
* Redução de custos logísticos e maior eficiência.
* Agilidade no desembaraço aduaneiro.
* Transparência e rastreabilidade das operações.
* Integração digital com outros sistemas governamentais e privados.

Em resumo, a DUIMP é o documento central do novo modelo de importação brasileiro, reunindo todas as informações em um só lugar e substituindo processos fragmentados anteriores.
---

## 📌 Módulos

### DUIMP (Declaração Única de Importação)
- Documento eletrônico que substitui a antiga DI.  
- Contém informações sobre mercadorias importadas, NCM, valor FOB, país de origem.  
- Endpoints: `GET /duimp/{id}`, `POST /duimp`, `PUT /duimp`, `DELETE /duimp`.

### CCT (Controle de Carga e Trânsito)
- Registra e acompanha movimentação de cargas e trânsito aduaneiro.  
- Permite rastrear manifesto, transportadora e status da carga.  
- Endpoints: `GET /cct/{id}`, `POST /cct`, `PUT /cct`, `DELETE /cct`.

### LPCO (Licenças, Permissões, Certificados e Outros)
- Gerencia autorizações necessárias para importação/exportação.  
- Inclui licenças sanitárias, ambientais e certificações diversas.  
- Endpoints: `GET /lpco/{id}`, `POST /lpco`, `PUT /lpco`, `DELETE /lpco`.

### Notificações
- Eventos push enviados pelo PUCOMEX.  
- Informam mudanças de status em DUIMP, CCT ou LPCO.  
- Endpoints: `GET /notificacoes/{id}`, `POST /notificacoes`, `PUT /notificacoes`, `DELETE /notificacoes`.

---

## 📌 Eventos
- Cada módulo gera **eventos** que podem ser consumidos via notificações.  
- Exemplo: DUIMP registrada, LPCO deferida, CCT atualizado.  
- Esses eventos são capturados e tratados pela aplicação para manter sincronização com o Siscomex.

---

## 📌 Models

### DUIMP
```csharp
public class DUIMPRequest {
    public string CnpjImportador { get; set; }
    public string Ncm { get; set; }
    public string Descricao { get; set; }
    public decimal ValorFOB { get; set; }
    public string PaisOrigem { get; set; }
    public DateTime DataEmbarque { get; set; }
}
```

### CCT
```csharp
public class CCTRequest {
    public string Manifesto { get; set; }
    public string Transportadora { get; set; }
    public string Status { get; set; }
    public DateTime DataRegistro { get; set; }
}
```

### LPCO
```csharp
public class LPCORequest {
    public string Tipo { get; set; }
    public string Ncm { get; set; }
    public string Descricao { get; set; }
    public decimal ValorEstimado { get; set; }
}
```

### Notificações
```csharp
public class NotificacaoRequest {
    public string Evento { get; set; }
    public string IdDocumento { get; set; }
    public DateTime DataEvento { get; set; }
    public string Mensagem { get; set; }
}
```

---

## 🚀 Recursos
- Autenticação via **certificado digital (e-CNPJ)**.  
- Documentação interativa com **Swagger/OpenAPI**.  
- **Testes unitários e de integração** para garantir qualidade.  
- Estrutura modular e escalável.  

---

