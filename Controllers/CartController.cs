using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using DoAnLTWEB.Models;
namespace DoAnLTWEB.Controllers
{
    public class CartController : Controller
    {

        public ActionResult Index()
        {
            QLShopEntities db = new QLShopEntities();
            
            return View(db.SanPham.ToList());
            
        }
        public ActionResult AddToCard(int id)
        {
            QLShopEntities db = new QLShopEntities();
            if (Session["cart"]==null)
            {
                List<GioHang> cart = new List<GioHang>();
                cart.Add(new GioHang { SanPham1 = db.SanPham.Single(p=>p.Id==id), SoLuong = 1 });
                Session["cart"] = cart;

            }
            else
            {
                List<GioHang> cart = (List<GioHang>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].SoLuong++;
                }
                else
                {
                    cart.Add(new GioHang { SanPham1 = db.SanPham.Single(p=>p.Id==id), SoLuong = 1 });
                }
                Session["cart"] = cart;
            }
            
            return RedirectToAction("Index");
        }
        public ActionResult Remove(int id)
        {
            List<GioHang> cart = (List<GioHang>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }
        public ActionResult CheckOut()
        {
            return View();
        }

        private int isExist(int id)
        {
            List<GioHang> cart = (List<GioHang>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].SanPham1.Id.Equals(id))
                    return i;
            return -1;
        }
    }
 }