using P2.Models.Models;
using RestSharp;

namespace P2.ConsoleSystem.Services;

public class EquipoService
{
    private readonly RestClient _client;
    
    public EquipoService()
    {
        _client = new RestClient("http://localhost:5148/api/");
    }
    
    public async Task<List<Equipos>> GetEquipos()
    {
        var request = new RestRequest("Equipo", Method.Get);
        var response = await _client.ExecuteAsync<List<Equipos>>(request);
        return response.Data;
    }
    
    public async Task<Equipos> GetEquipo(int id)
    {
        var request = new RestRequest($"Equipo/{id}", Method.Get);
        var response = await _client.ExecuteAsync<Equipos>(request);
        return response.Data;
    }
    
    public async Task AddEquipo(Equipos equipo)
    {
        var request = new RestRequest("Equipo", Method.Post);
        request.AddJsonBody(equipo);
        var response = await _client.ExecuteAsync(request);

        if (!response.IsSuccessful)
            throw new System.Exception(response.ErrorMessage);
    }
    
    public async Task UpdateEquipo(Equipos equipo)
    {
        var request = new RestRequest("Equipo", Method.Put);
        request.AddJsonBody(equipo);
        var response = await _client.ExecuteAsync(request);

        if (!response.IsSuccessful)
            throw new System.Exception(response.ErrorMessage);
    }
    
    public async Task DeleteEquipo(int id)
    {
        var request = new RestRequest($"Equipo/{id}", Method.Delete);
        var response = await _client.ExecuteAsync(request);

        if (!response.IsSuccessful)
            throw new System.Exception(response.ErrorMessage);
    }
}