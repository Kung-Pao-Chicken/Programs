using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.Entities;

namespace MyBlog.Bases
{
    public class CommonBase
    {
        /// <summary>
        /// 获取首页CatContentLogo的图片
        /// </summary>
        /// <param name="id">int:栏目ID</param>
        /// <returns></returns>
        public static byte[] GetImage(int id)
        {
            var t_mix_categorycontent = from val in new myblogEntities().mix_categorycontent select val;
            var t_mix_acticle = from val in new myblogEntities().mix_acticle orderby val.ActicleDate descending select val;
            return (from val in t_mix_categorycontent where val.CatContentID == id select val).First().CatcontentLogo;
        }
        /// <summary>
        /// 将一个字符串转换为数字，失败返回0
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int ToInt(string t)
        {
            int id;
            int.TryParse(t, out id);//这里当转换失败时返回的id为0
            return id;
        }
    }
}