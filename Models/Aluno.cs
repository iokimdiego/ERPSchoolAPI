namespace ERPSchoolAPI.Models;

public class Aluno
{
    public string nome { get; set; } = string.Empty; // Inicializa com string vazia para evitar null
    public int idade { get; set; } // Idade é um número inteiro, não precisa de inicialização
}