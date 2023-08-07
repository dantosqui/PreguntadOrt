static public class juego{
    static private string _username;
    static private int _puntajeActual;
    static private int _cantidadPreguntasCorrectas;
    static private List<Preguntas> _preguntas;
    static private List<Respuestas> _respuestas;

    static public void InicializarJuego(){
        _username=NULL;
        _puntajeActual=0;_cantidadPreguntasCorrectas=0;
    }
    static public List<Categorias> ObtenerCategorias(){
        return BD.ObtenerCategorias();
    }
    static public List<Dificultades> ObtenerDificultades(){
        return BD.ObtenerDificultades();
    }
    static public void CargarPartida(string username,int dificultad, int categoria){
        _preguntas=ObtenerPreguntas(dificultad, categoria);
        _respuestas=ObtenerRespuestas(_preguntas);
    }
    static public Preguntas ObtenerProximaPregunta(){
        
    }
}