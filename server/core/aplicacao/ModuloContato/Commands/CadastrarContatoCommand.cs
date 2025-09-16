using FluentResults;
using MediatR;

namespace eAgenda.Core.Aplicacao.ModuloContato.Commands;

// quando cadastramos
public record CadastrarContatoCommand(
    string Nome, string Telefone, string Email,
    string? Empresa, string? Cargo) : IRequest<Result<CadastrarContatoResult>>;

// quando retornamos
public record CadastrarContatoResult(Guid Id);
