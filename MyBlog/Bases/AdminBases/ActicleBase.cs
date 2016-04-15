using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.Entities;
using MyBlog.DTOs.AdminDTOs;

namespace MyBlog.Bases.AdminBases
{
    public class ActicleBase
    {
        public static ActicleDTO GetActicleContent(int id){
            var ActicleInfo = new ActicleDTO();
            ActicleInfo.ActicleID = id;
            ActicleInfo.ActicleTitle = (from val in new myblogEntities().mix_acticle where val.ActicleID == id select val).FirstOrDefault().ActicleTitle;
            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath("~/ActicleFiles/" + id + ".html")) == true)
            {
                ActicleInfo.ActicleContain = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/ActicleFiles/" + id + ".html"), System.Text.Encoding.UTF8).Replace("\"", "\'").Replace("\n", "\0");
            }
            return ActicleInfo;
        }

        public static string SetActicleContain(PostActicleDTO dto)
        {
            try
            {
                var db=new myblogEntities();
                var update = (from val in db.mix_acticle where val.ActicleID == dto.PostActicleID select val).FirstOrDefault();
                var path = System.Web.HttpContext.Current.Server.MapPath(@"~/ActicleFiles/" + dto.PostActicleID + ".html").Replace(@"\", @"/");
                dto.PostContainText = Microsoft.JScript.GlobalObject.unescape(dto.PostContainText);
                System.IO.File.WriteAllText(path, dto.PostContainText, System.Text.Encoding.UTF8);

                update.ActicleContain = dto.PostActicleID + ".html";
                update.ActicleAbstract = dto.PostActicleAbstract.Replace(@"'", @"\'");
                db.SaveChanges();
            }
            catch
            {
                return "failed";
            }
            return "success";
        }
    }
}