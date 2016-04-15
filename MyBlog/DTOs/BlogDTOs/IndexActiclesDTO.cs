using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.DTOs.BlogDTOs
{
    /// <summary>
    /// 首页最新文章DTO
    /// </summary>
    public class IndexActicleDTO
    {
        /// <summary>
        /// 文章ID
        /// </summary>
        public int ActicleID { get; set; }
        /// <summary>
        /// 文章所属项目ID，方便获取Logo
        /// </summary>
        public int? CatContentID { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string ActicleTitle { get; set; }
        /// <summary>
        /// 文章创立时间
        /// </summary>
        public System.DateTime? ActicleDate { get; set; }
        /// <summary>
        /// 文章摘要
        /// </summary>
        public string ActicleAbstract { get; set; }
        /// <summary>
        /// 文章所属栏目Logo的URL
        /// </summary>
        public string CatContentLogoURL { get; set; }
    }
}