using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Business.BLL;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace HuiTong.Controllers
{
    [Authorization]
    public class AdminController : BaseController
    {
        //
        // GET: /Admin/
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View("Index");
        }
        [AllowAnonymous]
        public ActionResult LoginCheck()
        {
            string msg = string.Empty;
            string userName = Request["UserName"] ?? "";
            string pwd = Request["Pwd"] ?? "";
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(pwd))
            {
                if (userName != "admin" || pwd != "admin")
                {
                    msg = "用户名或密码错误";
                }
                else
                {
                    HttpCookie authCookie = new HttpCookie("LoginedUser", userName);
                    authCookie.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(authCookie);
                    Response.Redirect("/Admin/Main");
                }
            }
            else
            {
                msg = "请输入用户名和密码";
            }
            ViewBag.Msg = msg;
            ViewBag.UserName = userName;
            ViewBag.Pwd = pwd;
            return View("Index");
        }


        public ActionResult Main()
        {
            return View();
        }

        public ActionResult Article(Article entity)
        {
            List<Article> items = new List<Business.Article>();
            List<object> parms = new List<object>();
            string condition = " state=1 ";
            if (!string.IsNullOrEmpty(entity.Title))
            {
                condition += " and Title=@Title";
                parms.Add(entity.Title);
            }
            if (entity.ParentID != 0)
            {
                condition += " and ParentID=@ParentID";
                parms.Add(entity.ParentID);
                ViewBag.Title = ArticleBLL.Instance.Where("ID=@ID").Parms(entity.ParentID).Get() == null ? "" :
                ArticleBLL.Instance.Where("ID=@ID").Parms(entity.ParentID).Get().Title;
                ViewBag.ParentEntity = ArticleBLL.Instance.Where("ID=@ID").Parms(entity.ParentID).Get();
            }
            //ArticleBLL.Instance.Where(condition).Parms(parms.ToArray())
            //    .OrderBy(entity.SortColumName + " " + entity.SortRule).List0(items, entity.PageIndex, entity.PageSize);
            items = ArticleBLL.Instance.Where(condition).Parms(parms.ToArray()).OrderBy("CreateTime desc").ListAll();
            ViewBag.Items = items;
            ViewBag.SearchEntity = entity;
            return View();
        }

        public ActionResult ArticleMain()
        {
            List<Article> list = ArticleBLL.Instance.Where("ParentID=0").ListAll();
            return View(list);
        }

        public ActionResult ArticleMainDetail(int ID)
        {
            Article entity = ArticleBLL.Instance.Where("ID=@ID").Parms(ID).Get();
            return View(entity);
        }
        public ActionResult ArticleDetail(Article entity)
        {
            Article ac = new Business.Article();
            ac.ParentID = entity.ParentID;
            if (entity.ID > 0)
            {
                ac = ArticleBLL.Instance.Where("ID=@ID").Parms(entity.ID).Get();
            }
            ViewBag.Entity = ac;
            ViewBag.Msg = "";
            ViewBag.ParentTitle = ArticleBLL.Instance.Where("ID=@ID").Parms(ac.ParentID).Get().Title;
            return View(ac);
        }

        [HttpPost]
        public void ArticleMainUpdate(Article entity)
        {
            string imgFileName = string.Empty;
            string imgUrlName = string.Empty;
            if (Request.Files.Count > 0)
            {
                imgFileName = Request.Files["Description"].FileName;
                imgUrlName = DateTime.Now.ToString("yyyyMMddHHmmss") + System.IO.Path.GetExtension(imgFileName);
            }
            if (!string.IsNullOrEmpty(imgFileName))
            {
                Request.Files["Description"].SaveAs(HttpContext.Server.MapPath("~/Images/Article") + @"\" + imgUrlName);
                entity.Description = "Images/Article" + @"/" + imgUrlName;
            }
            else
            {
                entity.Description = Request["DescriptionShow"];
            }
            ArticleBLL.Instance.Update(entity, new string[] { "Description" });
            Response.Redirect("/Admin/ArticleMain");
        }

        [HttpPost]
        public ActionResult ArticleAdd(Article entity)
        {
            string imgFileName = string.Empty;
            string imgUrlName = string.Empty;
            if (Request.Files.Count > 0)
            {
                imgFileName = Request.Files["ImgUrl"].FileName;
                imgUrlName = DateTime.Now.ToString("yyyyMMddHHmmss") + System.IO.Path.GetExtension(imgFileName);
            }
            List<string> colums = new List<string>() { "ParentID", "TiTle", "Text", "ImgUrl", "IsHomeShow", "Sort" };

            entity.Text = Server.UrlDecode(entity.Text);
            bool result = false;

            if (!string.IsNullOrEmpty(imgFileName))
            {
                Request.Files["ImgUrl"].SaveAs(HttpContext.Server.MapPath("~/Images/Article") + @"\" + imgUrlName);
                entity.ImgUrl = "/Images/Article" + @"/" + imgUrlName;
            }
            else
            {
                entity.ImgUrl = Request["ImgUrlShow"];
            }

            if (entity.ID > 0)
            {
                // colums = new List<string>() { "TiTle", "Text", "ImgUrl", "IsHomeShow", "Sort" };

                result = ArticleBLL.Instance.Update(entity);
            }
            else
            {
                if (string.IsNullOrEmpty(imgFileName))
                {
                    ViewBag.Msg = "请上传图片";
                    ViewBag.Entity = entity;
                    return View("ArticleDetail");
                }
                result = ArticleBLL.Instance.Add(entity);

            }

            if (result)
            {
                Response.Redirect("/Admin/Article?ParentID=" + entity.ParentID);
            }
            else
            {
                ViewBag.Msg = "保存失败！请联系管理员";

            }
            ViewBag.Entity = entity;
            return View("ArticleDetail");
        }

        [HttpPost]
        public ContentResult ArticleDelete(int ID)
        {
            string result = ArticleBLL.Instance.Where("ID=@ID").Parms(ID).Update("State=0") ? "ok" : "no";
            return Content(result, "text/html");
        }

        public ActionResult CompanyInfo()
        {
            CompanyInfo entity = CompanyInfoBLL.Instance.Get();
            entity = entity == null ? new CompanyInfo() : entity;

            ViewBag.Msg = "";
            return View(entity);
        }
        [HttpPost]
        public ActionResult CompanyInfoSave(CompanyInfo entity)
        {
            bool result = false;
            if (entity.ID > 0)
            {
                result = CompanyInfoBLL.Instance.Update(entity);
            }
            else
            {
                result = FunLayer.Transform.Int(CompanyInfoBLL.Instance.Add(entity)) > 0;
            }
            ViewBag.Msg = result ? "保存成功" : "保存失败?请联系管理员";
            return View("CompanyInfo", entity);

        }

        public PartialViewResult Top()
        {
            CompanyInfo entity = CompanyInfoBLL.Instance.Get();
            entity = entity == null ? new CompanyInfo() : entity;

            ViewBag.Msg = "";
            return PartialView(entity);
        }
        [HttpPost]
        public ContentResult CooperationAdd(Cooperation entity)
        {
            entity.Product = Request["Product"];
            string result = entity.Add() ? "提交成功" : "提交失败";
            return Content(result, "text/html");
        }
    }
}
