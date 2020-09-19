using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaoCao_webMuaBanGiayDep.Models
{
    public class Giohang
    {
        QLGiayDepDataContext db = new QLGiayDepDataContext();
        public int iMasp { get; set; }
        public string iHinh { get; set; }
        public string iTensp { get; set; }
        public int iSolg { get; set; }
        public int iDongia { get; set; }
        public int iThanhtien
        {
            get { return iSolg * iDongia; }
        }
        public Giohang(int masp)
        {
            iMasp = masp;
            ChiTietSanPham sp = db.ChiTietSanPhams.Single(dep => dep.MaSP == iMasp);
            iHinh = sp.Hinh;
            iTensp = sp.TenSP;
            iDongia = int.Parse(sp.Gia.ToString());
            iSolg = 1;
        }
    }
}