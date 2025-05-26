# 💸 API de Transferências de Saldo

Esta é uma API desenvolvida em **ASP.NET Core** com o objetivo de simular transferências de saldo entre usuários. O projeto foi criado com foco em práticas como separação de responsabilidades, uso de repositórios, unit of work e um padrão de retorno padronizado através da classe `OperationResult`.

## 🚀 Funcionalidades

- 📤 Transferência de saldo entre usuários
- 👤 Cadastro, edição, consulta e remoção de usuários
- 💰 Verificação de saldo antes da transferência
- 📄 Histórico de transferências por usuário
- ✅ Tratamento de erros e respostas padronizadas com `OperationResult`

## 🧱 Arquitetura

O projeto segue uma arquitetura em camadas, separando responsabilidades entre Controllers, Services, Repositories e Models.

### Camadas principais:

- **Controllers**: Responsáveis pelas requisições HTTP.
- **Services**: Contêm a lógica de negócio.
- **Repositories**: Abstraem o acesso ao banco de dados (Entity Framework Core).
- **Models**: Representam as entidades da aplicação.
- **Common**: Inclui a classe `OperationResult`, utilizada para padronizar os retornos de operação.

## 🛠 Tecnologias Utilizadas

- ASP.NET Core Web API
- Entity Framework Core
- MySQL
- C#
- Swagger

## 📦 Endpoints Principais

### Usuários

- `POST /api/user` - Registrar um novo usuário
- `GET /api/user/{id}` - Buscar usuário por ID
- `PUT /api/user/{id}` - Atualizar dados do usuário
- `DELETE /api/user/{id}` - Remover usuário

### Transferências

- `POST /api/transfer` - Realizar uma transferência
- `GET /api/transfer/{id}` - Buscar transferência por ID
- `GET /api/transfer/user/{userId}` - Listar transferências de um usuário

## ⚠️ Validações

- O usuário deve possuir saldo suficiente para realizar a transferência
- Não é possível transferir para usuários inexistentes
- Caso haja erro em qualquer operação, uma mensagem de erro padronizada é retornada via `OperationResult`
