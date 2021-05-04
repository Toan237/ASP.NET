using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WebSiteBanSach.Models
{
    [MetadataTypeAttribute(typeof(NhaXuatBanMetadata))]
    public partial class NhaXuatBan
    {
        internal sealed class NhaXuatBanMetadata
        {
            [Display(Name = "Mã nhà xuất bản")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public int MaNXB { get; set; }
            [Display(Name = "Tên nhà xuất bản")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public string TenNXB { get; set; }
            [Display(Name = "Địa chỉ")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public string DiaChi { get; set; }
            [Display(Name = "Điện thoại")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public string DienThoai { get; set; }
        }
    }
}