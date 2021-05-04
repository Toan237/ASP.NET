using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanSach.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace WebSiteBanSach.Controllers
{
    public class QuanLySanPhamController : Controller
    {
        // GET: QuanLySanPham
        QuanLyBanSachEntities1 db = new QuanLyBanSachEntities1();
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 3;
            return View(db.Saches.ToList().OrderBy(n=>n.MaSach).ToPagedList(pageNumber,pageSize));
        }
        // them moi
        [HttpGet]
        
        public ActionResult ThemMoi()
        {
            ViewBag.MaChuDe = new SelectList(db.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");

            return View();
        }
        
        [HttpPost]
        [ValidateInput(false)]
        
        public ActionResult ThemMoi(Sach sach, HttpPostedFileBase fileUpload)
        {
            
            
            ViewBag.MaChuDe = new SelectList(db.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            //kiem tra duong dan anh bia
            /*
            var fileName = Path.GetFileNameWithoutExtension(sach.fileUpload.FileName); 
            var extension = Path.GetFileNameWithoutExtension(sach.fileUpload.FileName);
            //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            sach.AnhBia = "~/HinhAnhSach/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/HinhAnhSach"), fileName);
            sach.fileUpload.SaveAs(fileName);
            if(ModelState.IsValid)
            {
                db.Saches.Add(sach);
                db.SaveChanges();
            }*/
            
                if (fileUpload == null)
                {
                    ViewBag.ThongBao = "Chọn hình ảnh";
                    //return View();
                }
           // them vao co so du lieu

           if(ModelState.IsValid)
           {
               // luu ten file
               var fileName = Path.GetFileName(fileUpload.FileName);
                // luu duong dan cua file
                var path = Path.Combine(Server.MapPath("~/HinhAnhSach"), fileName);
               //Kiem tra anh da ton tai chua

               if (System.IO.File.Exists(path))
                {
                   ViewBag.ThongBao = "Hình ảnh đã tồn tại";

                }
                else
                {
                   fileUpload.SaveAs(path);
               }

               sach.AnhBia = fileUpload.FileName;
               db.Saches.Add(sach);
               db.SaveChanges();
              }
       
            return View();
        }
        // Chỉnh sửa sản phẩm
        [HttpGet]
        public ActionResult ChinhSua(int MaSach)
        {
            
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == MaSach);
            if(sach == null)
            {
                Response.StatusCode = 404;
                return null; 
            }
            ViewBag.MaChuDe = new SelectList(db.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe", sach.MaChuDe);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB", sach.MaNXB);
            return View(sach);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(Sach sach, FormCollection f, HttpPostedFileBase fileUpload)
        {
            // them vao co so du lieu

            if (ModelState.IsValid)
            {
                // luu ten file
                if(fileUpload == null)
                {
                    db.Entry(sach).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                }
                else
                {
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    // luu duong dan cua file
                    var path = Path.Combine(Server.MapPath("~/HinhAnhSach"), fileName);

                    fileUpload.SaveAs(path);
                    sach.AnhBia = fileUpload.FileName;

                }
                // thực hiện cập nhật model
                db.Entry(sach).State = System.Data.Entity.EntityState.Modified;
                
                db.SaveChanges();
            }
            ViewBag.MaChuDe = new SelectList(db.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe", sach.MaChuDe);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB", sach.MaNXB);
            
            return RedirectToAction("Index");
        }
        public ActionResult HienThi(int MaSach)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }
        //Xoa san pham
        [HttpGet]
        public ActionResult Xoa(int MaSach)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaSach)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.Saches.Remove(sach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}