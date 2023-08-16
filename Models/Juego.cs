static public class Juego{
    static private string _username;
    static private int _puntajeActual;
    static private int _cantidadPreguntasCorrectas;
    static private List<Preguntas> _preguntas;
    static private List<Respuestas> _respuestas;
    static private Random rnd = new Random();

    static public void InicializarJuego(){
        _username="";
        _puntajeActual=0;_cantidadPreguntasCorrectas=0;
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
        return _preguntas[rnd.Next(0,_preguntas.Count())];
    }
    static public List<Respuestas> ObtenerProximasRespuestas(int idPregunta){
        
        List<Respuestas> respuestas = new List<Respuestas>();
        int i=-1;
        bool enc=false;
        while (i<_respuestas.Count()){
            i++;
            if(_respuestas[i].IdPregunta==idPregunta)respuestas.Add(respuestas[i]);
        }
        return respuestas;
    }
    static public Respuestas[] VerificarRespuesta(int idPregunta, int idRespuesta){
        Respuestas rtaEnviada= _respuestas.Find(x=>x.IdRespuesta==idRespuesta);
        if (rtaEnviada.Correcta){
            _puntajeActual++;
            _cantidadPreguntasCorrectas++;
            _preguntas.Remove(_preguntas.Find(x=>x.IdPregunta==idPregunta));
        }
        //ACORDARSE: MANDA PRIMERO RESPUESTA ENVIADA Y DESPUES RESPUESTA CORRECTA
        Respuestas[] rtaenviadaycorrecta = {rtaEnviada, _respuestas.Find(x=>x.IdPregunta==idPregunta && x.Correcta)};
        return rtaenviadaycorrecta; 
    }

   static public Categorias DevolverCategoriaPregunta(Preguntas preg){
        return ObtenerCategorias().Find(x=>x.IdCategoria==preg.IdCategoria);

   }
    static public void ObtenerInfoJugador(ref string username, ref int puntajeActual, ref int cantpreguntas){
        username=_username;puntajeActual=_puntajeActual;cantpreguntas=_cantidadPreguntasCorrectas;
    }
    
}