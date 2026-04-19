using Microsoft.AspNetCore.Mvc;
using SchoolERP.Models;
using SchoolERP.Services;

namespace ERPSchoolAPI.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunoController : ControllerBase
{
    private readonly AlunoService _service;

    public AlunoController(AlunoService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        return Ok(_service.Listar());
    }

    [HttpGet("buscar")]
    public IActionResult Buscar([FromQuery] string nome)
    {
        return Ok(_service.Buscar(nome));
    }

    [HttpPost]
    public IActionResult Adicionar([FromBody] Aluno aluno)
    {
        _service.Adicionar(aluno);
        return Ok("Aluno cadastrado");
    }

    [HttpDelete]
    public IActionResult Remover([FromQuery] string nome)
    {
        var ok = _service.Remover(nome);

        if (!ok)
            return NotFound("Aluno não encontrado");

        return Ok("Aluno removido");
    }

    [HttpPut]
    public IActionResult Atualizar([FromQuery] string nome, [FromBody] Aluno aluno)
    {
        var ok = _service.Atualizar(nome, aluno);

        if (!ok)
            return NotFound("Aluno não encontrado");

        return Ok("Aluno atualizado");
    }
}