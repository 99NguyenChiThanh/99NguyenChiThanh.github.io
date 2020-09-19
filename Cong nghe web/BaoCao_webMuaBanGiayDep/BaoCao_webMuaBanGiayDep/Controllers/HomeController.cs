using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaoCao_webMuaBanGiayDep.Models;

namespace BaoCao_webMuaBanGiayDep.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        QLGiayDepDataContext db = new QLGiayDepDataContext();
        public ActionResult Index()
        {
            List<ChiTietSanPham> dsSanPham = db.ChiTietSanPhams.ToList();
            return View(dsSanPham);
        }

        public ActionResult Chitietsp(string tensp)
        {
            ChiTietSanPham chitietsp = db.ChiTietSanPhams.ToList().FirstOrDefault(sp => sp.TenSP.Contains(tensp));
            return View(chitietsp);
        }

        [HttpPost]
        public ActionResult Timkiem(FormCollection col)
        {
            var tensp = col["txtTukhoa"];
            if (tensp != "")
            {
                List<ChiTietSanPham> lstsp = db.ChiTietSanPhams.ToList().Where(sp => sp.TenSP.Contains(tensp)).ToList();
                return View(lstsp);
            }
            return View();
        }
        public ActionResult Locsptheoloai(int ma)
        {
            List<ChiTietSanPham> listSP = db.ChiTietSanPhams.ToList().Where(sp => sp.MaLoai == ma).ToList();
            return View(listSP);
        }
        public ActionResult Locsptheonhom(int ms)
        {
            List<ChiTietSanPham> listSP = db.ChiTietSanPhams.ToList().Where(sp => sp.MaNhom == ms).ToList();
            return View(listSP);
        }
    }
}
