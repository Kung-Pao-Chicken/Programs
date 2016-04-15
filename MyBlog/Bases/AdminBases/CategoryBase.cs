using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.Entities;
using MyBlog.DTOs.AdminDTOs;

namespace MyBlog.Bases.AdminBases
{
    public class CategoryBase
    {
        /// <summary>
        /// 获取项目名称
        /// </summary>
        /// <param name="id">项目ID</param>
        /// <returns></returns>
        public static string GetHeadTitle(int id)
        {
            var headtitle = (from val in new myblogEntities().mix_category where val.CatID == id select val).FirstOrDefault().CatName;
            return headtitle;
        }
        /// <summary>
        /// 获取项目中栏目列表
        /// </summary>
        /// <param name="id">项目ID</param>
        /// <returns></returns>
        public static List<CategoryDTO> GetCatContentList(int id)
        {
            var CatContentList = new List<CategoryDTO>();
            var CatContentTable = from val in new myblogEntities().mix_categorycontent where val.CatID == id select val;
            foreach (var i in CatContentTable)
            {
                var CatContentItem = new CategoryDTO()
                {
                    CatContentID = i.CatContentID,
                    CatContentLogoURL = "/APIs/Image/"+i.CatContentID,
                    CatContentName = i.CatContentName,
                };
                CatContentList.Add(CatContentItem);
            }
            return CatContentList;
        }
        /// <summary>
        /// 设置项目
        /// </summary>
        /// <param name="Option"></param>
        /// <param name="PostCatContentID"></param>
        /// <param name="PostCatID"></param>
        /// <param name="PostCatContentName"></param>
        /// <returns></returns>
        public static string SetCatContent(DTOs.AdminDTOs.PostCatContentDTO dto)
        {
            var db = new myblogEntities();
            var update = (from val in db.mix_categorycontent where val.CatContentID == dto.PostCatContentID select val).FirstOrDefault();
            try
            {
                switch (dto.Option)
                {
                    case "add":
                        db.mix_categorycontent.Add(new mix_categorycontent() {
                            CatID = dto.PostCatID,
                            CatContentName = dto.PostCatContentName, 
                        });
                        db.SaveChanges();
                        break;
                    case "delete":
                        db.mix_categorycontent.Remove(update);
                        db.SaveChanges();
                        break;
                    case "update":
                        update.CatContentName = dto.PostCatContentName;
                        update.CatID = dto.PostCatID;
                        db.SaveChanges();
                        break;
                }
            }
            catch
            {
                return "failed";
            }
            return "success";
        }

        public static List<string> GetCategoryItems()
        {
            var CategoryTable = from val in new myblogEntities().mix_category select val;
            var result = new List<string>();
            foreach (var i in CategoryTable)
            {
                result.Add(i.CatID + "-" + i.CatName);
            }
            return result;
        }
    }
}