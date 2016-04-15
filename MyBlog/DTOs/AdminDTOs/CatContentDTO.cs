using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.DTOs.AdminDTOs
{
    /// <summary>
    /// 文章管理dto对象
    /// </summary>
    public class CatContentDTO
    {
        public int ActicleID { get; set; }
        public string ActicleTitle { get; set; }
        public string ActicleCopyright { get; set; }
    }
    /// <summary>
    /// 文章设置dto对象
    /// </summary>
    public class PostCatContentItemDTO
    {
        public string Option { get; set; }
        public int PostActicleID { get; set; }
        public int PostCatContentID { get; set; }
        public string PostActicleCopyright { get; set; }
        public string PostActicleTitle { get; set; }
    }
}