using k20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace k20.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        public ActionResult DanhSach()
        {   
            Model1 db = new Model1();
            List<KhachHang> danhsachkhachhang = db.KhachHangs.ToList();
            return View(danhsachkhachhang);
        }
    }
}