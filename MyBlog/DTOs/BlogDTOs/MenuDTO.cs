using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.DTOs.BlogDTOs
{
    /// <summary>
    /// 项目中的栏目
    /// </summary>
    public struct SubMenuItemDTO
    {
        /// <summary>
        /// 栏目ID
        /// </summary>
        public int CatContentID;
        /// <summary>
        /// 栏目名称
        /// </summary>
        public string CatcontentName;
        /// <summary>
        /// 文章数量
        /// </summary>
        public int ActicleCount;
    }
    public class MenuDTO
    {
        private List<SubMenuItemDTO> _SubMenuItem = new List<SubMenuItemDTO>();
        /// <summary>
        /// 项目名称
        /// </summary>
        public string CatName { get; set; }
        /// <summary>
        /// 栏目列表
        /// </summary>
        public List<SubMenuItemDTO> SubMenuItems
        {
            get
            {
                return _SubMenuItem;
            }
            set
            {
                _SubMenuItem = value;
            }
        }
    }
}