using FluentResults;
using MediatR;
using System.Collections.Immutable;

namespace eAgenda.Core.Aplicacao.ModuloContato.Commands;

public record SelecionarContatosQuery(int? Quantidade) : IRequest<Result<SelecionarContatosResult>>;

public record SelecionarContatosResult(ImmutableList<SelecionarContatosDTO> Contatos);

public record SelecionarContatosDTO(Guid Id, string Nome, string Telefone,
                                   string Email, string? Empresa, string? Cargo);