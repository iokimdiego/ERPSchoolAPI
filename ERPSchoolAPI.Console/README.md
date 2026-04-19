# ERPSchoolAPI

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-Console-239120?logo=csharp&logoColor=white)
![Status](https://img.shields.io/badge/status-em%20desenvolvimento-orange)
![License](https://img.shields.io/badge/license-MIT-blue)
![Ultimo commit](https://img.shields.io/github/last-commit/iokimdiego/ERPSchoolAPI?label=ultimo%20commit)
![Versao](https://img.shields.io/badge/versao-0.1.0-blue)

Projeto em C# com .NET, atualmente em formato de aplicacao de console, que simula o fluxo inicial de um ERP escolar focado no cadastro e manutencao de dados de aluno.

## Objetivo

Consolidar fundamentos de backend com C#/.NET por meio da evolucao incremental do sistema, iniciando com regras de negocio no console e evoluindo para uma API REST.

## Tecnologias

- C#
- .NET 10 (Console Application)
- Git e GitHub

## Funcionalidades implementadas

- Cadastro inicial de aluno (nome e idade)
- Validacao de entrada para idade com `int.TryParse`
- Bloqueio de idade negativa
- Menu interativo com opcoes para:
  - Visualizar dados do aluno
  - Atualizar nome
  - Atualizar idade (com validacao)
  - Encerrar o sistema

## Estrutura atual

```text
ERPSchoolAPI/
|- Aluno.cs
|- Program.cs
|- ERPSchoolAPI.csproj
`- README.md
```

## Como executar

1. Clone o repositorio:

```bash
git clone https://github.com/iokimdiego/ERPSchoolAPI.git
```

2. Acesse a pasta do projeto:

```bash
cd ERPSchoolAPI
```

3. Execute a aplicacao:

```bash
dotnet run
```

## Exemplo de uso no terminal

```text
=== SISTEMA ERP SCHOOL API ===
Digite seu nome: Diego
Digite sua idade: 25

=== MENU PRINCIPAL ===
1. Ver dados
2. Atualizar nome
3. Atualizar idade
0. Sair
Escolha uma opcao: 1

Nome: Diego
Idade: 25

=== MENU PRINCIPAL ===
1. Ver dados
2. Atualizar nome
3. Atualizar idade
0. Sair
Escolha uma opcao: 0
Saindo do sistema. Ate logo!
```

## Proximas evolucoes

- [ ] Migrar para ASP.NET Core Web API
- [ ] Implementar CRUD de alunos
- [ ] Implementar CRUD de cursos
- [ ] Integrar com banco de dados SQL Server
- [ ] Aplicar principios de arquitetura limpa
- [ ] Adicionar autenticacao e autorizacao com JWT
- [ ] Publicar documentacao com Swagger

## Contato

- LinkedIn: https://www.linkedin.com/in/iokimdiego
- Portfolio: https://www.iokimdiego.dev.br

## Licenca

Projeto sob licenca MIT.
