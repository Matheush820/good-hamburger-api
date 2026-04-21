#  Good Hamburger API

API REST desenvolvida em C# com ASP.NET Core para gerenciamento de pedidos de uma lanchonete fictícia chamada Good Hamburger.

O sistema permite criar, listar, consultar, atualizar e remover pedidos, além de aplicar regras de negócio para cálculo automático de desconto e total final.

---

##  Tecnologias utilizadas

- C# (.NET 9 / ASP.NET Core)
- Entity Framework Core
- SQLite
- Swagger (OpenAPI)
- Blazor (Frontend)
- HttpClient
- Git / GitHub

---

##  Funcionalidades

### Pedidos
- Criar pedido
- Listar todos os pedidos
- Buscar pedido por ID
- Atualizar pedido
- Remover pedido

### Cardápio
- Sanduíches:
  - X Burger — R$ 5,00
  - X Egg — R$ 4,50
  - X Bacon — R$ 7,00
- Acompanhamentos:
  - Batata frita — R$ 2,00
  - Refrigerante — R$ 2,50

---

## Regras de negócio

- Sanduíche + batata + refrigerante → 20% de desconto
- Sanduíche + refrigerante → 15% de desconto
- Sanduíche + batata → 10% de desconto
- Cada pedido pode conter apenas:
  - 1 sanduíche
  - 1 batata
  - 1 refrigerante
- Itens duplicados retornam erro de validação

O cálculo de subtotal, desconto e total é feito no Service da aplicação.

---

##  Arquitetura

O projeto segue uma arquitetura simples em camadas:

- Controllers → expõem endpoints da API
- Services → regras de negócio e cálculos
- DTOs → entrada de dados
- Models → entidades do banco
- Data → contexto do Entity Framework

Essa separação foi feita para manter o código organizado e facilitar manutenção.

---

##  Endpoints

### Pedidos

- POST `/api/pedidos`
- GET `/api/pedidos`
- GET `/api/pedidos/{id}`
- PUT `/api/pedidos/{id}`
- DELETE `/api/pedidos/{id}`

---

##  Exemplo de requisição

```json
{
  "sanduiche": "X Burger",
  "temBatata": true,
  "temRefrigerante": true
}

Como executar o projeto
Backend (API)
cd GoodHamburgerAPI
dotnet restore
dotnet run

A API será executada em:
http://localhost:seulocalhost

Swagger disponível em:
http://localhost:seulocalhost/swagger

Frontend (Blazor)
cd GoodHamburgerFront
dotnet restore
dotnet run
Testes

Foram considerados testes automatizados para validar:

Regras de desconto
Validação de itens duplicados
Cálculo final do pedido

 Decisões de arquitetura
Regras de negócio centralizadas em Service
Uso de DTO para separar API do domínio
Entity Framework Core com SQLite por simplicidade
Swagger para facilitar testes da API
Separação clara entre backend e frontend

 O que não foi implementado
Autenticação e login de usuários
Banco de dados em produção (PostgreSQL/MySQL)
Deploy em nuvem
Testes automatizados completos
Frontend avançado (foi mantido simples para integração)
 Autor

Projeto desenvolvido como desafio técnico para demonstrar habilidades em:

ASP.NET Core Web API
Entity Framework Core
Arquitetura backend
Integração com frontend (Blazor)
Regras de negócio em backend

---


Só falar.
