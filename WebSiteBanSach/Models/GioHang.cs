using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSiteBanSach.Models;
namespace WebSiteBanSach.Models
{
    public class GioHang
    {
        QuanLyBanSachEntities1 db = new QuanLyBanSachEntities1();
        /*private int iMaSP;
        public int IMaSP
        {
            get { return iMaSP; }
            set { iMaSP = value; }
        }*/
        public int iMaSach { get; set; }
        public string sTenSach { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien { get { return iSoLuong * dDonGia; } }

        public GioHang(int MaSach)
        {
            iMaSach = MaSach;
            Sach sach = db.Saches.Single(n => n.MaSach == iMaSach);
            sTenSach = sach.TenSach;
            sAnhBia = sach.AnhBia;
            dDonGia = double.Parse(sach.GiaBan.ToString());
            iSoLuong = 1;
        }

    }
}