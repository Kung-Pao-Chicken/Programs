using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.DTOs.AdminDTOs
{
    /// <summary>
    ///文章内容DTO对象
    /// </summary>
    public class ActicleDTO
    {
        /// <summary>
        /// 文章ID
        /// </summary>
        public int ActicleID { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string ActicleTitle { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        public string ActicleContain { get; set; }
    }
    /// <summary>
    /// 文章内容提交DTO对象
    /// </summary>
    public class PostActicleDTO
    {
        /// <summary>
        /// 文章ID
        /// </summary>
        public int PostActicleID { get; set; }
        /// <summary>
        /// 文章摘要
        /// </summary>
        public string PostActicleAbstract { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        public string PostContainText { get; set; }

    }
}