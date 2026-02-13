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
# 📌 Módulos
## Declaração Única de Importação (DUIMP)
É um documento eletrônico criado pelo Governo Federal como parte do Novo Processo de Importação (NPI). Ela foi desenvolvida para simplificar, agilizar e integrar os trâmites de importação no Brasil.

📌 Principais características
* Substitui a antiga Declaração de Importação (DI) e a Declaração Simplificada de Importação (DSI).
* Centraliza em um único documento todas as informações necessárias:
    * Aduaneiras
    * Administrativas
    * Comerciais
    * Financeiras
    * Fiscais
    * Logísticas

Permite que o processo de importação seja iniciado antes da chegada da mercadoria, trazendo mais previsibilidade. Facilita a integração entre Receita Federal, órgãos anuentes e importadores.

📌 Benefícios
* Redução de custos logísticos e maior eficiência.
* Agilidade no desembaraço aduaneiro.
* Transparência e rastreabilidade das operações.
* Integração digital com outros sistemas governamentais e privados.

Em resumo, a DUIMP é o documento central do novo modelo de importação brasileiro, reunindo todas as informações em um só lugar e substituindo processos fragmentados anteriores.

---

## Licenças, Permissões, Certificados e Outros (LPCO) 
São um módulo do Portal Único Siscomex (PUCOMEX) que centraliza o tratamento administrativo de operações de comércio exterior.

📌 O que são
* Licenças → Autorizações formais exigidas para importar ou exportar determinados produtos (ex.: licença sanitária, ambiental).
* Permissões → Autorizações específicas concedidas por órgãos anuentes para operações que envolvem restrições legais ou normativas.
* Certificados → Documentos que comprovam conformidade com normas técnicas, sanitárias ou de qualidade (ex.: certificado fitossanitário, certificado de origem).
* Outros Documentos → Qualquer documento adicional exigido por legislação nacional, normas internacionais ou pelo país importador/exportador.

📌 Finalidade
* Garantir que produtos e operações atendam às exigências legais e regulatórias.
* Servir como canal único de relacionamento entre empresas e órgãos anuentes (como Anvisa, Ibama, MAPA, entre outros).
* Evitar retenções desnecessárias e assegurar a conformidade aduaneira.

📌 Exemplos práticos
* Importação de medicamentos → exige licença da Anvisa.
* Exportação de madeira → exige autorização do Ibama.
* Exportação de alimentos → exige certificado fitossanitário do MAPA.

Em resumo, o LPCO é o módulo que concentra todas as autorizações e certificações necessárias para que uma operação de comércio exterior seja legal e segura.

---
# Controle de Carga e Trânsito (CCT)

É um módulo do Portal Único Siscomex (PUCOMEX) que tem como objetivo registrar, acompanhar e monitorar a movimentação de cargas e o trânsito aduaneiro no Brasil. Ele faz parte do Novo Processo de Importação (NPI) e é essencial para garantir rastreabilidade e transparência na logística internacional.

📌 O que é o CCT
* Sistema eletrônico que centraliza informações sobre entrada, movimentação e saída de cargas.
* Permite que intervenientes (transportadoras, recintos alfandegados, importadores e exportadores) registrem e acompanhem o fluxo da carga.
* Substitui processos manuais e descentralizados, trazendo maior eficiência.

📌 Finalidade
* Rastreabilidade: acompanhar cada etapa da movimentação da carga.
* Segurança: evitar extravios e irregularidades.
* Integração: conecta Receita Federal, órgãos anuentes e operadores logísticos.
* Agilidade: reduz burocracia e tempo de desembaraço.

📌 Exemplos práticos
* Registro da chegada de um contêiner em recinto alfandegado.
* Acompanhamento do trânsito aduaneiro de mercadorias entre portos e aeroportos.
* Atualização do status de manifesto de carga por transportadoras.

---
## Notificações 
No Portal Único Siscomex (PUCOMEX) são um mecanismo de eventos push que informam mudanças de status nas operações de comércio exterior (como DUIMP, CCT e LPCO). Elas funcionam como webhooks: quando ocorre um evento relevante, o sistema envia automaticamente uma mensagem para um endpoint previamente cadastrado pelo importador ou exportador. 

📌 O que são
* Mensagens automáticas enviadas pelo PUCOMEX.
* Informam alterações de status em documentos e processos (ex.: DUIMP registrada, LPCO deferida, CCT atualizado).
* São entregues a todos os representantes vinculados ao mesmo CNPJ.

📌 Finalidade
* Automatizar comunicação entre o Siscomex e os sistemas das empresas.
* Evitar consultas manuais constantes à API.
* Garantir sincronização em tempo real dos processos de importação e exportação.

📌 Exemplos práticos
* Notificação de deferimento de uma licença LPCO.
* Alerta de chegada de carga registrada no CCT.
* Atualização de status de uma DUIMP.

---
## Certificado Digital

É um documento eletrônico que funciona como uma identidade virtual para pessoas físicas ou jurídicas. Ele garante autenticidade, integridade e confidencialidade em transações online, permitindo assinar documentos, acessar sistemas governamentais (como o e-CAC da Receita Federal) e validar informações de forma segura.

📌 Tipos principais
* e-CPF → para pessoas físicas.
* e-CNPJ → para empresas.
* NF-e → específico para emissão de notas fiscais eletrônicas.

📌 Como emitir
* Escolher uma Autoridade Certificadora (AC) credenciada pela ICP-Brasil (ex.: Serpro, Certisign, Valid, Soluti).
* Solicitar o certificado (e-CPF ou e-CNPJ) no site da AC escolhida.
* Agendar a validação presencial ou online → apresentar documentos (RG, CPF, contrato social da empresa, etc.).

📌Instalar o certificado → pode ser emitido em:
* Arquivo (A1): instalado no computador.
* Token ou cartão (A3): dispositivo físico com maior segurança.
* Utilizar em sistemas → Receita Federal, Siscomex, emissão de NF-e, assinaturas digitais.

📌 Benefícios
* Segurança jurídica nas transações digitais.
* Eliminação de papel e burocracia.
* Validade legal equivalente à assinatura manuscrita.

---
## 📌 Resumo

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
## Quem Somos?
* <a href="https://www.linkedin.com/company/protech-software/about/" target="_blank">Protech-Software</a>
* <a href="https://www.linkedin.com/in/alessandro-silvestre-devops" target="_blank">Desenvolvedor</a>
