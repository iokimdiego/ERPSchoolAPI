using System.Globalization;
using System.Text;
using SchoolERP.Models;

namespace SchoolERP.Services;

public class AlunoService
{
    private List<Aluno> alunos = new();

    public List<Aluno> Listar()
    {
        return alunos;
    }

    public List<Aluno> Buscar(string nome)
    {
        return alunos
            .Where(a => Normalizar(a.Nome)
            .Contains(Normalizar(nome)))
            .ToList();
    }

    public void Adicionar(Aluno aluno)
    {
        alunos.Add(aluno);
    }

    public bool Remover(string nome)
    {
        var aluno = alunos.FirstOrDefault(a => Normalizar(a.Nome) == Normalizar(nome));

        if (aluno == null) return false;

        alunos.Remove(aluno);
        return true;
    }

    public bool Atualizar(string nome, Aluno novoAluno)
    {
        var aluno = alunos.FirstOrDefault(a => Normalizar(a.Nome) == Normalizar(nome));

        if (aluno == null) return false;

        aluno.Nome = novoAluno.Nome;
        aluno.Idade = novoAluno.Idade;

        return true;
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