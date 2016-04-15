using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Bases.BlogBases;

namespace MyBlog.Controllers
{
    public class MyBlogController : Controller
    {
        /// <summary>
        /// 首页Action
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Index()
        {
            var acticlelist = IndexBase.GetIndexActicleList(6);
            string template = "<div class='acticleindex'><div class='indexacticlelogo'><img src='{0}'/></div><div class='indexcontain'><div class='indexacticletitle'><a href='/MyBlog/Acticle/{1}'>{2}</a><span class='indexacticletime' style='float:right;'>{3}</span></div><textarea disabled='disabled' class='acticleabstract'>{4}</textarea></div></div>";
            foreach (var i in acticlelist)
            {
                ViewBag.NewActicleList += string.Format(template,
                    i.CatContentLogoURL,
                    i.ActicleID,
                    i.ActicleTitle,
                    i.ActicleDate,
                    i.ActicleAbstract
                );
            }
            return View();
        }
        /// <summary>
        /// 列表页Action
        /// </summary>
        /// <param name="id">项目的名称，如C#</param>
        /// <returns></returns>
        public ActionResult List(int id)
        {
            ViewBag.Topic = ListBase.GetCatContentName(id);
            string listtemplate = "<div class='listitem'><span class='listitemtitle'><a href=/MyBlog/Acticle/{0}>{1}</a></span><span class='listitemtime'>{2}</span></div>";
            foreach (var i in ListBase.GetActicleList(id))
            {
                ViewBag.ActicleList += string.Format(listtemplate, i.ActicleID, i.ActicleTitle, i.ActicleDate);
            }
            return View();
        }
        /// <summary>
        /// 文章内容页Action
        /// </summary>
        /// <param name="id">文章ID</param>
        /// <returns></returns>
        public ActionResult Acticle(int id)
        {
            var Acticle = ActicleBase.GetActicleInfo(id);
            ViewBag.ActicleTitle = Acticle.ActicleTitle;
            ViewBag.ActicleCopyright = Acticle.ActicleCopyright;
            ViewBag.ActicleContain = "/MyBlog/ActicleContain/"+id;
            ViewBag.ActicleDate = Acticle.ActicleDate;
            return View();
        }

        /// <summary>
        /// 获取文章内容页的文章内容Action
        /// </summary>
        /// <param name="id">int:文章ID</param>
        /// <returns></returns>
        public FileResult ActicleContain(int id)
        {
            return new FileContentResult(ActicleBase.GetActicleContain(id), "text/html");
        }
    }
}
