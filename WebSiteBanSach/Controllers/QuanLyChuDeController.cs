using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanSach.Models;

namespace WebSiteBanSach.Controllers
{
    public class QuanLyChuDeController : Controller
    {
        // GET: QuanLyChuDe
        QuanLyBanSachEntities1 db = new QuanLyBanSachEntities1();

        public ActionResult Index()
        {

            return View(db.ChuDes.ToList().OrderBy(n => n.MaChuDe));
        }
        [HttpGet]
        public ActionResult ThemMoi()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(ChuDe chude)
        {
            db.ChuDes.Add(chude);
            db.SaveChanges();
            return View();
        }
        [HttpGet]

        public ActionResult ChinhSua(int MaChuDe)
        {

            ChuDe chude = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            
            return View(chude);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(ChuDe chude, FormCollection f)
        {
            // them vao co so du lieu

            if (ModelState.IsValid)
            {
                // thực hiện cập nhật model
                db.Entry(chude).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
           
            return RedirectToAction("Index");
        }
        public ActionResult HienThi(int MaChuDe)
        {
            ChuDe chude = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chude);
        }
        //Xoa san pham
        [HttpGet]
        public ActionResult Xoa(int MaChuDe)
        {
            ChuDe chude = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chude);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaChuDe)
        {
            ChuDe chude = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.ChuDes.Remove(chude);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}