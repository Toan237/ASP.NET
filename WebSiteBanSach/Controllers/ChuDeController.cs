using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanSach.Models;

namespace WebSiteBanSach.Controllers
{
    public class ChuDeController : Controller
    {
        // GET: ChuDe

        QuanLyBanSachEntities1 db = new QuanLyBanSachEntities1();
        public ActionResult ChuDePartial()
        {

            return PartialView(db.ChuDes.Take(5).ToList());
        }
        public ViewResult SachTheoChuDe(int MaChuDe)
        {
            //Kiểm tra chủ đề có tồn tại không
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if(cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Sach> lstSach = db.Saches.Where(n => n.MaChuDe == MaChuDe).OrderBy(n=>n.GiaBan).ToList();
            if(lstSach.Count==0)
            {
                ViewBag.Sach = "Không có sách nào thuộc chủ đề này";
            }
            return View(lstSach);
        }
        // Hiển thị các chủ đề
        //public ViewResult DanhMucChuDe()
        //{
        //    return View(db.ChuDes.ToList());
        //}
    }
}