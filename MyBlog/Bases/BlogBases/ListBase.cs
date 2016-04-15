using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.DTOs.BlogDTOs;
using MyBlog.Entities;

namespace MyBlog.Bases.BlogBases
{
    public class ListBase
    {
        /// <summary>
        /// 获取栏目名称
        /// </summary>
        /// <param name="id">栏目ID</param>
        /// <returns></returns>
        public static string GetCatContentName(int id)
        {
            var t_mix_categorycontent = new myblogEntities().mix_categorycontent;
            return (from val in t_mix_categorycontent where val.CatContentID == id select val).First().CatContentName;
        }
        /// <summary>
        /// 获取列表页的文章列表DTO对象
        /// </summary>
        /// <param name="topic">string:栏目名称</param>
        /// <returns></returns>
        public static List<ListItemDTO> GetActicleList(int id)
        {
            var t_mix_categorycontent = new myblogEntities().mix_categorycontent;
            var topicid = (from val in t_mix_categorycontent where val.CatContentID == id select val).First().CatContentID;
            var t_mix_acticle = from val in new myblogEntities().mix_acticle where val.CatContentID == topicid select val;
            var acticlelist = new List<ListItemDTO>();

            foreach (var i in t_mix_acticle)
            {
                acticlelist.Add(new ListItemDTO() { ActicleDate = i.ActicleDate, ActicleID = i.ActicleID, ActicleTitle = i.ActicleTitle });
            }
            return acticlelist;
        }
    }
}