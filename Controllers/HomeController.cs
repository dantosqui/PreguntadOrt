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
        string username=""; int puntajeActual=0, cantpregs=0;
        Juego.ObtenerInfoJugador(ref username,ref puntajeActual,ref cantpregs);
        ViewBag.NumPregunta=cantpregs;
        ViewBag.Pregunta = Juego.ObtenerProximaPregunta();
        ViewBag.Username=username;
        ViewBag.Puntaje=puntajeActual;
        if(ViewBag.Pregunta != null /*nose despues vemos*/){
        ViewBag.Respuestas = Juego.ObtenerProximasRespuestas(ViewBag.Pregunta.IdPregunta);
        return RedirectToAction("Jugar"); 
       
        }else{
            return View("Fin");
        }
        
        
    }

    [HttpPost] public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta){
        Respuestas[] resps = Juego.VerificarRespuesta(idPregunta,idRespuesta);
        string username=""; int puntajeActual=0, cantpregs=0;
        Juego.ObtenerInfoJugador(ref username,ref puntajeActual,ref cantpregs);
        ViewBag.Username=username;
        ViewBag.Puntaje=puntajeActual;
        if(resps[0] == resps[1]){

            ViewBag.Correcta = true;
        }else
        {
            ViewBag.Correcta = false;
            ViewBag.RespuestaCorrecta = resps[1];
        }
        return View("Respuesta");
    }
}


