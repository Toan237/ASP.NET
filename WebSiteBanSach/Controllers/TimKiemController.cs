using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanSach.Models;
using PagedList.Mvc;
using PagedList;

namespace WebSiteBanSach.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        QuanLyBanSachEntities1 db = new QuanLyBanSachEntities1();
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f, int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 3;
            if (f["txtTimKiem"].ToString() == "")
            {
                ViewBag.ThongBao = "Không tìm thấy sách trùng tên ";
                return View(db.Saches.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));
            }
            string sTuKhoa = f["txtTimKiem"].ToString();
            
            ViewBag.TuKhoa = sTuKhoa;
            List<Sach> lstKQTK = db.Saches.Where(n => n.TenSach.Contains(sTuKhoa)).ToList();

            //phan trang
            

            if(lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sách trùng tên ";
                return View(db.Saches.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " +lstKQTK.Count+" kết quả!";
            return View(lstKQTK.OrderBy(n=>n.TenSach).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult KetQuaTimKiem(int? page , String sTuKhoa)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<Sach> lstKQTK = db.Saches.Where(n => n.TenSach.Contains(sTuKhoa)).ToList();

            //phan trang
            int pageNumber = (page ?? 1);
            int pageSize = 3;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sách trùng tên ";
                return View(db.Saches.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy" + lstKQTK.Count + " kết quả!";
            return View(lstKQTK.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));
        }
    }
}