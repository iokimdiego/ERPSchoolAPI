using System.Linq;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Text;

List<Aluno> alunos = new List<Aluno>(); // Cria uma lista para armazenar os objetos do tipo Aluno. Essa lista pode ser usada para gerenciar múltiplos alunos, permitindo adicionar, remover ou listar os alunos cadastrados no sistema.

ExibirTitulo();
ExibirMenu(alunos);

// ===================MÉTODOS===================

string RemoverAcentos(string texto)
{
    var normalizedString = texto.Normalize(NormalizationForm.FormD);
    var stringBuilder = new StringBuilder();

    foreach (var c in normalizedString)
    {
        if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
        {
            stringBuilder.Append(c);
        }
    }

    return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
}

void ExibirTitulo()
{
    Console.WriteLine("=== SISTEMA ERP ESCOLA ===");
}


void CadastrarAluno(List<Aluno> alunos)
{
    while (true)
    {
        Aluno aluno = new Aluno();

        Console.Write("Digite o nome do aluno ou 0 para voltar: ");
        aluno.Nome = Console.ReadLine() ?? string.Empty;

        if (aluno.Nome == "0")
        {
            Console.WriteLine("Operação de cadastro cancelada.");
            return;
        }

        bool idadeValida = false;

        while (!idadeValida)
        {
            Console.Write("Digite a idade do aluno: ");
            string idadeInput = Console.ReadLine() ?? "";

            if (int.TryParse(idadeInput, out int idade))
            {
                aluno.Idade = idade;
                idadeValida = true;
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
        }

        alunos.Add(aluno);
        Console.WriteLine($"Aluno {aluno.Nome} cadastrado com sucesso!");

        Console.Write("Deseja cadastrar outro aluno? (S/N): ");
        string resposta = Console.ReadLine()?.ToUpper() ?? "";

        if (resposta != "S")
            break;
    }
}

void ListarAlunos(List<Aluno> alunos) // O método ListarAlunos recebe uma lista de alunos como parâmetro, permitindo que ele acesse e exiba as informações de todos os alunos cadastrados na lista. Isso é útil para mostrar uma visão geral dos alunos registrados no sistema, facilitando a consulta e o gerenciamento dos dados dos alunos.
{
    Console.WriteLine("\n=== LISTA DE ALUNOS ===");
    if (alunos.Count == 0)
    {
        Console.WriteLine("Nenhum aluno cadastrado.");
        return;
    }
    foreach (var aluno in alunos)
    {
        Console.WriteLine($"Nome: {aluno.Nome}, Idade: {aluno.Idade}");
    }
}

void BuscarAluno(List<Aluno> alunos)
{
    while (true)
    {
        Console.Write("\nDigite o nome do aluno para buscar ou 0 para voltar: ");
        string nomeBusca = Console.ReadLine() ?? string.Empty;

        if (nomeBusca == "0")
        {
            Console.WriteLine("Operação de busca cancelada.");
            return;
        }

        // var aluno = alunos.FirstOrDefault(a => 
        //     RemoverAcentos(a.Nome.ToLower()) == RemoverAcentos(nomeBusca.ToLower())
        // );

        var alunosEncontrados = alunos
        .Where(a => RemoverAcentos(a.Nome.ToLower())
        .Contains(RemoverAcentos(nomeBusca.ToLower())))
        .ToList();

        if (alunosEncontrados.Count == 0)
        {
            Console.WriteLine("Nenhum aluno encontrado. Tente novamente.");
        }
        else
        {
            Console.WriteLine("\n=== ALUNOS ENCONTRADOS ===");
            
            foreach (var a in alunosEncontrados)
            {
                // if (RemoverAcentos(a.Nome.ToLower()) == RemoverAcentos(nomeBusca.ToLower()))
                {
                    Console.WriteLine($"Aluno encontrado: {a.Nome}, Idade: {a.Idade}");
                }
            }
        }
    }
}

void RemoverAluno(List<Aluno> alunos)
{
    while (true)
    {
        Console.Write("\nDigite o nome do aluno para remover ou 0 para voltar: ");
        string nomeRemover = Console.ReadLine() ?? string.Empty;

        if (nomeRemover == "0")
        {
            Console.WriteLine("Operação cancelada.");
            return;
        }

        var aluno = alunos.FirstOrDefault(a => 
            RemoverAcentos(a.Nome.ToLower()) == RemoverAcentos(nomeRemover.ToLower())
        );

        if (aluno == null)
        {
            Console.WriteLine("Aluno não encontrado. Tente novamente.");
        }
        else
        {
            alunos.Remove(aluno);
            Console.WriteLine($"Aluno {aluno.Nome} removido com sucesso.");
        }
    }
}

void EditarAluno(List<Aluno> alunos)
{
    while (true)
    {
        Console.Write("\nDigite o nome do aluno que deseja atualizar ou 0 para voltar: ");
        string nomeBusca = Console.ReadLine() ?? string.Empty;

        if (nomeBusca == "0")
        {
            Console.WriteLine("Operação cancelada.");
            return;
        }

        var aluno = alunos.FirstOrDefault(a => 
            RemoverAcentos(a.Nome.ToLower()) == RemoverAcentos(nomeBusca.ToLower())
        );

        if (aluno == null)
        {
            Console.WriteLine("Aluno não encontrado. Tente novamente.");
        }
        else
        {
            Console.WriteLine($"Aluno encontrado: {aluno.Nome}, Idade: {aluno.Idade}");

            Console.Write("\nNovo nome (ou Enter para manter): ");
            string novoNome = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(novoNome))
            {
                aluno.Nome = novoNome;
            }

            bool idadeValida = false;

            while (!idadeValida)
            {
                Console.Write("Nova idade (ou Enter para manter): ");
                string entrada = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    break; // mantém idade atual
                }

                if (int.TryParse(entrada, out int novaIdade))
                {
                    aluno.Idade = novaIdade;
                    idadeValida = true;
                }
                else
                {
                    Console.WriteLine("Idade inválida.");
                }
            }

            Console.WriteLine($"Aluno {aluno.Nome} atualizado com sucesso!");
            return;
        }
    }
}

void ExibirMenu(List<Aluno> alunos) // O método ExibirMenu recebe uma lista de alunos como parâmetro, permitindo que ele chame os métodos CadastrarAluno e ListarAlunos, que também recebem a lista de alunos como argumento. Isso é importante para garantir que as operações de cadastro e listagem de alunos sejam realizadas na mesma lista, mantendo a consistência dos dados e permitindo que as alterações feitas em um método sejam refletidas no outro.
{
    while (true)
    {
        Console.WriteLine("\n=== MENU ===");
        Console.WriteLine("1. Cadastrar aluno");
        Console.WriteLine("2. Listar alunos cadastrados");
        Console.WriteLine("3. Buscar aluno por nome");
        Console.WriteLine("4. Remover aluno");
        Console.WriteLine("5. Editar aluno");
        Console.WriteLine("0. Sair");

        Console.Write("Escolha uma opção: ");
        string opcao = Console.ReadLine() ?? string.Empty;

        switch (opcao)
        {
            case "1":
                CadastrarAluno(alunos); // Chama o método CadastrarAluno passando a lista de alunos para adicionar um novo aluno à lista
                break;

            case "2":
                ListarAlunos(alunos); // Chama o método ListarAlunos passando a lista de alunos para exibir as informações de todos os alunos cadastrados
                break;

            case "3":
                BuscarAluno(alunos); // Chama o método BuscarAluno passando a lista de alunos para buscar um aluno específico pelo nome
                break;

            case "4":
                RemoverAluno(alunos); // Chama o método RemoverAluno passando a lista de alunos para remover um aluno específico pelo nome
                break;

            case "5":
                EditarAluno(alunos); // Chama o método EditarAluno passando a lista de alunos para editar as informações de um aluno específico pelo nome
                break;

            case "0":
                Console.WriteLine("Saindo do sistema. Até logo!");
                return;

            default:
                Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                break;
        }
    }
}