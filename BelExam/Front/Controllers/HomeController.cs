using Autofac.Extras.NLog;
using System;
using System.Web.Mvc;

namespace Front.Controllers
{
    public class HomeController : Controller
    {
        private readonly Client.Contracts.IProductoService _productoProxy;
        private readonly ILogger _logger;

        public HomeController(Client.Contracts.IProductoService productoServiceProxy, ILogger logger)
        {
            this._productoProxy = productoServiceProxy;
            this._logger = logger;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Search(string search)
        {           
            try
            {
                _logger.Info("Iniciando busqueda...!");
                var result = _productoProxy.SearchWithSP(search); // _productoProxy.Search(search);
                var json = Json(new { success = true, result }, JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
                return json;

            }
            catch (Exception ex)
            {
                _logger.Error($"Error al realizar la busqueda. Error Mensaje:{ex}");
                return Json(new { success = false,message = $"Error en la búsqueda :{ex}" }, JsonRequestBehavior.AllowGet);
            }
           
        }
    }
}
