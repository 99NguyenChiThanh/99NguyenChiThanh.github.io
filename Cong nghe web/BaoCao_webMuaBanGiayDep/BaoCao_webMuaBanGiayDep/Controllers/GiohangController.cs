using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaoCao_webMuaBanGiayDep.Models;

namespace BaoCao_webMuaBanGiayDep.Controllers
{
    public class GiohangController : Controller
    {
        //
        // GET: /Giohang/
        QLGiayDepDataContext db = new QLGiayDepDataContext();

        public List<Giohang> LayGioHang()
        {
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang == null)
            {
                lstGiohang = new List<Giohang>();
                Session["Giohang"] = lstGiohang;
            }
            return lstGiohang;
        }

        public ActionResult ThemGiohang(int masp)
        {
            if (Session["kh"] != null && Session["kh"].ToString() != "Saitaikhoanhoacmatkhau")
            {
                List<Giohang> lstGiohang = LayGioHang();
                Giohang gh = lstGiohang.Find(sp => sp.iMasp == masp);
                if (gh == null)
                {
                    gh = new Giohang(masp);
                    lstGiohang.Add(gh);
                }
                else
                {
                    gh.iSolg++;
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult XoaGiohang(int masp)
        {
            List<Giohang> lstGiohang = LayGioHang();
            Giohang gh = lstGiohang.SingleOrDefault(sp => sp.iMasp == masp);
            if (gh != null)
            {
                if (gh.iSolg > 1)
                    gh.iSolg -= 1;
                else
                {
                    lstGiohang.RemoveAll(dep => dep.iMasp == masp);
                }
                return RedirectToAction("Giohang");
            }
            return RedirectToAction("Giohang");
        }

        private int Tongtien()
        {
            int Tongtien = 0;
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang != null)
                Tongtien = lstGiohang.Sum(t => t.iThanhtien);
            return Tongtien;
        }

        public ActionResult Dathang()
        {
            List<Giohang> lstGiohang = LayGioHang();
            ViewBag.tongtien = Tongtien();
            return View(lstGiohang);
        }

        public ActionResult Giohang()
        {
            List<Giohang> lstGiohang = LayGioHang();
            if (lstGiohang.Count == 0)
                return RedirectToAction("Index", "Home");
            ViewBag.tongtien = Tongtien();
            return View(lstGiohang);
        }

        public ActionResult Xacnhandathang()
        {
            DonDatHang ddh = new DonDatHang();
            KhachHang kh = (KhachHang)Session["kh"];
            List<Giohang> gh = LayGioHang();
            ddh.MaKH = kh.MaKH;
            ddh.NgayDat = DateTime.Now;
            var ngaygiao = String.Format("{0:MM/dd/yyyy}", DateTime.Now.AddDays(3));
            ddh.NgayGiao = DateTime.Parse(ngaygiao);
            ddh.TinhTrangGiaoHang = false;
            db.DonDatHangs.InsertOnSubmit(ddh);
            db.SubmitChanges();
            foreach (var i in gh)
            {
                ChiTietDonDatHang ctdh = new ChiTietDonDatHang();
                ctdh.MaDonHang = ddh.MaDonHang;
                ctdh.MaSP = i.iMasp;
                ctdh.SoLuong = i.iSolg;
                ctdh.DonGia = i.iDongia;
                db.ChiTietDonDatHangs.InsertOnSubmit(ctdh);
            }
            db.SubmitChanges();
            Session["Giohang"] = null;
            return View();
        }
    }
}
