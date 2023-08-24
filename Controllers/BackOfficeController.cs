using Microsoft.AspNetCore.Mvc;

namespace PreguntadOrt.Controllers;

public class BackOfficeController : Controller
{
    public IActionResult AgregarPregunta(){
        ViewBag.Categorias = BD.ObtenerCategorias();
        ViewBag.Dificultades = BD.ObtenerDificultades();
        return View("AgregarPregunta");
    }
    
    public IActionResult CrearPregunta(int IdCategoria,int IdDificultad,string Enunciado, string[] EnunciadoRespuestas,int Correcta){

        List<int> idpreg=BD.AgregarPregunta(IdCategoria,IdDificultad,Enunciado);

        for(int i=0;i<4;i++){
            if (i-1==Correcta){
            BD.CargarRespuesta(EnunciadoRespuestas[i], true, i,idpreg[0]);
            }
            else{
                BD.CargarRespuesta(EnunciadoRespuestas[i],false, i,idpreg[0]);
            }
        }
        return RedirectToAction("Index", "Home");
    }
}
