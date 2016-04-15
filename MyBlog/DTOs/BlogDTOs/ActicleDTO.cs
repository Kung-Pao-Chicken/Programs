using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.DTOs.BlogDTOs
{
    /// <summary>
    /// 文章页DTO
    /// </summary>
    public class ActicleDTO
    {
        /// <summary>
        /// 文章标题
        /// </summary>
        public string ActicleTitle { get; set; }
        /// <summary>
        /// 文章所属
        /// </summary>
        public string ActicleCopyright { get; set; }
        /// <summary>
        /// 文章创立时间
        /// </summary>
        public DateTime? ActicleDate { get; set; }
        /// <summary>
        /// 文章内容路径
        /// </summary>
        public string ActicleContain { get; set; }
    }
}