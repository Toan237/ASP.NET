using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanSach.Models;

namespace WebSiteBanSach.Controllers
{
    public class NhaXuatBanController : Controller
    {
        // GET: NhaXuatBan
        QuanLyBanSachEntities1 db = new QuanLyBanSachEntities1();
        public PartialViewResult NhaXuatBanPartial()
        {
            return PartialView(db.NhaXuatBans.Take(5).OrderBy(x=>x.TenNXB).ToList());
        }
        // Hiển thị sách theo nhà xuất bản
        public ViewResult SachTheoNXB(int MaNXB)
        {
            NhaXuatBan nxb = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nxb == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Sach> lstSach = db.Saches.Where(n => n.MaNXB == MaNXB).OrderBy(n => n.GiaBan).ToList();
            if (lstSach.Count == 0)
            {
                ViewBag.Sach = "Không có sách nào thuộc chủ đề này";
            }
            return View(lstSach);
        }
        // Hiển thị các nhà xuất bản
        public ViewResult DanhMucNXB()
        {
            return View(db.NhaXuatBans.ToList());
        }
    }
}