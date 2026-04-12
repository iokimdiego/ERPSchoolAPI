List<Aluno> alunos = new List<Aluno>(); // Cria uma lista para armazenar os objetos do tipo Aluno. Essa lista pode ser usada para gerenciar múltiplos alunos, permitindo adicionar, remover ou listar os alunos cadastrados no sistema.

ExibirTitulo();
ExibirMenu(alunos);

// ===================MÉTODOS===================

void ExibirTitulo()
{
    Console.WriteLine("=== SISTEMA ERP SCHOOL API ===");
}


void CadastrarAluno(List<Aluno> alunos) // O método CadastrarAluno recebe uma lista de alunos como parâmetro, permitindo que o aluno cadastrado seja adicionado à lista. Isso é útil para gerenciar múltiplos alunos no sistema, possibilitando operações como listar, atualizar ou remover alunos posteriormente.
{
    Aluno aluno = new Aluno(); // Cria uma nova instância da classe Aluno para armazenar os dados do aluno que será cadastrado. Cada vez que o método for chamado, um novo objeto Aluno será criado para armazenar as informações do aluno atual.
    
    Console.Write("Digite o nome do aluno: ");
    aluno.Nome = Console.ReadLine() ?? string.Empty;

    bool idadeValida = false;

    while (!idadeValida)
    {
        Console.Write("Digite a idade do aluno: ");
        string idadeInput = Console.ReadLine() ?? "";

        if (int.TryParse(idadeInput, out int idade)) // Tenta converter a entrada para um número inteiro, se for possível, atribui à variável idade
        {
            aluno.Idade = idade; // Atribui a idade ao objeto aluno
            idadeValida = true; // Define a variável idadeValida como true para sair do loop, indicando que a idade foi inserida corretamente

        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro para a idade.");
        }
    }
    alunos.Add(aluno); // Adiciona o objeto aluno à lista de alunos, permitindo que ele seja gerenciado e listado posteriormente
    Console.WriteLine("Aluno cadastrado com sucesso!");
}

void ListarAlunos(List<Aluno> alunos) // O método ListarAlunos recebe uma lista de alunos como parâmetro, permitindo que ele acesse e exiba as informações de todos os alunos cadastrados na lista. Isso é útil para mostrar uma visão geral dos alunos registrados no sistema, facilitando a consulta e o gerenciamento dos dados dos alunos.
{
    Console.WriteLine("\n=== LISTA DE ALUNOS ===");
    if (alunos.Count == 0)
    {
        Console.WriteLine("Nenhum aluno cadastrado.");
        return;
    }
    else
    {
        foreach (var aluno in alunos)
        {
            Console.WriteLine($"Nome: {aluno.Nome}, Idade: {aluno.Idade}");
        }
    }
}

void ExibirMenu(List<Aluno> alunos) // O método ExibirMenu recebe uma lista de alunos como parâmetro, permitindo que ele chame os métodos CadastrarAluno e ListarAlunos, que também recebem a lista de alunos como argumento. Isso é importante para garantir que as operações de cadastro e listagem de alunos sejam realizadas na mesma lista, mantendo a consistência dos dados e permitindo que as alterações feitas em um método sejam refletidas no outro.
{
    while (true)
    {
        Console.WriteLine("\n=== MENU ===");
        Console.WriteLine("1. Cadastrar aluno: ");
        Console.WriteLine("2. Listar alunos cadastrados: ");
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

            case "0":
                Console.WriteLine("Saindo do sistema. Até logo!");
                return;

            default:
                Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                break;
        }
    }
}