using eAgenda.Core.Aplicacao.ModuloContato.Commands;
using System.Collections.Immutable;

namespace eAgenda.WebApi.Models.Contatos;

public record SelecionarContatoPorIdRequest(Guid Id);

public record SelecionarContatoPorIdResponse(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string? Empresa,
    string? Cargo,
    ImmutableList<DetalhesCompromissoContatoDTO> Compromissos
);
