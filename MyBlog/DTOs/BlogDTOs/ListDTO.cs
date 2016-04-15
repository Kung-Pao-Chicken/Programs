using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.DTOs.BlogDTOs
{
    /// <summary>
    /// 列表页DTO
    /// </summary>
    public class ListItemDTO
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
        /// 文章创建时间
        /// </summary>
        public DateTime? ActicleDate { get; set; }
    }
}