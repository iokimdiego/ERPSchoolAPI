using System.Globalization;
using System.Text;
using ERPSchoolAPI.Models;

namespace ERPSchoolAPI.Services;

public class AlunoService
{
    private List<Aluno> alunos = new List<Aluno>();

    public void CadastrarAluno()
    {
        while (true)
        {
            Aluno aluno = new Aluno();

            Console.Write("Digite o nome do aluno ou 0 para voltar: ");
            aluno.Nome = Console.ReadLine() ?? string.Empty;

            if (aluno.Nome == "0")
                return;

            while (true)
            {
                Console.Write("Digite a idade: ");
                if (int.TryParse(Console.ReadLine(), out int idade))
                {
                    aluno.Idade = idade;
                    break;
                }

                Console.WriteLine("Idade inválida.");
            }

            alunos.Add(aluno);
            Console.WriteLine($"Aluno {aluno.Nome} cadastrado!");

            Console.Write("Cadastrar outro? (S/N): ");
            if ((Console.ReadLine() ?? "").ToUpper() != "S")
                break;
        }
    }

    public void ListarAlunos()
    {
        Console.WriteLine("\n=== ALUNOS ===");

        if (alunos.Count == 0)
        {
            Console.WriteLine("Nenhum aluno cadastrado.");
            return;
        }

        foreach (var a in alunos)
        {
            Console.WriteLine($"Nome: {a.Nome}, Idade: {a.Idade}");
        }
    }

    public void BuscarAluno()
    {
        while (true)
        {
            Console.Write("\nBuscar nome (0 para sair): ");
            string busca = Console.ReadLine() ?? "";

            if (busca == "0") return;

            var encontrados = alunos
                .Where(a => Normalizar(a.Nome).Contains(Normalizar(busca)))
                .ToList();

            if (encontrados.Count == 0)
            {
                Console.WriteLine("Nenhum encontrado.");
                continue;
            }

            foreach (var a in encontrados)
            {
                Console.WriteLine($"Nome: {a.Nome}, Idade: {a.Idade}");
            }
        }
    }

    public void RemoverAluno()
    {
        while (true)
        {
            Console.Write("\nNome para remover (0 para sair): ");
            string nome = Console.ReadLine() ?? "";

            if (nome == "0") return;

            var aluno = alunos.FirstOrDefault(a => Normalizar(a.Nome) == Normalizar(nome));

            if (aluno == null)
            {
                Console.WriteLine("Não encontrado.");
                continue;
            }

            alunos.Remove(aluno);
            Console.WriteLine("Removido!");
        }
    }

    public void EditarAluno()
    {
        while (true)
        {
            Console.Write("\nNome para editar (0 para sair): ");
            string nome = Console.ReadLine() ?? "";

            if (nome == "0") return;

            var aluno = alunos.FirstOrDefault(a => Normalizar(a.Nome) == Normalizar(nome));

            if (aluno == null)
            {
                Console.WriteLine("Não encontrado.");
                continue;
            }

            Console.Write("Novo nome: ");
            string novoNome = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(novoNome))
                aluno.Nome = novoNome;

            Console.Write("Nova idade: ");
            if (int.TryParse(Console.ReadLine(), out int idade))
                aluno.Idade = idade;

            Console.WriteLine("Atualizado!");
            return;
        }
    }

    private string Normalizar(string texto)
    {
        var normalized = texto.ToLower().Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();

        foreach (var c in normalized)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                sb.Append(c);
        }

        return sb.ToString();
    }
}