using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanSach.Models;
namespace WebSiteBanSach.Controllers
{
    public class QuanLyNhaXuatBanController : Controller
    {
        // GET: QuanLyNhaXuatBan
        QuanLyBanSachEntities1 db = new QuanLyBanSachEntities1();
        public ActionResult Index()
        {
            return View(db.NhaXuatBans.ToList().OrderBy(n => n.MaNXB));
        }
        [HttpGet]
        public ActionResult ThemMoi()
        {

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]

        public ActionResult ThemMoi(NhaXuatBan nhaxuatban)
        {
            db.NhaXuatBans.Add(nhaxuatban);
            db.SaveChanges();
            return View();
        }
        [HttpGet]

        public ActionResult ChinhSua(int MaNXB)
        {

            NhaXuatBan nhaxuatban = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nhaxuatban == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(nhaxuatban);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(NhaXuatBan nhaxuatban, FormCollection f)
        {
            // them vao co so du lieu

            if (ModelState.IsValid)
            {
                // thực hiện cập nhật model
                db.Entry(nhaxuatban).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public ActionResult HienThi(int MaNXB)
        {
            NhaXuatBan nhaxuatban = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nhaxuatban == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nhaxuatban);
        }
        //Xoa san pham
        [HttpGet]
        public ActionResult Xoa(int MaNXB)
        {
            NhaXuatBan nhaxuatban = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nhaxuatban == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nhaxuatban);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaNXB)
        {
            NhaXuatBan nhaxuatban = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nhaxuatban == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.NhaXuatBans.Remove(nhaxuatban);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}