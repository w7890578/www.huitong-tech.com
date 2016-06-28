using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Business.BLL;

namespace HuiTong.Controllers
{
    public class HomeIndex
    {
        public List<Article> Plans = new List<Article>();
        public List<Article> Products = new List<Article>();
        public List<Article> News = new List<Article>();
        public List<Article> PlansTwo = new List<Article>();

    }

    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            HomeIndex home = new HomeIndex();
            home.Products = ArticleBLL.Instance.Where(@"ParentID=@ParentID and IsHomeShow=@IsHomeShow 
and State=1").Parms(1, true).List0(1, 4);
            home.Plans = ArticleBLL.Instance.Where(@"ParentID=@ParentID 
            and IsHomeShow=@IsHomeShow and State=1").Parms(2, true).List0(1, 2);
            home.News = ArticleBLL.Instance.Where(@"ParentID=@ParentID 
            and IsHomeShow=@IsHomeShow and State=1").Parms(7, true).List0(1, 2);
            home.PlansTwo = ArticleBLL.Instance.Where(@"ParentID=@ParentID 
            and IsHomeShow=@IsHomeShow and State=1").Parms(2, true).List0(1, 6);
            return View(home);
        }

        public PartialViewResult Master()
        {
            List<Business.Article> list = ArticleBLL.Instance.Where("state=1").OrderBy("ID ASC").ListAll();
            return PartialView(list);
        }
        public PartialViewResult Top(int ParentID)
        {
            List<Business.Article> list = ArticleBLL.Instance.Where("state=1").OrderBy("ID ASC").ListAll();
            ViewBag.Entity = ArticleBLL.Instance.Where("ID=@ID").Parms(ParentID).Get();
            return PartialView(list);
        }

        public PartialViewResult TopForDetail(int ParentID)
        {
            List<Business.Article> list = ArticleBLL.Instance.Where("state=1").OrderBy("ID ASC").ListAll();
            ViewBag.Entity = ArticleBLL.Instance.Where("ID=@ID").Parms(ParentID).Get();
            return PartialView(list);
        }
        public PartialViewResult TopForHome()
        {
            List<Business.Article> list = ArticleBLL.Instance.Where("state=1").OrderBy("ID ASC").ListAll();
            return PartialView(list);
        }

        public PartialViewResult Foot()
        {
            return PartialView();
        }

        public PartialViewResult List(int ParentID, string Title = "")
        {

            ORM.BLL<Article>.Query q = ArticleBLL.Instance.Where("state=1 and ParentID=@ParentID").Parms(ParentID);
            if (!string.IsNullOrEmpty(Title))
            {
                q = q.Where("TiTle like '%" + Title + "%'");
            }
            List<Business.Article> list = q.OrderBy("ID ASC").ListAll();
            ViewBag.Entity = ArticleBLL.Instance.Where("state=1 and ID=@ID")
                .Parms(ParentID).Get();
            return PartialView(list);
        }


        public PartialViewResult ListForNews(int ParentID, string Title = "")
        {

            ORM.BLL<Article>.Query q = ArticleBLL.Instance.Where("state=1 and ParentID=@ParentID").Parms(ParentID);
            if (!string.IsNullOrEmpty(Title))
            {
                q = q.Where("TiTle like '%" + Title + "%'");
            }
            List<Business.Article> list = q.OrderBy("ID ASC").ListAll();
            ViewBag.Entity = ArticleBLL.Instance.Where("state=1 and ID=@ID")
                .Parms(ParentID).Get();
            return PartialView(list);
        }

        public PartialViewResult Detail(int ID, int ParentID)
        {
            ORM.BLL<Article>.Query q = ArticleBLL.Instance.Where("state=1 and ParentID=@ParentID").Parms(ParentID);
            List<Business.Article> list = q.OrderBy("ID ASC").ListAll();


            Article model = ArticleBLL.Instance.Where("state=1 and ID=@ID").Parms(ID).Get();

            ViewBag.Entity = ArticleBLL.Instance.Where("state=1 and ID=@ID")
                .Parms(ParentID).Get();
            ViewBag.Text = model.Text;
            return PartialView(list);
        }

    }
}
