using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.Entities;
using MyBlog.DTOs.AdminDTOs;

namespace MyBlog.Bases.AdminBases
{
    public class AdminLayoutBase
    {
        /// <summary>
        /// 获取项目列表
        /// </summary>
        /// <returns></returns>
        public static List<MenuCategoryDTO> GetCategoryMenu()
        {
            var t_mix_category = from val in new myblogEntities().mix_category select val;
            var CategoryList = new List<MenuCategoryDTO>();
            foreach (var i in t_mix_category)
            {
                CategoryList.Add(new MenuCategoryDTO() { CatID = i.CatID, CatName = i.CatName });
            }
            return CategoryList;
        }
        /// <summary>
        /// 获取栏目列表
        /// </summary>
        /// <returns></returns>
        public static List<MenuCatContentDTO> GetCatContentMenu()
        {
            var t_mix_categorycontent = from val in new myblogEntities().mix_categorycontent select val;
            var t_mix_acticle = from val in new myblogEntities().mix_acticle select val;
            var CatContentList = new List<MenuCatContentDTO>();
            foreach (var i in t_mix_categorycontent)
            {
                var CatContent = new MenuCatContentDTO();
                CatContent.CatContentName = i.CatContentName;
                CatContent.CatContentID = i.CatContentID;
                CatContent.ActicleCount =(from val in t_mix_acticle where val.CatContentID == i.CatContentID select val).Count();
                CatContentList.Add(CatContent);
            }
            return CatContentList;
        }
    }
}