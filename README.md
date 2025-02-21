# FornecedoresPlayMove

## 📌 Buenas Senhoras e Senhores! Tudo certo? Segue a visão geral do projeto:
A FornecedoresPlayMove é uma Web API desenvolvida em C# com ASP.NET Core para o gerenciamento de fornecedores de uma empresa!

## 🚀 Tecnologias Utilizadas
- C#
- ASP.NET Core
- Entity Framework Core
- SQL Server
- Swagger (Swashbuckle)

## 🛠 Configuração do Ambiente
1. Clonar este repositório:
   ```sh
   git clone https://github.com/ZDjow/FornecedoresPlayMove.git
   ```
2. Navegar até o diretório do projeto:
   ```sh
   cd FornecedoresPlayMove
   ```
3. Configurar a string de conexão com o SQL Server no arquivo `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "conexaoFornecedoresDB": "Server=localhost\\SQLEXPRESS;Database=FornecedoresDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
   }
   ```
4. Executar as migrações do banco de dados (deixei os dados da minha migração no projeto para vocês examinarem como foi criada e alterada a entidade):
   ```sh
   dotnet ef database update
   ```
5. Executar a API:
   ```sh
   dotnet run
   ```

## 📌 Endpoints da API

### 🔹 Listar todos os fornecedores
**GET** `/api/fornecedores`

### 🔹 Buscar um fornecedor por ID
**GET** `/api/fornecedores/{id}`

### 🔹 Criar um novo fornecedor
**POST** `/api/fornecedores`
- Exemplo de corpo da requisição:
```json
{
  "nome": "Fornecedor X",
  "email": "fornecedorx@email.com"
}
```

### 🔹 Atualizar um fornecedor existente
**PUT** `/api/fornecedores/{id}`

### 🔹 Remover um fornecedor
**DELETE** `/api/fornecedores/{id}`

## 📖 Documentação da API
Via Swagger. Depois de iniciar o projeto, acessar:
```
http://localhost:<porta>/swagger/index.html
```

## 👨‍💻 Autor
**ZDjow**
- GitHub: [@ZDjow](https://github.com/ZDjow)
