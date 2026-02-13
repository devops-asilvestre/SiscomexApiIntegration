# 📦 Siscomex API Integration

## 📋 Descrição do Projeto

**Siscomex API Integration** é uma solução corporativa em **ASP.NET Core (.NET 10)** que fornece uma integração RESTful padronizada com as APIs do **Portal Único Siscomex (PUCOMEX)**. Este projeto facilita a comunicação com os sistemas de comércio exterior brasileiro, permitindo consultas e gerenciamento eficiente de documentos relacionados à importação e exportação de mercadorias.

### 🎯 Objetivo Principal

Centralizar e padronizar a integração com as APIs do PUCOMEX através de uma arquitetura robusta, escalável e segura, oferecendo endpoints RESTful para operações críticas de:
- **LPCO**: Licenças, Permissões, Certificados e Outros
- **DUIMP**: Declaração Única de Importação
- **CCT**: Controle de Carga e Trânsito
- **Notificações**: Eventos push e acompanhamento de documentos

---

## 🏗️ Arquitetura do Projeto

O projeto segue a **Arquitetura em Camadas Hexagonal** (Layered + Hexagonal Architecture), com separação clara de responsabilidades:

```
SiscomexApiIntegration/
├── src/
│   ├── SiscomexApiIntegration.API
│   │   ├── Controllers/                    # Camada de Apresentação
│   │   │   ├── LPCOController.cs
│   │   │   ├── DUIMPController.cs
│   │   │   ├── CCTController.cs
│   │   │   └── NotificacoesController.cs
│   │   ├── Program.cs                      # Configuração da aplicação
│   │   ├── Properties/
│   │   └── SiscomexApiIntegration.API.csproj
│   │
│   ├── SiscomexApiIntegration.Domain       # Camada de Domínio
│   │   ├── Entity/                         # Entidades e DTOs
│   │   │   ├── LPCO.cs                     # LPCORequest, LPCOResponse, etc
│   │   │   ├── DUIMP.cs                    # DUIMPRequest, DUIMPResponse, etc
│   │   │   ├── CCT.cs                      # CCTRequest, CCTResponse, etc
│   │   │   └── Notificacoes.cs             # NotificacaoRequest, NotificacaoResponse, etc
│   │   └── Properties/
│   │
│   ├── SiscomexApiIntegration.Application  # Camada de Aplicação (future)
│   │   └── Services/
│   │
│   ├── SiscomexApiIntegration.Infrastructure # Camada de Infraestrutura (future)
│   │   ├── Data/
│   │   └── ExternalServices/
│   │
│   └── SiscomexApiIntegration.Contracts    # Contratos e Interfaces (future)
│
├── tests/
│   ├── SiscomexApiIntegration.UnitTests       # Testes Unitários
│   └── SiscomexApiIntegration.IntegrationTests # Testes de Integração
│
├── .github/
│   └── workflows/                          # Pipelines CI/CD
│
└── README.md                               # Este arquivo
```

### 📊 Camadas do Projeto

| Camada | Responsabilidade | Status |
|--------|-----------------|--------|
| **API** | Controladores HTTP, roteamento, validação de requisições | ✅ Implementado |
| **Domain** | Entidades de domínio, DTOs (Request/Response), regras de negócio | ✅ Implementado |
| **Application** | Lógica de negócio, orquestração de operações, services | 🔄 Em Desenvolvimento |
| **Infrastructure** | Acesso a dados, integração com APIs externas, HttpClient | 🔄 Parcialmente |
| **Contracts** | Interfaces e contratos públicos | ⏳ Planejado |

---
## 🚀 Principais Módulos

### 1. **LPCO Controller** - Licenças, Permissões, Certificados e Outros
**Endpoint Base:** `/api/lpco`

Gerencia Licenças, Permissões, Certificados e Outros documentos necessários para operações de comércio exterior.

#### Operações Disponíveis:
```http
GET    /api/lpco/{id}              Consulta um LPCO por ID
POST   /api/lpco                   Cria um novo LPCO
PUT    /api/lpco/{id}              Atualiza um LPCO existente
DELETE /api/lpco/{id}              Remove um LPCO
```

#### Entidades de Dados:

**LPCORequest** (Criação):
```csharp
{
  "tipo": "Licença de Importação",
  "ncm": "87032310",
  "descricao": "Automóvel com cilindrada acima de 3000cc",
  "valorEstimado": 50000.00
}
```

**LPCOResponse** (Leitura):
```csharp
{
  "id": "LPCO-2024-00001",
  "tipo": "Licença de Importação",
  "ncm": "87032310",
  "descricao": "Automóvel com cilindrada acima de 3000cc",
  "status": "Aprovado"
}
```

**O que é LPCO?**

São um módulo do Portal Único Siscomex (PUCOMEX) que centraliza o tratamento administrativo de operações de comércio exterior.

- **Licenças** → Autorizações formais exigidas para importar ou exportar determinados produtos (ex.: licença sanitária, ambiental).
- **Permissões** → Autorizações específicas concedidas por órgãos anuentes para operações que envolvem restrições legais ou normativas.
- **Certificados** → Documentos que comprovam conformidade com normas técnicas, sanitárias ou de qualidade (ex.: certificado fitossanitário, certificado de origem).
- **Outros Documentos** → Qualquer documento adicional exigido por legislação nacional, normas internacionais ou pelo país importador/exportador.

---

### 2. **DUIMP Controller** - Declaração Única de Importação
**Endpoint Base:** `/api/duimp`

Gerencia Declarações Únicas de Importação (DUIMP), documento fundamental para todas as operações de importação.

#### Operações Disponíveis:
```http
GET    /api/duimp/{id}             Consulta uma DUIMP por ID
POST   /api/duimp                  Cria uma nova DUIMP
PUT    /api/duimp/{id}             Atualiza uma DUIMP existente
DELETE /api/duimp/{id}             Remove uma DUIMP
```

#### Propriedades Principais:

| Campo | Tipo | Descrição |
|-------|------|-----------|
| `id` | String | Identificador único (ex: DUIMP-2024-00001) |
| `cnpjImportador` | String | CNPJ da empresa importadora (14 dígitos) |
| `ncm` | String | Código de Classificação Fiscal (8 dígitos) |
| `descricao` | String | Descrição comercial da mercadoria |
| `valorFOB` | Decimal | Valor free on board em USD |
| `paisOrigem` | String | País de origem da mercadoria |
| `dataEmbarque` | DateTime | Data do embarque |
| `situacao` | String | Status: Registrada, Em Processamento, Aprovada, Rejeitada |

**O que é DUIMP?**

É um documento eletrônico criado pelo Governo Federal como parte do Novo Processo de Importação (NPI). Ela foi desenvolvida para simplificar, agilizar e integrar os trâmites de importação no Brasil.

📌 Principais características:
- Substitui a antiga Declaração de Importação (DI) e a Declaração Simplificada de Importação (DSI).
- Centraliza em um único documento todas as informações necessárias:
  - Aduaneiras
  - Administrativas
  - Comerciais
  - Financeiras
  - Fiscais
  - Logísticas

---

### 3. **CCT Controller** - Controle de Carga e Trânsito
**Endpoint Base:** `/api/cct`

Gerencia documentos de Controle de Carga e Trânsito, essenciais para rastreamento logístico.

#### Operações Disponíveis:
```http
GET    /api/cct/{id}               Consulta um CCT por ID
POST   /api/cct                    Cria um novo registro de CCT
PUT    /api/cct/{id}               Atualiza um CCT existente
DELETE /api/cct/{id}               Remove um CCT
```

#### Propriedades Principais:

| Campo | Tipo | Descrição |
|-------|------|-----------|
| `id` | String | Identificador único do CCT |
| `manifesto` | String | Número do manifesto de carga |
| `transportadora` | String | Razão social da transportadora |
| `status` | String | Status: Registrado, Em Trânsito, Entregue, Retido |
| `dataRegistro` | DateTime | Data de registro do CCT |

**O que é CCT?**

É um módulo do Portal Único Siscomex (PUCOMEX) que tem como objetivo registrar, acompanhar e monitorar a movimentação de cargas e o trânsito aduaneiro no Brasil. Ele faz parte do Novo Processo de Importação (NPI) e é essencial para garantir rastreabilidade e transparência na logística internacional.

---

### 4. **Notificações Controller** - Eventos e Acompanhamento
**Endpoint Base:** `/api/notificacoes`

Gerencia eventos e notificações relacionadas aos documentos, permitindo acompanhamento em tempo real.

#### Operações Disponíveis:
```http
GET    /api/notificacoes/{id}      Consulta uma notificação por ID
POST   /api/notificacoes           Cria uma nova notificação
PUT    /api/notificacoes/{id}      Atualiza uma notificação
DELETE /api/notificacoes/{id}      Remove uma notificação
```

#### Tipos de Eventos:

| Evento | Descrição |
|--------|-----------|
| `documento_registrado` | Documento foi registrado no sistema |
| `documento_aprovado` | Documento foi aprovado |
| `documento_rejeitado` | Documento foi rejeitado |
| `pendencia_cadastro` | Há pendências de cadastro |
| `fiscalizacao_iniciada` | Fiscalização foi iniciada |
| `mercadoria_liberada` | Mercadoria foi liberada |

#### Propriedades Principais:

| Campo | Tipo | Descrição |
|-------|------|-----------|
| `id` | String | Identificador único da notificação |
| `evento` | String | Tipo do evento |
| `idDocumento` | String | ID do documento relacionado |
| `dataEvento` | DateTime | Data e hora do evento |
| `mensagem` | String | Descrição detalhada do evento |

**O que são Notificações?**

No Portal Único Siscomex (PUCOMEX) são um mecanismo de eventos push que informam mudanças de status nas operações de comércio exterior (como DUIMP, CCT e LPCO). Elas funcionam como webhooks: quando ocorre um evento relevante, o sistema envia automaticamente uma mensagem para um endpoint previamente cadastrado pelo importador ou exportador.

---
## 🔐 Segurança

### Autenticação e Autorização

O projeto implementa **múltiplas camadas de segurança**:

#### 1. **Certificado Digital X.509 (e-CNPJ)**

A integração com as APIs do PUCOMEX requer autenticação por certificado digital:

```csharp
var cert = new X509Certificate2(@"C:\certificados\ecnpj.pfx", "senha_certificado");
var handler = new HttpClientHandler();
handler.ClientCertificates.Add(cert);
_httpClient = new HttpClient(handler);
```

#### 2. **JWT Bearer Token**

A API também suporta autenticação JWT Bearer para aplicações cliente:

```csharp
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://seu-provedor-identidade";
        options.Audience = "sua-api";
    });
```

### ⚠️ Recomendações de Segurança

| Item | Status | Descrição |
|------|--------|-----------|
| 🔒 **Certificado Seguro** | ⚠️ Crítico | Armazenar em Azure Key Vault, não no código |
| 🔑 **Senhas** | ⚠️ Crítico | Usar variáveis de ambiente ou secrets manager |
| 🛡️ **HTTPS** | ✅ Implementado | Todas as requisições em HTTPS |
| 🔐 **CORS** | ⚠️ Revisar | Configurar apenas domínios confiáveis |
| 📝 **Logging** | ⏳ Recomendado | Implementar logging de auditoria |
| 🚫 **Rate Limiting** | ⏳ Recomendado | Prevenir abuso da API |

---

## 🛠️ Tecnologias Utilizadas

| Tecnologia | Versão | Propósito |
|-----------|--------|----------|
| **.NET** | 10.0 | Framework principal |
| **ASP.NET Core** | 10.0 | Web API framework |
| **C#** | 14.0 | Linguagem de programação |
| **Swagger/OpenAPI** | 10.1.0 | Documentação interativa |
| **Entity Framework Core** | 10.0.1 | ORM para acesso a dados |
| **JWT Bearer** | 10.0.1 | Autenticação JWT |
| **X.509 Certificates** | - | Certificado digital |
| **HttpClient** | - | Integração com APIs externas |

### Dependências Instaladas

```xml
<ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="10.0.1" />
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="10.0.3" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="10.0.1" />
    <PackageReference Include="Microsoft.OpenApi" Version="2.0.0" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="10.1.0" />
    <PackageReference Include="Swashbuckle.AspNetCore.SwaggerGen" Version="9.0.6" />
    <PackageReference Include="Swashbuckle.AspNetCore.SwaggerUI" Version="9.0.6" />
</ItemGroup>
```

---

## 📦 Instalação e Configuração

### Pré-requisitos

- ✅ **.NET 10 SDK** instalado ([Download](https://dotnet.microsoft.com/download/dotnet/10.0))
- ✅ **Git** para versionamento
- ✅ **Certificado Digital (e-CNPJ)** em formato PFX
- ✅ **Visual Studio 2022** ou **VS Code** (recomendado)
- ✅ **Acesso à API do PUCOMEX**

### Passos de Instalação

#### 1. Clonar o Repositório

```bash
git clone https://github.com/devops-asilvestre/SiscomexApiIntegration.git
cd SiscomexApiIntegration
```

#### 2. Restaurar Dependências

```bash
dotnet restore
```

#### 3. Configurar Certificado Digital

**Windows:**
```bash
# Criar diretório para certificados
mkdir C:\certificados

# Copiar arquivo ecnpj.pfx para o diretório
copy seu_certificado.pfx C:\certificados\ecnpj.pfx
```

**Linux/macOS:**
```bash
mkdir -p ~/.siscomex/certificates
cp seu_certificado.pfx ~/.siscomex/certificates/ecnpj.pfx
```

#### 4. Compilar o Projeto

```bash
dotnet build
```

#### 5. Executar em Desenvolvimento

```bash
dotnet run --project src/SiscomexApiIntegration.API
```

A aplicação estará disponível em:
- API: `https://localhost:5001`
- Swagger: `https://localhost:5001/swagger`

#### 6. Acessar Documentação

Abra o navegador e acesse:
```
https://localhost:5001/swagger/index.html
```

---

## 📚 Exemplos de Uso

### 1. Consultar um LPCO

```bash
curl -X GET "https://localhost:5001/api/lpco/LPCO-2024-00001" \
  -H "Authorization: Bearer seu_token_jwt" \
  -H "Content-Type: application/json"
```

**Resposta (200 OK):**
```json
{
  "id": "LPCO-2024-00001",
  "tipo": "Licença de Importação",
  "ncm": "87032310",
  "descricao": "Automóvel com cilindrada acima de 3000cc",
  "status": "Aprovado"
}
```

### 2. Criar uma Nova DUIMP

```bash
curl -X POST "https://localhost:5001/api/duimp" \
  -H "Authorization: Bearer seu_token_jwt" \
  -H "Content-Type: application/json" \
  -d '{
    "cnpjImportador": "12345678000100",
    "ncm": "87032310",
    "descricao": "Automóvel com cilindrada acima de 3000cc",
    "valorFOB": 50000.00,
    "paisOrigem": "Alemanha",
    "dataEmbarque": "2024-12-15T00:00:00Z"
  }'
```

**Resposta (201 Created):**
```json
{
  "id": "DUIMP-2024-00001",
  "cnpjImportador": "12345678000100",
  "ncm": "87032310",
  "descricao": "Automóvel com cilindrada acima de 3000cc",
  "valorFOB": 50000.00,
  "paisOrigem": "Alemanha",
  "situacao": "Registrada"
}
```

### 3. Atualizar um CCT

```bash
curl -X PUT "https://localhost:5001/api/cct/CCT-2024-00001" \
  -H "Authorization: Bearer seu_token_jwt" \
  -H "Content-Type: application/json" \
  -d '{
    "status": "Entregue"
  }'
```

### 4. Listar Notificações

```bash
curl -X GET "https://localhost:5001/api/notificacoes?evento=documento_aprovado" \
  -H "Authorization: Bearer seu_token_jwt" \
  -H "Content-Type: application/json"
```

---

## 🧪 Testes

### Executar Todos os Testes

```bash
dotnet test
```

### Testes Unitários

```bash
dotnet test tests/SiscomexApiIntegration.UnitTests
```

### Testes de Integração

```bash
dotnet test tests/SiscomexApiIntegration.IntegrationTests
```

### Testes com Cobertura

```bash
dotnet test /p:CollectCoverage=true /p:CoverageFormat=opencover
```

---

## 📖 Documentação da API

### Swagger UI

A documentação interativa está disponível em:

```
https://localhost:5001/swagger/index.html
```

### OpenAPI JSON

O arquivo OpenAPI completo pode ser obtido em:

```
https://localhost:5001/swagger/v1/swagger.json
```

---

## 🔄 CI/CD Pipeline

### GitHub Actions

Os workflows estão configurados em `.github/workflows/`:

### Processos Automáticos

- ✅ Build automático a cada commit
- ✅ Execução de testes unitários
- ✅ Execução de testes de integração
- ✅ Análise de qualidade de código
- ✅ Deploy automático (em branches selecionadas)

---

## 🤝 Contribuindo

### Guia de Contribuição

1. **Fork** o repositório
2. **Crie uma branch** para sua feature (`git checkout -b feature/AmazingFeature`)
3. **Commit** suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. **Push** para a branch (`git push origin feature/AmazingFeature`)
5. **Abra um Pull Request**

### Padrões de Código

- Use **camelCase** para variáveis e **PascalCase** para classes
- Siga as [Convenções de Codificação C#](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Mantenha métodos pequenos e focados
- Adicione comentários XML para métodos públicos
- Implemente testes para novas funcionalidades

---

## 📋 Roadmap do Projeto

### Fase 1: MVP (Atual) ✅
- [x] Estrutura básica da API
- [x] Controladores para LPCO, DUIMP, CCT, Notificações
- [x] Documentação com Swagger
- [x] Autenticação JWT básica

### Fase 2: Camadas Completas 🔄
- [ ] Implementar camada Application com serviços de negócio
- [ ] Implementar camada Infrastructure com Entity Framework Core
- [ ] Configurar banco de dados (SQL Server / PostgreSQL)
- [ ] Implementar repositório pattern

### Fase 3: Recursos Avançados ⏳
- [ ] Cache distribuído (Redis)
- [ ] Message Queue (RabbitMQ)
- [ ] Logging centralizado (ELK Stack)
- [ ] Rate limiting e throttling
- [ ] Versionamento de API

### Fase 4: DevOps 🚀
- [ ] Containerização (Docker)
- [ ] Orquestração (Kubernetes)
- [ ] CI/CD avançado (GitHub Actions)
- [ ] Monitoramento (Prometheus / Grafana)
- [ ] Testes de carga

---

## 📞 Contato e Suporte

| Item | Informação |
|------|-----------|
| **Desenvolvedor Principal** | [Alessandro](https://www.linkedin.com/in/alessandro-silvestre-devops/) |
| **Email** | devops.asilvestre@gmail.com.br |
| **Protech-Software** | [protech-software](https://www.linkedin.com/company/protech-software/) |
| **Repositório** | https://github.com/devops-asilvestre/SiscomexApiIntegration |
| **Issues** | [GitHub Issues](https://github.com/devops-asilvestre/SiscomexApiIntegration/issues) |

---

## 📌 Informações de Versão

| Propriedade | Valor |
|------------|--------|
| **Versão Atual** | v1.0.0 |
| **Status** | Em Desenvolvimento ⚙️ |
| **.NET Target** | .NET 10 |
| **C# Version** | 14.0 |
| **Data de Criação** | 2024 |
| **Última Atualização** | 2024-12-15 |

---

## ⚡ Notas Importantes

### 🔐 Segurança
1. **Nunca commitar** credenciais, senhas ou certificados no repositório
2. Usar **variáveis de ambiente** ou **Azure Key Vault** para secrets
3. **Revisar regularmente** as permissões de acesso
4. Manter dependências **atualizadas** para patches de segurança

### 📝 Certificado Digital
1. Este projeto **requer um certificado digital válido** (e-CNPJ)
2. O certificado deve estar em **formato PFX**
3. Armazenar em local **seguro e protegido**
4. Implementar **rotação de certificados** quando necessário

### 🌐 Endpoints Reais
1. Atualmente conectado aos **endpoints reais** do PUCOMEX
2. Em desenvolvimento, considere usar **mocks** para testes
3. Validar acesso **antes de usar em produção**

### 📋 Compliance
1. Certifique-se de estar em **conformidade** com regulamentações brasileiras
2. Manter **auditoria** de todas as operações de comércio exterior
3. Respeitar **prazos legais** e **obrigações fiscais**
4. Proteger **dados sensíveis** conforme LGPD

---

## 🔗 Links Úteis

- 📚 [Documentação .NET 10](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-10)
- 🔐 [PUCOMEX - Portal Único Siscomex](https://pucomex.gov.br)
- 📖 [Swagger/OpenAPI](https://swagger.io/)
- 🧪 [xUnit.net Testing Framework](https://xunit.net/)
- 🐳 [Docker Documentation](https://docs.docker.com/)
- ☸️ [Kubernetes Documentation](https://kubernetes.io/docs/)

---

## 📞 FAQ - Perguntas Frequentes

### P: Como obtenho um certificado e-CNPJ?
**R:** Solicite à sua empresa registrada junto à Receita Federal. O certificado é emitido por Autoridades Certificadoras credenciadas (AC).

### P: Qual é o custo de usar a API do PUCOMEX?
**R:** O acesso à API do PUCOMEX é gratuito para operadores de comércio exterior registrados.

### P: Posso usar esta API em produção?
**R:** Sim, desde que tenha cumprido todas as configurações de segurança recomendadas.

### P: Como faço para contribuir com melhorias?
**R:** Envie um Pull Request ou abra uma Issue no GitHub.

---

**Desenvolvido com ❤️ pela equipe de DevOps**

**Última atualização:** 15 de dezembro de 2024
