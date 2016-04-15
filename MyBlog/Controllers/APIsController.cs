using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyBlog.Bases;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class APIsController : Controller
    {
        public Object Image(int id)
        {
            var pic=CommonBase.GetImage(id);
            if(pic == null){
                return new EmptyResult();
            }
            else
            {
                return new FileContentResult(pic, "image/jpeg");
            }
        }
    }
}
