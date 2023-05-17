using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ictshop.Models;


namespace Ictshop.Controllers
{
    public class DanhmucController : Controller
    {
        Qlbanhang db = new Qlbanhang();
        // GET: Danhmuc
        public ActionResult DanhmucPartial()
        {
            var danhmuc = db.Hangsanxuats.ToList();
            return PartialView(danhmuc);
        }
        public ActionResult Manufacturer(int mahangsx) {
            var hangsx = db.Hangsanxuats.SingleOrDefault(n => n.Mahang == mahangsx);
            return PartialView(hangsx);
        }
        public ActionResult ListManufacturers(int mahangsx, string tenhangsx)
        {
            var sanpham = db.Sanphams.Where(n=> n.Mahang == mahangsx).ToList();
            return View(sanpham);
        }
    }
}