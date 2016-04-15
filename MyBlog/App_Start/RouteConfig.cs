using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //logo
            routes.MapRoute(
                name: "Image",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "API", action = "Image", id = UrlParameter.Optional }
            );
            //首页
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "MyBlog", action = "Index" }
            );
            //列表页
            routes.MapRoute(
                name: "List",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MyBlog", action = "List", id = UrlParameter.Optional }
            );
            //文章页
            routes.MapRoute(
                name: "ActicleContent",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MyBlog", action = "Acticles", id = UrlParameter.Optional }
            );
            //文章内容
            routes.MapRoute(
                name: "ActicleContain",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MyBlog", action = "ActicleContain", id = UrlParameter.Optional }
            );


            //后台首页-项目管理页
            routes.MapRoute(
                name: "AdminProject",
                url: "{controller}/{action}",
                defaults: new { controller = "MyAdmin", action = "Project" }
            );
            //项目设置Post位置
            routes.MapRoute(
                name: "AdminProjectPost",
                url: "{controller}/{action}",
                defaults: new { controller = "MyAdmin", action = "ProjectPost" }
            );
            //栏目管理页
            routes.MapRoute(
                name: "AdminCategory",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MyAdmin", action = "Category", id = UrlParameter.Optional }
            );
            //栏目管理页提交
            routes.MapRoute(
                name: "AdminCategoryPost",
                url: "{controller}/{action}",
                defaults: new { controller = "MyAdmin", action = "CategoryPost" }
            );
            //文章管理页
            routes.MapRoute(
                name: "AdminCatContentActicle",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MyAdmin", action = "CatContent", id = UrlParameter.Optional }
            );
            //文章管理页-不指定ID
            routes.MapRoute(
                name: "AdminCatContentNone",
                url: "{controller}/{action}",
                defaults: new { controller = "MyAdmin", action = "CatContent" }
            );
            //文章内容编辑
            routes.MapRoute(
                name: "AdminActicleContent",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MyAdmin", action = "Acticle" ,id=UrlParameter.Optional }
            );
        }
    }
}