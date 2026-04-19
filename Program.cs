using ERPSchoolAPI.Services;

var service = new AlunoService();

while (true)
{
    Console.WriteLine("\n=== MENU ===");
    Console.WriteLine("1. Cadastrar");
    Console.WriteLine("2. Listar");
    Console.WriteLine("3. Buscar");
    Console.WriteLine("4. Remover");
    Console.WriteLine("5. Editar");
    Console.WriteLine("0. Sair");
    
    Console.Write("Escolha uma opção: ");

    var op = Console.ReadLine();

    switch (op)
    {
        case "1": service.CadastrarAluno(); break;
        case "2": service.ListarAlunos(); break;
        case "3": service.BuscarAluno(); break;
        case "4": service.RemoverAluno(); break;
        case "5": service.EditarAluno(); break;
        case "0": return;
    }
}