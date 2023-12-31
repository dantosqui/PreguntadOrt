static public class Juego{
    static private string _username;
    static private int _puntajeActual;
    static private int _cantidadPreguntasCorrectas;
    static private int _preguntaNumero=1;
    static private List<Preguntas> _preguntas;
    static private List<Respuestas> _respuestas;
    static private Random rnd = new Random();

    static public void InicializarJuego(){
        _username="";
        _puntajeActual=0;_cantidadPreguntasCorrectas=0;
        _preguntaNumero = 1;
    }
    static public List<Categorias> ObtenerCategorias(){
        return BD.ObtenerCategorias();
    }
    static public List<Dificultades> ObtenerDificultades(){
        return BD.ObtenerDificultades();
    }
    static public void CargarPartida(string username,int dificultad, int categoria){
        _username=username;
        _preguntas=BD.ObtenerPreguntas(dificultad, categoria);
        _respuestas=BD.ObtenerRespuestas(_preguntas);
    }
    static public Preguntas ObtenerProximaPregunta(){
        if (_preguntas.Any()){
        return _preguntas[rnd.Next(0,_preguntas.Count)];
        }
        else return null;
    }
    static public List<Respuestas> ObtenerProximasRespuestas(int idPregunta){
        
        List<Respuestas> respuestas = new List<Respuestas>();
        
        foreach (var i in _respuestas){
            if(i.IdPregunta==idPregunta)
            respuestas.Add(i);
        }
        return respuestas;
    }
    static public Respuestas[] VerificarRespuesta(int idPregunta, int idRespuesta){
        Respuestas rtaEnviada= _respuestas.Find(x=>x.IdRespuesta==idRespuesta);
        _preguntaNumero++;
        if (rtaEnviada.Correcta){
            _puntajeActual+=10;
            _cantidadPreguntasCorrectas++;
            
        }
        //ACORDARSE: MANDA PRIMERO RESPUESTA ENVIADA Y DESPUES RESPUESTA CORRECTA
        Respuestas[] rtaenviadaycorrecta = {rtaEnviada, _respuestas.Find(x=>x.IdPregunta==idPregunta && x.Correcta)};
        
        _preguntas.Remove(_preguntas.Find(x=>x.IdPregunta==idPregunta));
        return rtaenviadaycorrecta; 
    }

   static public Categorias DevolverCategoriaPregunta(Preguntas preg){
        return ObtenerCategorias().Find(x=>x.IdCategoria==preg.IdCategoria);

   }
    static public void ObtenerInfoJugador(ref string username, ref int puntajeActual, ref int cantpreguntas, ref int preguntaNumero){
        username=_username;puntajeActual=_puntajeActual;cantpreguntas=_cantidadPreguntasCorrectas;preguntaNumero=_preguntaNumero;
    }
    
}