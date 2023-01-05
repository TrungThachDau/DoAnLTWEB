using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using DoAnLTWEB.Models;
namespace DoAnLTWEB.Controllers
{
    public class CollectionController : Controller
    {
        // GET: Collection
        public ActionResult Index(string search="", string SortColumn="Id", int loai=0,int page=1)
        {
            QLShopEntities db = new QLShopEntities();
            List<SanPham> sp = db.SanPham.Where(row=>row.Ten.Contains(search)).ToList();
            switch(SortColumn)
            {
                case "PriceMax":
                    sp = sp.OrderByDescending(row=>row.Gia).ToList();
                    break;
                case "PriceMin":
                    sp = sp.OrderBy(row=>row.Gia).ToList();
                    break;
                case "AtoZ":
                    sp = sp.OrderBy(row=>row.Ten).ToList();
                    break;
                case "ZtoA":
                    sp = sp.OrderByDescending(row=>row.Ten).ToList();
                    break;
                case "New":
                    sp = sp.OrderByDescending(row=>row.Id).ToList();
                    break;
            }
            if(loai==1)
            {
                List<SanPham> ao = db.SanPham.Where(a => a.LoaiSP_ID==1).ToList();
                return View(ao);
            }
            else if(loai==2)
            {
                List<SanPham> quan = db.SanPham.Where(q => q.LoaiSP_ID == 2).ToList();
                return View(quan);
            }
            else if (loai == 3)
            {
                List<SanPham> pk = db.SanPham.Where(p => p.LoaiSP_ID == 3).ToList();
                return View(pk);
            }
            int NumberPage = 8;
            int TotalPage = Convert.ToInt32(Math.Ceiling((double)sp.Count / Convert.ToDouble(NumberPage)));
            int Start = (page - 1) * NumberPage;
            int End = TotalPage;
            ViewBag.Start = Start;
            ViewBag.End = End;
            ViewBag.TotalPage = TotalPage;
            ViewBag.Page = page;
            sp = sp.Skip(Start).Take(NumberPage).ToList();
            //End Page
            return View(sp);
        }
        public ActionResult Tee(int page=1)
        {
            QLShopEntities db = new QLShopEntities();
            List<SanPham> sp = db.SanPham.Where(row => row.Kieu == "Tee").ToList();
            int NumberPage = 8;
            int TotalPage = Convert.ToInt32(Math.Ceiling((double)sp.Count / Convert.ToDouble(NumberPage)));
            int Start = (page - 1) * NumberPage;
            int End = TotalPage;
            ViewBag.Start = Start;
            ViewBag.End = End;
            ViewBag.TotalPage = TotalPage;
            ViewBag.Page = page;
            sp = sp.Skip(Start).Take(NumberPage).ToList();
            return View(sp);
        }
        public ActionResult Polo(int page=1)
        {
            QLShopEntities db = new QLShopEntities();
            List<SanPham> sp = db.SanPham.Where(row => row.Kieu == "Polo").ToList();
            int NumberPage = 8;
            int TotalPage = Convert.ToInt32(Math.Ceiling((double)sp.Count / Convert.ToDouble(NumberPage)));
            int Start = (page - 1) * NumberPage;
            int End = TotalPage;
            ViewBag.Start = Start;
            ViewBag.End = End;
            ViewBag.TotalPage = TotalPage;
            ViewBag.Page = page;
            sp = sp.Skip(Start).Take(NumberPage).ToList();
            return View(sp);
        }
        public ActionResult Hoodie(int page=1)
        {
            QLShopEntities db = new QLShopEntities();
            List<SanPham> sp = db.SanPham.Where(row => row.Kieu == "Hoodie").ToList();

            int NumberPage = 8;
            int TotalPage = Convert.ToInt32(Math.Ceiling((double)sp.Count / Convert.ToDouble(NumberPage)));
            int Start = (page - 1) * NumberPage;
            int End = TotalPage;
            ViewBag.Start = Start;
            ViewBag.End = End;
            ViewBag.TotalPage = TotalPage;
            ViewBag.Page = page;
            sp = sp.Skip(Start).Take(NumberPage).ToList();
            return View(sp);
        }
        public ActionResult Shorts(int page=1)
        {
            QLShopEntities db = new QLShopEntities();
            List<SanPham> sp = db.SanPham.Where(row => row.Kieu == "Shorts").ToList();

            int NumberPage = 8;
            int TotalPage = Convert.ToInt32(Math.Ceiling((double)sp.Count / Convert.ToDouble(NumberPage)));
            int Start = (page - 1) * NumberPage;
            int End = TotalPage;
            ViewBag.Start = Start;
            ViewBag.End = End;
            ViewBag.TotalPage = TotalPage;
            ViewBag.Page = page;
            sp = sp.Skip(Start).Take(NumberPage).ToList();
            return View(sp);
        }
        public ActionResult Pants(int page = 1)
        {
            QLShopEntities db = new QLShopEntities();
            List<SanPham> sp = db.SanPham.Where(row => row.Kieu == "Pants").ToList();

            int NumberPage = 8;
            int TotalPage = Convert.ToInt32(Math.Ceiling((double)sp.Count / Convert.ToDouble(NumberPage)));
            int Start = (page - 1) * NumberPage;
            int End = TotalPage;
            ViewBag.Start = Start;
            ViewBag.End = End;
            ViewBag.TotalPage = TotalPage;
            ViewBag.Page = page;
            sp = sp.Skip(Start).Take(NumberPage).ToList();
            return View(sp);
        }
        public ActionResult Accessory(int page = 1)
        {
            QLShopEntities db = new QLShopEntities();
            List<SanPham> sp = db.SanPham.Where(row => row.Kieu == "Phụ kiện").ToList();

            int NumberPage = 8;
            int TotalPage = Convert.ToInt32(Math.Ceiling((double)sp.Count / Convert.ToDouble(NumberPage)));
            int Start = (page - 1) * NumberPage;
            int End = TotalPage;
            ViewBag.Start = Start;
            ViewBag.End = End;
            ViewBag.TotalPage = TotalPage;
            ViewBag.Page = page;
            sp = sp.Skip(Start).Take(NumberPage).ToList();
            return View(sp);
        }
    

        public ActionResult Detail(int id)
        {
            QLShopEntities db = new QLShopEntities();
            SanPham sp = db.SanPham.Where(row => row.Id == id).FirstOrDefault();
            return View(sp);

        }
    }
}