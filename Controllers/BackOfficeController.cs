/*using Microsoft.AspNetCore.Mvc;

namespace PreguntadOrt.Controllers;

public class BackOfficeController : Controller
{
    public IActionResult AñadirPregunta(){
        return View("AñadirPregunta");
    }
    public IActionResult CrearPregunta(int IdCategoria,int IdDificultad,string Enunciado, string[] EnunciadoRespuestas,int Correcta){
        BD.CargarPregunta(IdCategoria,IdDificultad,Enunciado)

        for(int i=0;i<4;i++){
            if (i=Correcta){
            BD.CargarRespuesta(EnunciadoRespuestas[i], true, i)}
            else{
                BD.CargarRespuesta(EnunciadoRespuesas[i],false, i)
            }
        }
        Return RedirectToAction("Index", "HomeController");
    }
}
*/