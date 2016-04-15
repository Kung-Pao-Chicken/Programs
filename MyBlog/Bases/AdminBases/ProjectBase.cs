using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.DTOs.AdminDTOs;
using MyBlog.Entities;

namespace MyBlog.Bases.AdminBases
{
    public class ProjectBase
    {
        public static List<ProjectDTO> GetCategoryList()
        {
            var CategoryList = new List<ProjectDTO>();
            var categorytable = new myblogEntities().mix_category;
            foreach (var i in categorytable)
            {
                CategoryList.Add(new ProjectDTO() { CatID = i.CatID, CatName = i.CatName });
            }
            return CategoryList;
        }
        public static string SetCategory(PostProjectDTO dto)
        {
            var db = new myblogEntities();
            var update = (from val in db.mix_category where val.CatID == dto.PostCatID select val).FirstOrDefault();
            try
            {
                switch (dto.Option)
                {
                    case "add":
                        db.mix_category.Add(new mix_category() { CatName = dto.PostCatName });
                        db.SaveChanges();
                        break;
                    case "delete":
                        db.mix_category.Remove(update);
                        db.SaveChanges();
                        break;
                    case "update":
                        update.CatName = dto.PostCatName;
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
    }
}