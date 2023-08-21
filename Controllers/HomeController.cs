using Microsoft.AspNetCore.Mvc;

namespace PreguntadOrt.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ConfigurarJuego(){
        Juego.InicializarJuego();
        ViewBag.Categorias = BD.ObtenerCategorias();
        ViewBag.Dificultades = BD.ObtenerDificultades();
        return View();
    }

    public IActionResult Comenzar(string username, int dificultad, int categoria){
        Juego.CargarPartida(username, dificultad, categoria);
        if(BD.ObtenerPreguntas(dificultad,categoria) != null)/*hay que ver lo de null aca*/{
            return RedirectToAction("Jugar");
        }else{
            return RedirectToAction("ConfigurarJuego");
        }
    }

    public IActionResult Jugar(){
        string username=""; int puntajeActual=0, cantpregs=0, preguntaNumero=0;
        Juego.ObtenerInfoJugador(ref username,ref puntajeActual,ref cantpregs, ref preguntaNumero);
        
        ViewBag.NumPregunta=cantpregs;
        ViewBag.Pregunta = Juego.ObtenerProximaPregunta();
        ViewBag.Username=username;
        ViewBag.Puntaje=puntajeActual;
        ViewBag.PreguntaNumero=preguntaNumero;
        if(ViewBag.Pregunta != null /*nose despues vemos*/){
        ViewBag.Respuestas = Juego.ObtenerProximasRespuestas(ViewBag.Pregunta.IdPregunta);
        foreach (var i in BD.ObtenerCategorias()){
            if (i.IdCategoria==ViewBag.Pregunta.IdCategoria){
                ViewBag.Categoria=i.Nombre;
            }
        }
        
        return View("Juego"); 
       
        }else{
            BD.AgregarTablaPuntajes(ViewBag.Puntaje, username, DateTime.Now);
            return View("Fin");

        }
        
        
    }
    public IActionResult HighScores(){
ViewBag.puntajes = BD.ObtenerPuntaje();
        return View();
    }

    [HttpPost] public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta){
        Respuestas[] resps = Juego.VerificarRespuesta(idPregunta,idRespuesta);
        string username=""; int puntajeActual=0, cantpregs=0, preguntaNumero=0;
        Juego.ObtenerInfoJugador(ref username,ref puntajeActual,ref cantpregs, ref preguntaNumero);
        ViewBag.Username=username;
        ViewBag.Puntaje=puntajeActual;
        if(resps[0] == resps[1]){

            ViewBag.Correcta = true;
        }else
        {
            ViewBag.Correcta = false;
            ViewBag.RespuestaCorrecta = resps[1].Contenido;
        }
        return View("Respuesta");
    }
}


