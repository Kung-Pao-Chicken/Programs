using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.Entities;
using MyBlog.DTOs.AdminDTOs;

namespace MyBlog.Bases.AdminBases
{
    public class CatContentBase
    {
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<CatContentDTO> GetActicleList(int? id){
            var ActicleList = new List<CatContentDTO>();
            var ActicleTable = from val in new myblogEntities().mix_acticle select val;
            if (id != null)
            {
                ActicleTable = from val in new myblogEntities().mix_acticle where val.CatContentID==id select val;
            }
            foreach (var i in ActicleTable)
            {
                var Acticle = new CatContentDTO()
                {
                    ActicleID = i.ActicleID,
                    ActicleCopyright = i.ActicleCopyright,
                    ActicleTitle = i.ActicleTitle,
                };
                ActicleList.Add(Acticle);
            }
            return ActicleList;
        }

        /// <summary>
        /// 设置文章信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static string SetActicle(DTOs.AdminDTOs.PostCatContentItemDTO dto)
        {
            var db = new myblogEntities();
            var update = (from val in db.mix_acticle where val.ActicleID == dto.PostActicleID select val).FirstOrDefault();

            try
            {
                switch (dto.Option)
                {
                    
                    case "update":
                        update.ActicleTitle = dto.PostActicleTitle;
                        update.ActicleCopyright = dto.PostActicleCopyright;
                        update.CatContentID = dto.PostCatContentID;
                        db.SaveChanges();
                        break;
                    case "add":
                        db.mix_acticle.Add(new mix_acticle() { 
                            CatContentID = dto.PostCatContentID, 
                            ActicleTitle = dto.PostActicleTitle, 
                            ActicleCopyright = dto.PostActicleCopyright, 
                            ActicleDate = DateTime.Now });
                        db.SaveChanges();
                        break;
                    case "delete":
                        db.mix_acticle.Remove(update);
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

        /// <summary>
        /// 获取栏目列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetCatContentList()
        {
            var CatContentList = from val in new myblogEntities().mix_categorycontent select val;
            var result = new List<string>();
            foreach (var i in CatContentList)
            {
                result.Add(i.CatContentID + "-" + i.CatContentName);
            }
            return result;
        }

        /// <summary>
        /// 获取栏目名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetCatContentName(int? id)
        {
            if (id == null)
            {
                return "未分类文章列表";
            }
            else
            {
                var headtitle = (from val in new myblogEntities().mix_categorycontent where val.CatContentID == id select val).FirstOrDefault().CatContentName;
                return headtitle;
            }
        }
    }
}