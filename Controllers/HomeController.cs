using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnLTWEB.Models;
namespace DoAnLTWEB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int page=1)
        { 
            QLShopEntities db = new QLShopEntities();
            List<KhuyenMai> sp = db.KhuyenMai.ToList();
            //Page
            int NumberPage =10;
            int TotalPage = Convert.ToInt32(Math.Ceiling((double)sp.Count / Convert.ToDouble(NumberPage)));
            int Start = (page - 1) * NumberPage;
            int End = page * NumberPage;
            if (End > sp.Count)
            {
                End = sp.Count;
            }
            ViewBag.Start = Start;
            ViewBag.End = End;
            ViewBag.TotalPage = TotalPage;
            ViewBag.Page = page;
            sp = sp.Skip(Start).Take(NumberPage).ToList();
            //End Page
            return View(sp);
        }
    }
}