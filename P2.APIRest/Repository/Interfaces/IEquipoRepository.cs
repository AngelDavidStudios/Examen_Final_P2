using P2.Models.Models;

namespace P2.APIRest.Repository.Interfaces;

public interface IEquipoRepository
{
    List<Equipos> GetAllEquipos();
    Equipos GetEquipoById(int id);
    
    // CRUD
    void AddEquipo(Equipos equipo);
    void UpdateEquipo(Equipos equipo);
    void DeleteEquipo(int id);
}