using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Bases;
using MyBlog.Bases.AdminBases;
using MyBlog.DTOs.AdminDTOs;

namespace MyBlog.Controllers
{
    public class MyAdminController : Controller
    {
        /// <summary>
        /// 项目管理页
        /// </summary>
        /// <returns></returns>
        public ActionResult Project()
        {
            string listtemplate = "<tr class='listitem' tag='{0}'><td class='catname'>{1}</td><td>{2}</td><td class='listitemoption'><a class='option' id='update' href='#'>修改</a><a class='option' id='delete' href='#'>删除</a></td></tr>";
            var CategoryList = ProjectBase.GetCategoryList();
            foreach (var i in CategoryList)
            {
                ViewBag.CategoryList += string.Format(listtemplate, i.CatID, i.CatName, i.CatID);
            }
            return View();
            
        }
        /// <summary>
        /// 项目管理提交
        /// </summary>
        /// <returns></returns>
        public EmptyResult ProjectPost()
        {
            var PostDTO = new DTOs.AdminDTOs.PostProjectDTO()
            {
                Option = Request.Form["option"],
                PostCatID = CommonBase.ToInt(Request.Form["catid"]),
                PostCatName = Request.Form["catname"]
            };
            var result = ProjectBase.SetCategory(PostDTO);
            Response.Write(result);
            return new EmptyResult();
        }
        /// <summary>
        /// 栏目管理页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Category(int id)
        {
            var CatContentList = CategoryBase.GetCatContentList(id);
            var listtemplate = "<tr class='listitem' tag='{0}'><td>{1}</td><td class='catcontentname'>{2}</td><td class='catcontentlogo'><img class='logo' src='{3}'/></td><td class='listitemoption'><a class='option' id='delete' href='#'>删除</a><a class='option' id='update' href='#'>修改</a></td></tr>";
            var CatList = CategoryBase.GetCategoryItems();
            ViewBag.HeadTitle = CategoryBase.GetHeadTitle(id);
            ViewBag.CatID = id;
            foreach(var i in CatContentList){
                ViewBag.CatContentList += string.Format(listtemplate, i.CatContentID, i.CatContentID, i.CatContentName, i.CatContentLogoURL);
            }
            foreach (var i in CatList)
            {
                ViewBag.SelectBox += "<option>" + i + "</option>";
            }
            ViewBag.SelectBox = "<select class='catidtext' id='catidtext'>" + ViewBag.SelectBox + "</select>";
            return View();
        }
        /// <summary>
        /// 栏目管理提交
        /// </summary>
        /// <returns></returns>
        public EmptyResult CategoryPost()
        {
            var PostDTO = new DTOs.AdminDTOs.PostCatContentDTO()
            {
                Option = Request.Form["option"],
                PostCatID = CommonBase.ToInt(Request.Form["catid"]),
                PostCatContentID = CommonBase.ToInt(Request.Form["catcontentid"]),
                PostCatContentName = Request.Form["catcontentname"]
            };
            var result = CategoryBase.SetCatContent(PostDTO);
            
            Response.Write(result);
            return new EmptyResult();
        }

        public ActionResult CatContent(int? id)
        {
            string listtemplate = "<tr class='listitem' tag='{0}'><td>{1}</td><td class='listitemacticletitle'>{2}</td><td class='listitemacticlecopyright'>{3}</td><td class='listitemoption'><a class='option' id='update' href='#'>修改</a><a class='option' id='edit' href='/MyAdmin/Acticle/{4}'>编辑</a><a class='option' id='delete' href='#'>删除</a></td></tr>";
            var ActicleList = CatContentBase.GetActicleList(id);
            var CatContentList = CatContentBase.GetCatContentList();
            foreach (var i in ActicleList)
            {
                ViewBag.ActicleList += string.Format(listtemplate, i.ActicleID, i.ActicleID, i.ActicleTitle, i.ActicleCopyright, i.ActicleID);
            }
            foreach (var i in CatContentList)
            {
                ViewBag.SelectBox += "<option>" + i + "</option>";
            }
            ViewBag.SelectBox = "<select class='catcontentidtext' id='catcontentidtext'>" + ViewBag.SelectBox + "</select>";
            ViewBag.CatContentID = id;
            ViewBag.CatContentName = CatContentBase.GetCatContentName(id);
            return View();
        }

        /// <summary>
        /// 文章管理提交
        /// </summary>
        /// <returns></returns>
        public EmptyResult CatContentPost()
        {
            var PostDTO=new DTOs.AdminDTOs.PostCatContentItemDTO(){
                Option = Request.Form["option"],
                PostActicleID = CommonBase.ToInt(Request.Form["acticleid"]),
                PostActicleCopyright = Request.Form["acticlecopyright"],
                PostActicleTitle = Request.Form["acticletitle"],
                PostCatContentID = CommonBase.ToInt(Request.Form["catcontentid"]),
            };
            var result = Bases.AdminBases.CatContentBase.SetActicle(PostDTO);
            Response.Write(result);
            return new EmptyResult();
        }

        /// <summary>
        /// 文章内容管理
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Acticle(int id)
        {
            var ActicleInfo = ActicleBase.GetActicleContent(id);
            ViewBag.ActicleTitle = ActicleInfo.ActicleTitle;
            ViewBag.ActicleContent = ActicleInfo.ActicleContain;
            ViewBag.ActicleID = ActicleInfo.ActicleID;
            return View();
        }

        /// <summary>
        /// 文章内容提交
        /// </summary>
        /// <returns></returns>
        public EmptyResult ActiclePost()
        {
            var PostDTO = new DTOs.AdminDTOs.PostActicleDTO()
            {
                PostActicleID = CommonBase.ToInt(Request.Form["acticleid"]),
                PostActicleAbstract = Request.Form["abstract"],
                PostContainText = Request.Form["contain"],
            };
            var result = ActicleBase.SetActicleContain(PostDTO);
            Response.Write(result);
            return new EmptyResult();
        }
    }
}
