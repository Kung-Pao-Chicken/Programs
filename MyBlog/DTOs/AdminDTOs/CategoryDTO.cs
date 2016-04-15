using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.DTOs.AdminDTOs
{
    /// <summary>
    /// 项目内容列表
    /// </summary>
    public class CategoryDTO
    {
        /// <summary>
        /// 栏目ID
        /// </summary>
        public int CatContentID { get; set; }
        /// <summary>
        /// 栏目名称
        /// </summary>
        public string CatContentName { get; set; }
        /// <summary>
        /// 栏目Logo的URL
        /// </summary>
        public string CatContentLogoURL { get; set; }
    }

    public class PostCatContentDTO
    {
        public string Option{ get; set; }
        public int PostCatContentID{ get; set; }
        public int PostCatID{ get; set; }
        public string PostCatContentName { get; set; }
    }
}