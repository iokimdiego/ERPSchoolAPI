Aluno aluno = new Aluno(); //

ExibirTitulo();
CadastrarUsuario(aluno);
ExibirMenu(aluno);

// ===================MÉTODOS===================

void ExibirTitulo()
{
    Console.WriteLine("=== SISTEMA ERP SCHOOL API ===");
}


void CadastrarUsuario(Aluno aluno)
{
    Console.Write("Digite seu nome:");
    aluno.Nome = Console.ReadLine() ?? string.Empty;

    bool idadeValida = false;

    while (!idadeValida)
    {
        Console.Write("Digite sua idade:");
        string idadeInput = Console.ReadLine() ?? string.Empty;

        if (int.TryParse(idadeInput, out int idade)) // Tenta converter a entrada para um número inteiro, se for possível, atribui à variável idade
        {
            aluno.Idade = idade; // Atribui a idade ao objeto aluno
            // nunca use out ou ref direto em propriedades, isso pode causar problemas de encapsulamento e manutenção do código. Use variáveis locais para manipular os dados antes de atribuí-los às propriedades.

            if (aluno.Idade >= 0)
            {
                idadeValida = true;
            }
            else
            {
                Console.WriteLine("Idade deve ser um número positivo. Tente novamente.");
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro para a idade.");
        }
    }
}

void ExibirMenu(Aluno aluno)
{
    while (true)
    {
        Console.WriteLine("\n=== MENU PRINCIPAL ===");
        Console.WriteLine("1. Ver dados");
        Console.WriteLine("2. Atualizar nome");
        Console.WriteLine("3. Atualizar idade");
        Console.WriteLine("0. Sair");

        Console.Write("Escolha uma opção:");
        string opcao = Console.ReadLine() ?? string.Empty;

        switch (opcao)
        {
            case "1":
                Console.WriteLine($"\nNome: {aluno.Nome}");
                Console.WriteLine($"Idade: {aluno.Idade}");
                break;

            case "2":
                Console.Write("\nDigite o novo nome: ");
                aluno.Nome = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("Nome atualizado com sucesso!");
                break;

            case "3":
                bool novaIdadeValida = false;
                while (!novaIdadeValida)
                {
                    Console.Write("\nDigite a nova idade: ");
                    string novaIdadeInput = Console.ReadLine() ?? string.Empty;

                    if (int.TryParse(novaIdadeInput, out int novaIdade))
                    {
                        if (novaIdade >= 0)
                        {
                            aluno.Idade = novaIdade;
                            novaIdadeValida = true;
                            Console.WriteLine("Idade atualizada com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Idade deve ser um número positivo. Tente novamente.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro para a idade.");
                    }
                }
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
