using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaoCao_webMuaBanGiayDep.Models;

namespace BaoCao_webMuaBanGiayDep.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        QLGiayDepDataContext db = new QLGiayDepDataContext();
        public ActionResult Dangnhap()
        {
            if (Session["kh"] != null && Session["kh"].ToString() != "Saitaikhoanhoacmatkhau")
                return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        public ActionResult login(FormCollection col)
        {
            var user = col["txtUsername"];
            var pass = col["txtPassword"];
            KhachHang k = db.KhachHangs.FirstOrDefault(a => a.TaiKhoan == user && a.MatKhau == pass);
            if (k != null)
            {
                Session["kh"] = k;
                return RedirectToAction("Index", "Home");
            }
            Session["kh"] = "Saitaikhoanhoacmatkhau";
            return RedirectToAction("Dangnhap", "Login");
        }
        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection col, KhachHang kh)
        {
            var hoten = col["txtHoten"];
            var gt = col["rdo"];
            var sdt = col["txtSDT"];
            var user = col["txtUsername"];
            var pass = col["txtPassword"];
            var email = col["txtEmail"];
            var diachi = col["txtDiachi"];

            kh.HoTen = hoten;
            kh.GioiTinh = gt;
            kh.DienThoai = sdt;
            kh.TaiKhoan = user;
            kh.MatKhau = pass;
            kh.Email = email;
            kh.DiaChi = diachi;

            db.KhachHangs.InsertOnSubmit(kh);
            db.SubmitChanges();

            Session["kh"] = hoten;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Dangxuat()
        {
            Session["kh"] = null;
            Session["Giohang"] = null;
            return RedirectToAction("Dangnhap", "Login");
        }
    }
}
