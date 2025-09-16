using eAgenda.Core.Aplicacao.ModuloContato.Cadastrar;
using eAgenda.Core.Dominio.ModuloContato;
using eAgenda.WebApi.Models.Contatos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eAgenda.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ContatoController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IRepositorioContato _repositorioContato;
    private readonly ILogger<ContatoController> _logger;

    public ContatoController(IMediator mediator,
                             IRepositorioContato repositorioContato, 
                             ILogger<ContatoController> logger                            
        ) {
        _mediator = mediator;
        _repositorioContato = repositorioContato;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(CadastrarContatoRequest request) {
        var command = new CadastrarContatoCommand(
            request.Nome,
            request.Telefone,
            request.Email,
            request.Empresa,
            request.Cargo
        ); 

        var result = await _mediator.Send(command);

        if (result.IsFailed) return BadRequest();

        var response = new CadastrarContatoResponse(result.Value.Id);

        return Created(string.Empty, response);
    }

    // Ação (MVC) = Endpoint (Web API)
    [HttpGet]
    public async Task<IActionResult> SelecionarRegistrosAsync() {
        var registros = await _repositorioContato.SelecionarRegistrosAsync();

        return Ok(registros);
    }
}
