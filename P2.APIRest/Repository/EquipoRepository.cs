using Microsoft.Data.SqlClient;
using P2.APIRest.Repository.Interfaces;
using P2.Models.Models;

namespace P2.APIRest.Repository;

public class EquipoRepository: IEquipoRepository
{
    private readonly string _connectionString;
    
    public EquipoRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("ConnectionP2");
    }
    
    public List<Equipos> GetAllEquipos()
    {
        List<Equipos> equipos = new();
        using (SqlConnection connection = new(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM GENERAL.Equipos";
            SqlCommand command = new(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Equipos equipo = new()
                {
                    IdEquipo = Convert.ToInt32(reader["IDEquipo"]),
                    Nombre = reader["NombreEquipo"].ToString(),
                    Tipo = reader["TipoEquipo"].ToString(),
                    PrecioXDia = Convert.ToDouble(reader["PrecioxDia"]),
                    Descripcion = reader["Descripcion"].ToString(),
                };
                equipos.Add(equipo);
            }
        }
        return equipos;
    }
    
    public Equipos GetEquipoById(int id)
    {
        Equipos equipo = new();
        using (SqlConnection connection = new(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM GENERAL.Equipos WHERE IDEquipo = @Id";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                equipo.IdEquipo = Convert.ToInt32(reader["IDEquipo"]);
                equipo.Nombre = reader["NombreEquipo"].ToString();
                equipo.Tipo = reader["TipoEquipo"].ToString();
                equipo.PrecioXDia = Convert.ToDouble(reader["PrecioxDia"]);
                equipo.Descripcion = reader["Descripcion"].ToString();
            }
        }
        return equipo;
    }
    
    public void AddEquipo(Equipos equipo)
    {
        using (SqlConnection connection = new(_connectionString))
        {
            connection.Open();
            string query = "INSERT INTO GENERAL.Equipos (IDEquipo, NombreEquipo, TipoEquipo, PrecioxDia, Descripcion) VALUES (@IDEquipo, @Nombre, @Tipo, @Precio, @Descripcion)";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@IDEquipo", equipo.IdEquipo);
            command.Parameters.AddWithValue("@Nombre", equipo.Nombre);
            command.Parameters.AddWithValue("@Tipo", equipo.Tipo);
            command.Parameters.AddWithValue("@Precio", equipo.PrecioXDia);
            command.Parameters.AddWithValue("@Descripcion", equipo.Descripcion);
            command.ExecuteNonQuery();
        }
    }
    
    public void UpdateEquipo(Equipos equipo)
    {
        using (SqlConnection connection = new(_connectionString))
        {
            connection.Open();
            string query = "UPDATE GENERAL.Equipos SET NombreEquipo = @Nombre, TipoEquipo = @Tipo, PrecioxDia = @Precio, Descripcion = @Descripcion WHERE IDEquipo = @IDEquipo";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@IDEquipo", equipo.IdEquipo);
            command.Parameters.AddWithValue("@Nombre", equipo.Nombre);
            command.Parameters.AddWithValue("@Tipo", equipo.Tipo);
            command.Parameters.AddWithValue("@Precio", equipo.PrecioXDia);
            command.Parameters.AddWithValue("@Descripcion", equipo.Descripcion);
            command.ExecuteNonQuery();
        }
    }
    
    public void DeleteEquipo(int id)
    {
        using (SqlConnection connection = new(_connectionString))
        {
            connection.Open();
            string query = "DELETE FROM GENERAL.Equipos WHERE IDEquipo = @Id";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
    }
}