using eAgenda.Core.Dominio.ModuloContato;
using Microsoft.AspNetCore.Mvc;

namespace eAgenda.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ContatoController : ControllerBase
{
    private readonly IRepositorioContato _repositorioContato;
    private readonly ILogger<ContatoController> _logger;

    public ContatoController(IRepositorioContato repositorioContato, 
                            ILogger<ContatoController> logger                            
        ) {
        _repositorioContato = repositorioContato;
        _logger = logger;
    }

    // Ação (MVC) = Endpoint (Web API)
    [HttpGet]
    public async Task<IActionResult> SelecionarRegistrosAsync() {
        var registros = await _repositorioContato.SelecionarRegistrosAsync();

        return Ok(registros);
    }
}
