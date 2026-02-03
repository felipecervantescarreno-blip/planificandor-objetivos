using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

[Route("Tareas")]
public class TareasController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var tareas = new List<Tarea>();
        return View(tareas);
    }
}


//    var cs = _config.GetConnectionString("DefaultConnection");

//    await using var conn = new SqlConnection(cs);
//    await conn.OpenAsync();

//    var sql = """
//        INSERT INTO Tareas (Nombre, Descripcion)
//        VALUES (@Nombre, @Descripcion)
//    """;

//    await using var cmd = new SqlCommand(sql, conn);
//    cmd.Parameters.AddWithValue("@Nombre", tarea.Nombre);
//    cmd.Parameters.AddWithValue("@Descripcion", tarea.Descripcion);

//    await cmd.ExecuteNonQueryAsync();

//    return View();
//}
//}
