using eAgenda.Core.Aplicacao.ModuloContato.Commands;
using System.Collections.Immutable;

namespace eAgenda.WebApi.Models.Contatos;

public record SelecionarContatosRequest(
    int? Quantidade
);

public record SelecionarContatosResponse(
    int Quantidade,
    ImmutableList<SelecionarContatosDTO> Contatos
);