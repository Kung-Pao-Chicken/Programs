using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.DTOs.AdminDTOs
{
    /// <summary>
    /// 项目列表
    /// </summary>
    public class ProjectDTO
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
    /// 提交的项目列表
    /// </summary>
    public class PostProjectDTO
    {
        /// <summary>
        /// 操作方式
        /// </summary>
        public string Option { get; set; }
        /// <summary>
        /// 项目ID
        /// </summary>
        public int PostCatID { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string PostCatName { get; set; }
    }
}