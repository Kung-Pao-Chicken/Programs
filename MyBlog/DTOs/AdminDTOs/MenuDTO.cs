using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.DTOs.AdminDTOs
{
    /// <summary>
    /// 项目导航列表
    /// </summary>
    public class MenuCategoryDTO
    {
        /// <summary>
        /// 项目ID
        /// </summary>
        public int CatID { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string CatName { get; set; }
    }
    /// <summary>
    /// 栏目导航列表
    /// </summary>
    public class MenuCatContentDTO
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
        /// 栏目文章数量
        /// </summary>
        public int ActicleCount { get; set; }
    }
}