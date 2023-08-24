using System.Data.SqlClient;
using Dapper;

public class BD{ 
private static string _connectionString = @"Server=localhost;
DataBase=PreguntadOrt;Trusted_Connection=True;";

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
        return db.Query<Preguntas>(sql, new {@dif = dificultad, @cat=categoria}).ToList(); 
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
  List<Respuestas> resp = new List<Respuestas>();
    for (int i = 0;i<preguntas.Count;i++){
        using(SqlConnection db = new SqlConnection(_connectionString)){
        string sql = "select * from Respuestas where Respuestas.IdPregunta = @preg";
        resp = db.Query<Respuestas>(sql, new{@preg = preguntas[i].IdPregunta}).ToList(); 
        }
        listaQuery.AddRange(resp);
    }
    return listaQuery;
  
}


public static void AgregarTablaPuntajes(int puntaje, string username, DateTime fechaHora){

    string SQL = "insert into Puntajes(fechahora,username,puntaje) values (@fH, @u, @p)";

    using(SqlConnection db = new SqlConnection(_connectionString)){
        db.Execute(SQL, new {fH = fechaHora, u = username, p = puntaje});
    }
}

public static List<Puntaje> ObtenerPuntaje(){
    List<Puntaje> ps = new List<Puntaje>();
   using(SqlConnection db = new SqlConnection(_connectionString)){
        string sql = "SELECT top 5 * FROM Puntajes order by Puntajes.puntaje desc";
        ps = db.Query<Puntaje>(sql).ToList(); 
        sql = "select top 5 Puntajes.puntaje from Puntajes order by Puntajes.puntaje desc";
        List<int> lInt = db.Query<int>(sql).ToList();
        for(int i = 0; i < ps.Count; i++){
            ps[i].PuntajeUsuario = lInt[i];
        }

    }
    return ps;
}


public static List<int> AgregarPregunta(int IdCategoria,int IdDificultad,String Enunciado){

List<int> idpreg = new List<int>();
    string SQL ="INSERT INTO Preguntas(IdCategoria,IdDificultad,Enunciado) VALUES (@pidcat, @piddif, @penun)";
    using(SqlConnection db = new SqlConnection(_connectionString))
    {
        db.Execute(SQL,new{pidcat=IdCategoria,piddif=IdDificultad,penun=Enunciado});
    }
    using(SqlConnection db=new SqlConnection(_connectionString)){
        string sql = "SELECT IdPregunta FROM Preguntas WHERE Enunciado=@en";
        idpreg=db.Query<int>(sql, new {en=Enunciado}).ToList();
    }
    return idpreg;

}

public static void CargarRespuesta(string enunciado, bool Correcta, int Opcion, int IdPregunta){
    string SQL ="INSERT INTO Respuestas(IdPregunta,Opcion,Contenido, Correcta) VALUES (@pidpr,@pop,@pen,@pco)";
    using(SqlConnection db = new SqlConnection(_connectionString))
    {
        db.Execute(SQL,new{pen=enunciado,pco=Correcta,pop=Opcion,pidpr=IdPregunta});
    }
}


}
