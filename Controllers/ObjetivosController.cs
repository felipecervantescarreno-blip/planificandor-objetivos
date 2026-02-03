using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Planificador_Objetivos.Controllers
{
    public class ObjetivosController : Controller
    {
        private readonly IConfiguration _configuration;

        // Inyección de configuración
        public ObjetivosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            // Aquí se declara y obtiene la cadena de conexión
            string connectionString = _configuration.GetConnectionString("MiConexion");

            var objetivos = new List<string>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Objetivos"; // Ajusta la tabla

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Cambia "Nombre" por la columna real de tu tabla
#pragma warning disable CS8604 // Posible argumento de referencia nulo
                            objetivos.Add(reader["Nombre"].ToString());
#pragma warning restore CS8604 // Posible argumento de referencia nulo
                        }
                    }
                }
            }

            ViewBag.Objetivos = objetivos;
            return View();
        }
    }
}


