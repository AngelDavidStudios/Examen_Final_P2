using Microsoft.AspNetCore.Mvc;
using P2.APIRest.Repository.Interfaces;
using P2.Models.Models;

namespace P2.APIRest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquipoController: ControllerBase
{
    private readonly IEquipoRepository _equipoRepository;
    
    public EquipoController(IEquipoRepository equipoRepository)
    {
        _equipoRepository = equipoRepository;
    }
    
    [HttpGet]
    public IActionResult GetAllEquipos()
    {
        return Ok(_equipoRepository.GetAllEquipos());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetEquipoById(int id)
    {
        return Ok(_equipoRepository.GetEquipoById(id));
    }
    
    [HttpPost]
    public IActionResult AddEquipo([FromBody] Equipos equipo)
    {
        _equipoRepository.AddEquipo(equipo);
        return Ok("Equipo agregado con exito");
    }
    
    [HttpPut]
    public IActionResult UpdateEquipo([FromBody] Equipos equipo)
    {
        _equipoRepository.UpdateEquipo(equipo);
        return Ok("Equipo actualizado con exito");
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteEquipo(int id)
    {
        _equipoRepository.DeleteEquipo(id);
        return Ok("Equipo eliminado con exito");
    }
}