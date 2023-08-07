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
        string sql = "select * from Preguntas where Preguntas.IdDificultad = @dif and Preguntas.IdCategoria = @cat";
        return db.Query<Preguntas>(sql, new {@dif = dificultad}, new {@cat = categoria}).ToList(); 
    }
}else if (dificultad == -1 && categoria != -1){
using(SqlConnection db = new SqlConnection(_connectionString)){
        string sql = "select * from Preguntas where Preguntas.IdCategoria = @cat";
        return db.Query<Preguntas>(sql, new {@cat = categoria}).ToList(); 
    }
    }else if (dificultad != -1 && categoria == -1){
        using(SqlConnection db = new SqlConnection(_connectionString)){
        string sql = "select * from Preguntas where Preguntas.IdDificultad = @dif";
        return db.Query<Preguntas>(sql, new {@dif = dificultad}).ToList(); 
    }
    }else{
        using(SqlConnection db = new SqlConnection(_connectionString)){
        string sql = "select * from Preguntas";
        return db.Query<Preguntas>(sql).ToList(); 
    }
    }
}






//nose si esta bien hay que ver no se me ocurrio asi otra forma de hacerlo
public static List<Respuestas> ObtenerRespuestas(List<Preguntas> preguntas){
  List<Respuestas> listaQuery = new List<Respuestas>();
    for (int i = 0;i<preguntas.Count;i++){
        using(SqlConnection db = new SqlConnection(_connectionString)){
        string sql = "select * from Respuestas where Respuestas.IdPregunta = @preg";
        List<Respuestas> resp = db.Query<Categorias>(sql, new{@preg = preguntas[i].IdPregunta}).ToList(); 
        }
        listaQuery.AddRange(resp);
    }
    return listaQuery;
    
}
}
