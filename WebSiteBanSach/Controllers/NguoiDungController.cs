using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanSach.Models;
namespace WebSiteBanSach.Controllers
{
    public class NguoiDungController : Controller
    {
        QuanLyBanSachEntities1 db = new QuanLyBanSachEntities1();
        // GET: NguoiDung
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(KhachHang kh)
        {
            
            if (ModelState.IsValid)
            {
                Debug.WriteLine(kh.Email);
                Debug.WriteLine(kh.HoTen);
                db.KhachHangs.Add(kh);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            Debug.WriteLine("OK");
            string sTaiKhoan = f.Get("txtTaiKhoan").ToString();
            string sMatKhau = f.Get("txtMatKhau").ToString();
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if(kh != null)
            {
                //ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công !";
                Session["TaiKhoan"] = kh.MaKh;
                Debug.WriteLine(Session["TaiKhoan"]);
                if (kh.MaKh == 1)
                {
                    Debug.WriteLine("Admin");
                    return RedirectToAction("Index", "QuanLySanPham");
                    
                }
                
                return RedirectToAction("Index", "Home"); ;
            }
            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng !";
            return View();
        }
        public ActionResult DangXuat()
        {
            Session.Contents.Remove("TaiKhoan");
            return RedirectToAction("Index", "Home");
        }
    }
}