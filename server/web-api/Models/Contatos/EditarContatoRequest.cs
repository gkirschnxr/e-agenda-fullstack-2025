namespace eAgenda.WebApi.Models.Contatos;

public record EditarContatoRequest(
    string Nome, 
    string Telefone, 
    string Email,
    string? Empresa, 
    string? Cargo
);

public record EditarContatoResponse(
    string Nome,
    string Telefone,
    string Email,
    string? Empresa,
    string? Cargo
);