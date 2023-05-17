using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ictshop.Models;

namespace Ictshop.Controllers
{
    public class SanphamController : Controller
    {

        Qlbanhang db = new Qlbanhang();

        // GET: Sanpham
        public ActionResult hangsx()
        {
            var Hangsx = db.Hangsanxuats.ToList();
            return PartialView(Hangsx);
        }
        public ActionResult sanpham(int Mahang)
        {
            var ss = db.Sanphams.Where(n => n.Mahang == Mahang).Take(4).ToList();
            return PartialView(ss);
        }
        public ActionResult timkiem(string name)
        {
            var sanpham = db.Sanphams.ToList();

            if (!string.IsNullOrWhiteSpace(name))
            {
                sanpham = sanpham.Where(n => n.Tensp.ToLower().Contains(name.ToLower())).ToList();
            }

            return View(sanpham);

        }
        public ActionResult xemchitiet(int Masp)
        {
            var chitiet = db.Sanphams.SingleOrDefault(n=>n.Masp== Masp);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }

    }

}