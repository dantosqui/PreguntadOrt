using System.Data.SqlClient;
using Dapper;

public class BD{
private static string _connectionString = @"Server=localhost;
DataBase =NombreBase;Trusted_Connection=True;";

public static List<Categorias> ObtenerCategorias(){
    using(SqlConnection db = new SqlConnection(_connectionString)){
        string sql = "SELECT * FROM Categorias";
        return db.Query<Categorias>(sql).ToList(); 
    }

}

public static List<Dificultades> ObtenerDificultades(){
   using(SqlConnection db = new SqlConnection(_connectionString)){
        string sql = "SELECT * FROM Dificultades";
        return db.Query<Dificultades>(sql).ToList(); 
    }

}
public static List<Preguntas> ObtenerPreguntas(int dificultad, int categoria){
if(dificultad != -1 && categoria != -1){
       using(SqlConnection db = new SqlConnection(_connectionString)){
        string sql = "SELECT * FROM Categorias";
        return db.Query<Categorias>(sql).ToList(); 
    }
/*esta todo vacio creo que me olvide de poner schema and data y habre puesto solo schema mieerda perdon
*/
}
}

public static List<Respuestas> ObtenerRespuestas(List<Preguntas> preguntas){
    return new List<Respuestas>();
}
}