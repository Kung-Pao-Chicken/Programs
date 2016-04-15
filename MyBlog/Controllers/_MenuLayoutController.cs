using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Bases.BlogBases;

namespace MyBlog.Controllers.BlogControllers
{
    public class _MenuLayoutController : Controller
    {
        /// <summary>
        /// 分部视图Menu部分，获取导航列表
        /// </summary>
        /// <returns></returns>
        public ActionResult _MenuLayout()
        {
            var menu = LayoutBase.GetMenu();
            foreach (var i in menu)
            {
                ViewBag.Menu += string.Format("<h3>{0}</h3><ul>", i.CatName);
                ViewBag.Menu += "</ul>";
                foreach (var k in i.SubMenuItems)
                {
                    ViewBag.Menu += string.Format("<li><a href='/MyBlog/List/{0}'>{1} ({2})</a></li>",
                    k.CatContentID,
                    k.CatcontentName,
                    k.ActicleCount);
                }
            }
            return PartialView();
        }

    }
}
