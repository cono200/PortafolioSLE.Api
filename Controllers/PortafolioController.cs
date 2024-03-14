using PortafolioSLE.Api.Models;
using PortafolioSLE.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace PortafolioSLE.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PortafolioController : ControllerBase
{
    private readonly ILogger<PortafolioController> _logger;
    private readonly PortafolioServices _portafolioServices;


    public PortafolioController(
        ILogger<PortafolioController> logger,
        PortafolioServices portafolioServices)
    {
        _logger = logger;
        _portafolioServices = portafolioServices;
    }
    
    [HttpGet]
    public async Task<ActionResult> GetPortafolio()
    {
        var portafolio = await _portafolioServices.GetAsync();
        return Ok(portafolio);
    }

    [HttpGet("{id}")]	
    public async Task<ActionResult> GetPortafolioById(string id)
    {
        return Ok(await _portafolioServices.GetPortafolioId(id));
    }

    [HttpPost]
    public async Task<ActionResult> CreatePortafolio([FromBody] Portafolio portafolio)
    {
        if (portafolio == null)
        {
            return BadRequest();
        }
        if (portafolio.NombreProyecto == string.Empty)
        {
            ModelState.AddModelError("NombreProyecto", "El nombre del proyecto es requerido");
        }

        await _portafolioServices.InsertPortafolio(portafolio);
        return Created("Created", true);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePortafolio([FromBody] Portafolio portafolio,string id)
    {
        if (portafolio == null)
        {
            return BadRequest();
        }
        if (portafolio.NombreProyecto == string.Empty)
        {
            ModelState.AddModelError("NombreProyecto", "El nombre del proyecto es requerido");
        }

        portafolio.Id = id;
        await _portafolioServices.UpdatePortafolio(portafolio);
        return Created("Created", true);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePortafolio(string id)
    {
        await _portafolioServices.DeletePortafolio(id);
        return NoContent();
    }







}