using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Bases.AdminBases;

namespace MyBlog.Controllers.AdminControllers
{
    public class _AdminMenuLayoutController : Controller
    {
        /// <summary>
        /// 分部视图Menu部分，获取导航列表
        /// </summary>
        /// <returns></returns>
        public ActionResult _AdminMenuLayout()
        {
            var CategoryMenu = AdminLayoutBase.GetCategoryMenu();
            var CatContentMenu = AdminLayoutBase.GetCatContentMenu();
            foreach (var i in CategoryMenu)
            {
                ViewBag.CategoryList += string.Format("<li><a href='/MyAdmin/Category/{0}'>{1}</a></li>", i.CatID, i.CatName);
            }
            foreach (var i in CatContentMenu)
            {
                ViewBag.CatContentList += string.Format("<li><a href='/MyAdmin/CatContent/{0}'>{1}</a>({2})</li>", i.CatContentID, i.CatContentName, i.ActicleCount);
            }
            return PartialView();
        }

    }
}
