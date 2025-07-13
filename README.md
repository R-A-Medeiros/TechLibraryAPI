# 📚 TechLibraryAPI

O **TechLibraryAPI** é um projeto de API RESTful desenvolvido com **.NET 8** e estruturado em uma arquitetura limpa e modular, separando responsabilidades entre camadas de domínio, aplicação, infraestrutura e apresentação. 

Seu objetivo é fornecer uma base robusta e escalável para o gerenciamento de uma biblioteca técnica, com foco em boas práticas como **injeção de dependência**, **validação de dados**, **tratamento centralizado de exceções**, e uso de padrões como **Repository** e **Unit of Work**.

Além disso, a API oferece endpoints organizados para operações CRUD de autores e livros, com mapeamento DTO-entity via **AutoMapper**, e documentação automática com **Swagger**.

O projeto pode servir como ponto de partida para aplicações reais ou como referência para estudos de arquitetura e boas práticas em APIs REST com C#.


## 🏗️ Arquitetura

O projeto segue uma arquitetura em camadas:
```
FCxLabs.TechLibraryAPI
├── .github/           → Workflows e configurações de CI/CD
├── build/             → Scripts de build ou configurações de automação
├── eng/               → Scripts de engenharia, configs ou ferramentas auxiliares
├── src/               → Código-fonte da aplicação
│   ├── core/
│   │   ├── Application  → Casos de uso (Use Cases), interfaces e validações
│   │   ├── Domain       → Entidades de negócio e contratos (interfaces) de repositórios
│   │   └── Exception    → Exceções personalizadas
│   ├── infrastructure/  → Implementações de persistência e serviços externos
│   └── presentation/
│       └── API/         → Controllers, filtros, middlewares e injeção de dependências
├── tests/             → Projetos de teste unitário e integração
├── .gitignore         → Arquivo de exclusões do Git
└── FCxLabs.TechLibraryAPI.sln → Solução principal da aplicação
```

## 📂 Principais Endpoints

Método	Endpoint	Descrição

- GET	/api/author	Lista autores
- GET	/api/author/{id}	Detalha um autor
- POST	/api/author	Cadastra novo autor
- PUT	/api/author/{id}	Atualiza autor
- DELETE	/api/author/{id}	Remove autor
- GET	/api/book	Lista livros
- GET	/api/book/{id}	Detalha um livro
- POST	/api/book	Cadastra novo livro
- PUT	/api/book/{id}	Atualiza livro
- DELETE	/api/book/{id}	Remove livro

  
## 🚀 Funcionalidades

- CRUD de **Autores** e **Livros**
- Validação com **FluentValidation**
- Mapeamento com **AutoMapper**
- Persistência com **Entity Framework Core**
- Documentação com **Swagger**
- Filtro de exceções global com `ExceptionFilter`
- Separação clara por **Use Cases**


## 🔮 Atualizações Futuras

O projeto está em constante evolução. Algumas melhorias planejadas incluem:

- 🧪 **Testes Unitários para registro de usuários**
 
   Implementação de testes automatizados para verificar o correto funcionamento do processo de registro, incluindo cenários de sucesso, validação de campos obrigatórios (e-mail e senha), tratamento de dados         inválidos e verificação de duplicidade de e-mail. Isso garantirá maior confiabilidade e robustez à funcionalidade de cadastro.

- 🧑‍💻 **Controle de Acesso por Perfil (Authorization)**  
  Adição de níveis de permissão para acesso diferenciado de acordo com o papel do usuário (ex: administrador, leitor, editor).

- 📄 **Paginação e Filtros Avançados**  
  Suporte à paginação de resultados e filtros combinados (por título, autor, categoria etc.) nos endpoints de listagem.


## ⚙️ Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)

## ▶️ Executando o Projeto

1. Clone o repositório:

```bash
git clone https://github.com/R-A-Medeiros/TechLibraryAPI.git
cd TechLibraryAPI/src/presentation/FCxLabs.TechLibraryAPI.API
```
2. Restaure os pacotes:
```bash
dotnet restore
```
3. Execute a aplicação:
```bash
dotnet run
```
4. Acesse no navegador:
```bash
https://localhost:5001/swagger
```
## 🧪 Testes

```bash
dotnet test
```

## 📘 Contribuindo
Contribuições são bem-vindas!
Para contribuir:

Faça um fork

Crie uma branch: git checkout -b feature/NovaFuncionalidade

Commit: git commit -m 'Descrição'

Push: git push origin feature/NovaFuncionalidade

Abra um Pull Request.

