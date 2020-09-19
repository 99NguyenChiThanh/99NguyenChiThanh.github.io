using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaoCao_webMuaBanGiayDep.Models;
using System.IO;

namespace BaoCao_webMuaBanGiayDep.Controllers
{
    public class QlysanphamController : Controller
    {
        //
        // GET: /Qlysanpham/
        QLGiayDepDataContext db = new QLGiayDepDataContext();
        public ActionResult Qlysanpham()
        {
            List<ChiTietSanPham> dsSanPham = db.ChiTietSanPhams.ToList();
            return View(dsSanPham);
        }
        public ActionResult Them()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertNew(FormCollection col, HttpPostedFileBase fileUpload)
        {
            var fileName="";
            if (fileUpload != null && fileUpload.ContentLength > 0)
            {
                fileName = Path.GetFileName(fileUpload.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Hinh/"), fileName);
                fileUpload.SaveAs(path);
            }
            ChiTietSanPham sp = new ChiTietSanPham();
            sp.TenSP = col["tensp"];
            sp.Hinh = fileName;
            sp.MoTa = col["mota"];
            sp.Size = col["size"];
            sp.MaLoai = int.Parse(col["loai"]);
            sp.Gia = int.Parse(col["dongia"]);
            sp.MaNhom = int.Parse(col["nhom"]);

            db.ChiTietSanPhams.InsertOnSubmit(sp);
            db.SubmitChanges();
            return RedirectToAction("Qlysanpham", "Qlysanpham");
        }
        public ActionResult Sua(int masp)
        {
            ChiTietSanPham sp = new ChiTietSanPham();
            sp = db.ChiTietSanPhams.FirstOrDefault(dep => dep.MaSP == masp);
            return View(sp);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection col, int masp)
        {
            ChiTietSanPham sp = new ChiTietSanPham();
            if (sp != null)
            {
                sp = db.ChiTietSanPhams.FirstOrDefault(dep => dep.MaSP == masp);
                sp.TenSP = col["tensp"];
                sp.Hinh = col["hinh"];
                sp.MoTa = col["mota"];
                sp.Size = col["size"];
                sp.MaLoai = int.Parse(col["loai"]);
                sp.Gia = int.Parse(col["dongia"]);
                sp.MaNhom = int.Parse(col["nhom"]);

                db.SubmitChanges();
            }
            return RedirectToAction("Qlysanpham", "Qlysanpham");
        }
        public ActionResult Xoa(int masp)
        {
            ChiTietSanPham sp = new ChiTietSanPham();
            sp = db.ChiTietSanPhams.FirstOrDefault(dep => dep.MaSP == masp);
            if (sp != null)
            {
                List<ChiTietDonDatHang> lstDDH = db.ChiTietDonDatHangs.ToList().Where(giay => giay.MaSP == masp).ToList();
                db.ChiTietDonDatHangs.DeleteAllOnSubmit(lstDDH);
                db.ChiTietSanPhams.DeleteOnSubmit(sp);
                db.SubmitChanges();
            }
            return RedirectToAction("Qlysanpham", "Qlysanpham");
        }
    }
}
