using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.Entities;
using MyBlog.DTOs.BlogDTOs;

namespace MyBlog.Bases.BlogBases
{
    public class IndexBase
    {
        /// <summary>
        /// 获取首页最新文章
        /// </summary>
        /// <param name="count">int:显示的条数</param>
        /// <returns></returns>
        public static List<IndexActicleDTO> GetIndexActicleList(int count)
        {
            var t_mix_categorycontent = from val in new myblogEntities().mix_categorycontent select val;
            var t_mix_acticle = from val in new myblogEntities().mix_acticle orderby val.ActicleDate descending select val;
            var cx = 0;
            var indexacticle=new List<IndexActicleDTO>();
            foreach (var i in t_mix_acticle)
            {
                var item=new IndexActicleDTO();
                item.CatContentLogoURL = "/APIs/Image/"+i.CatContentID;
                item.CatContentID = i.CatContentID;
                item.ActicleID = i.ActicleID;
                item.ActicleTitle = i.ActicleTitle;
                item.ActicleDate = i.ActicleDate;
                item.ActicleAbstract = i.ActicleAbstract;
                indexacticle.Add(item);
                if (cx >= count-1)
                {
                    break;
                }
                else
                {
                    cx++;
                }
            }
            return indexacticle;
        }
    }
}