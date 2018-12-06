using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Front.Controllers
{
    public class PedidoController : Controller
    {
        private readonly Client.Contracts.IPedidoService _pedidoProxy;
        public PedidoController(Client.Contracts.IPedidoService pedidoServiceProxy)
        {
            this._pedidoProxy = pedidoServiceProxy;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPedidoByClient(string client,int anioCampania)
        {
            try
            {
                if (client == null || anioCampania == 0)
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }

                var result = _pedidoProxy.GetPedidoByClient(client,anioCampania);
                return Json(new { success = true, result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex )
            {
                return Json(new { success = false, error = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}
