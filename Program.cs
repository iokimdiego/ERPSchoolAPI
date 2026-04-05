Console.WriteLine("=== SISTEMA ERP SCHOOL API ===");

Console.Write("Digite seu nome: ");
string nome = Console.ReadLine();

// Console.Write("Digite sua idade: ");
// int idade = int.Parse(Console.ReadLine()); // Esta linha pode lançar uma exceção se a entrada não for um número inteiro

int idade = 0; // Variável para armazenar a idade do usuário
bool idadeValida = false;

while (!idadeValida) // Loop para validar a entrada da idade
{
    Console.Write("Digite sua idade: ");
    string idadeInput = Console.ReadLine();

    if (int.TryParse(idadeInput, out idade)) // Tenta converter a entrada para um número inteiro
    {
        idadeValida = true; // A idade é válida, sai do loop
    }
    else
    {
        Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro para a idade."); // Mensagem de erro para entrada inválida
    }
}

Console.WriteLine($"Bem-vindo, {nome}! Você tem {idade} anos.");