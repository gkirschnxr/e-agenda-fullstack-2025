using eAgenda.Core.Aplicacao.ModuloContato.Commands;
using eAgenda.Core.Dominio.ModuloContato;
using eAgenda.WebApi.Models.Contatos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eAgenda.WebApi.Controllers;

// A��o (MVC) = Endpoint (Web API)
[ApiController]
[Route("[controller]")]
public class ContatoController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CadastrarContatoResponse>> Cadastrar(CadastrarContatoRequest request) {
        var command = new CadastrarContatoCommand(
            request.Nome,
            request.Telefone,
            request.Email,
            request.Empresa,
            request.Cargo
        ); 

        var result = await mediator.Send(command);

        if (result.IsFailed) return BadRequest();

        var response = new CadastrarContatoResponse(result.Value.Id);

        return Created(string.Empty, response);
    }

    [HttpPut("id:guid")]
    public async Task<ActionResult<EditarContatoResponse>> Editar(Guid id, EditarContatoRequest request) {
        var command = new EditarContatoCommand(
                id,
                request.Nome,
                request.Telefone,
                request.Email,
                request?.Empresa,
                request?.Cargo
        );

        var result = await mediator.Send(command);

        if (result.IsFailed) return BadRequest();

        var response = new EditarContatoResponse(
                result.Value.Nome,
                result.Value.Telefone,
                result.Value.Email,
                result.Value.Empresa,
                result.Value.Cargo
        );

        return Ok(response);
    }

    
    [HttpGet]
    public async Task<ActionResult<SelecionarContatosResponse>> SelecionarRegistros(
        [FromQuery] SelecionarContatosRequest? request
    ) {
        var query = new SelecionarContatosQuery(request?.Quantidade);

        var result = await mediator.Send(query);

        if (result.IsFailed) return BadRequest();

        var response = new SelecionarContatosResponse(
            result.Value.Contatos.Count, 
            result.Value.Contatos
        );

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SelecionarContatoPorIdResponse>> SelecionarRegistroPorId(
        Guid id
    ) {
        var query = new SelecionarContatoPorIdQuery(id);

        var result = await mediator.Send(query);

        if (result.IsFailed) return NotFound(id);

        var response = new SelecionarContatoPorIdResponse(
            result.Value.Id,
            result.Value.Nome,
            result.Value.Telefone,
            result.Value.Email,
            result.Value.Empresa,
            result.Value.Cargo,
            result.Value.Compromissos
        );

        return Ok(response);
    }
}
