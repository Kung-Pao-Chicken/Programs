using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.DTOs.BlogDTOs;
using MyBlog.Entities;

namespace MyBlog.Bases.BlogBases
{
    public class LayoutBase
    {
        /// <summary>
        /// 获取导航的DTO对象
        /// </summary>
        /// <returns></returns>
        public static List<MenuDTO> GetMenu()
        {
            var t_category=new myblogEntities().mix_category;
            var t_categorycontent = new myblogEntities().mix_categorycontent;
            var t_acticle = new myblogEntities().mix_acticle;

            var Menus = new List<MenuDTO>();
            foreach (var i in t_category)
            {
                var a = new MenuDTO() { CatName = i.CatName };
                var b = new SubMenuItemDTO();
                foreach (var k in t_categorycontent.Where(val => val.CatID == i.CatID))
                {
                    b.CatcontentName = k.CatContentName;
                    b.CatContentID = k.CatContentID;
                    b.ActicleCount = (from val in t_acticle where val.CatContentID == k.CatContentID select val).Count();
                    a.SubMenuItems.Add(b);
                }
                Menus.Add(a);
            }
            return Menus;
        }
    }
}