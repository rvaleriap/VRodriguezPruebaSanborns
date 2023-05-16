using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class ProductoController : Controller
    {

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Producto producto = new ML.Producto();
            ML.Result result = BL.Producto.GetAll();
           
            if (result.Correct)
            {
                producto.Productos = result.Objects;
                return View(producto);
            }
            else
            {
                return View(producto);
            }
        }
        [HttpGet]
        public ActionResult Form(int? Sku)
        {
           
            ML.Producto producto = new ML.Producto();
            producto.Division = new ML.Division();

            if (Sku == null)
            {
                return View(producto);
            }
            else
            {
                ML.Result result = BL.Producto.GetById(Sku.Value);
                if (result.Correct)
                {
                    producto = (ML.Producto)result.Object;
                    return View(producto);
                }
                else
                {
                    ViewBag.Message = "ocurrio un problema";
                    return View("Modal");

                }
            }

        }
        [HttpPost]
        public ActionResult Form(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            if (producto.Sku == 0)
            {
                result = BL.Producto.Add(producto);
                if (result.Correct)
                {
                    ViewBag.Message= "Registrado con Exito";
                    return View("Modal");
                }
                else
                {
                    ViewBag.Message = "No se pudo registrar";
                    return View("Modal");
                }
                
            }
            else
            {
                result = BL.Producto.Update(producto);
                if (result.Correct)
                {
                    ViewBag.Message= "Actualizado con Exito";
                    return View("Modal");
                }
                else
                {
                    ViewBag.Message=  "Actualizado con Exito" ;
                    return View("Modal");
                }
            }
        }
    }
}
