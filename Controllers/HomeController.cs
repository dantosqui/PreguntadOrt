using Microsoft.AspNetCore.Mvc;

namespace PreguntadOrt.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ConfigurarJuego(){
        Juego.InicializarJuego()
        ViewBag.Categorias = BD.ObtenerCategorias;
        ViewBag.Dificultades = BD.ObtenerDificultades;
        return ConfigurarJuego();
    }

    public IActionResult Comenzar(string username, int dificultad, int categoria){
        Juego.CargarPartida(username, dificultad, categoria);
        if(BD.ObtenerPreguntas(dificultad,categoria) != null)/*hay que ver lo de null aca*/{
            return RedirectToAction(Jugar);
        }else{
            return RedirectToAction(ConfigurarJuego);
        }
    }


    public IActionResult Jugar(){
        
        ViewBag.Pregunta = Juego.ObtenerProximaPregunta();
        if(ViewBag.Pregunta != null /*nose despues vemos*/){
        ViewBag.Respuestas = Juego.ObtenerProximasRespuestas(ViewBag.Pregunta.IdPregunta);
        return Juego();
       
        }else{
            return Fin();
        }
        
        
    }

    [HttpPost] public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta){
        ViewBag.RespuestaCorrecta
        ViewBag.EsCorrecta = Juego.VerificarRespuesta(idPregunta, idRespuesta);
        return Respuesta()
    }
}


