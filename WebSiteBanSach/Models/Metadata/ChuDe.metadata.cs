using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebSiteBanSach.Models
{
    [MetadataTypeAttribute(typeof(ChuDeMetadata))]
    public partial class ChuDe
    {
        internal sealed class ChuDeMetadata
        {
            [Display(Name = "Mã chủ đề")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public int MaChuDe { get; set; }
            [Display(Name = "Tên chủ đề")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public string TenChuDe { get; set; }
        }
    }
}