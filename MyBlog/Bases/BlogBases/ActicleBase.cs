using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.DTOs.BlogDTOs;
using MyBlog.Entities;

namespace MyBlog.Bases.BlogBases
{
    public class ActicleBase
    {
        /// <summary>
        /// 获取文章内容
        /// </summary>
        /// <param name="id">int:文章ID</param>
        /// <returns></returns>
        public static byte[] GetActicleContain(int id)
        {
            var Acticle = (from val in new myblogEntities().mix_acticle where val.ActicleID == id select val).First();
            var path = System.Web.HttpContext.Current.Server.MapPath("~/ActicleFiles/" + Acticle.ActicleContain);
            return System.IO.File.ReadAllBytes(path);
        }
        /// <summary>
        /// 获取文章的DTO对象
        /// </summary>
        /// <param name="id">int:文章ID</param>
        /// <returns></returns>
        public static ActicleDTO GetActicleInfo(int id)
        {
            var Acticle = (from val in new myblogEntities().mix_acticle where val.ActicleID == id select val).First();
            var ActicleContent = new ActicleDTO()
            {
                ActicleTitle = Acticle.ActicleTitle,
                ActicleCopyright = Acticle.ActicleCopyright,
                ActicleDate = Acticle.ActicleDate,
                ActicleContain = Acticle.ActicleContain
            };
            return ActicleContent;
        }
    }
}