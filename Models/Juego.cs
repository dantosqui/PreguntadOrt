static public class juego{
    static private string _username;
    static private int _puntajeActual;
    static private int _cantidadPreguntasCorrectas;
    static private List<Preguntas> _preguntas;
    static private List<Respuestas> _respuestas;
    Random rnd = new Random();

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
        _username=username;
        _preguntas=ObtenerPreguntas(dificultad, categoria);
        _respuestas=ObtenerRespuestas(_preguntas);
    }
    static public Preguntas ObtenerProximaPregunta(){
        return _preguntas[rnd.Next(0,_preguntas.Count())];
    }
    static public List<Respuestas> ObtenerProximasRespuestas(int Idpregunta){
        
        List<Respuestas> respuestas = new List<Respuestas>();
        int i=-1;
        bool enc=false;
        while (i<_respuestas.Count()){
            i++;
            if(_respuestas[i].IdPregunta==idpregunta)respuestas.Add(respuestas[i]);
        }
        return respuestas;
    }
    static public bool VerificarRespuesta(int idPregunta, int idRespuesta){
        //estoy re duro mandame tambien por aca la respuesta correcta ;)
            
    }

   
    
}