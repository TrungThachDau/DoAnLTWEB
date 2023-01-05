using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnLTWEB.Models;
using System.Web.Helpers;

namespace DoAnLTWEB.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            QLShopEntities db = new QLShopEntities();
            var check = Crypto.VerifyHashedPassword(db.User.Where(row => row.Username == username).FirstOrDefault().Password, password);
            if (check)
            {
                Session["username"] = username;
                ;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Sai tên đăng nhập hoặc mật khẩu";
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session["username"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult Register(User u)
        {
            if (ModelState.IsValid)
            {
                QLShopEntities db = new QLShopEntities();
                var check = db.User.Where(s => s.Username.Equals(u.Username)).FirstOrDefault();
                
                if (check == null)
                {

                    u.Password = Crypto.HashPassword(u.Password);
                    //u.Password = Crypto.SHA256(u.Password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.User.Add(u);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "Tên người dùng đã tồn tại";
                    return View();
                }


            }
            return View();
        }
        public ActionResult CreateItem()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult CreateItem(SanPham sp)
        {
            QLShopEntities db = new QLShopEntities();
            db.SanPham.Add(sp);
            db.SaveChanges();
            return RedirectToAction("Manage");
        }
        public ActionResult Manage(string search2="")
        {
            QLShopEntities db = new QLShopEntities();
            List<SanPham> sp = db.SanPham.Where(s => s.Ten.Contains(search2)).ToList();
            return View(sp);

        }
        public ActionResult Delete(int id)
        {
            QLShopEntities db = new QLShopEntities();
            SanPham sp = db.SanPham.Where(row => row.Id == id).FirstOrDefault();
            return View(sp);
            
        }
        [HttpPost]
        public ActionResult Delete(int id, SanPham s)
        {
            QLShopEntities db = new QLShopEntities();
            SanPham sp = db.SanPham.Where(row => row.Id == id).FirstOrDefault();
            db.SanPham.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Manage");
        }
        public ActionResult Edit(int id)
        {
            QLShopEntities db = new QLShopEntities();
            SanPham sp = db.SanPham.Where(row => row.Id == id).FirstOrDefault();
            return View(sp);
        }
        [HttpPost]
        public ActionResult Edit(SanPham s)
        {
            QLShopEntities db = new QLShopEntities();
            SanPham sp = db.SanPham.Where(row => row.Id == s.Id).FirstOrDefault();
            sp.Ten = s.Ten;
            sp.Gia = s.Gia;
            sp.ThongTin = s.ThongTin;
            sp.LuotMua = s.LuotMua;
            sp.HinhAnh = s.HinhAnh;
            sp.LoaiSP_ID=s.LoaiSP_ID;
            sp.Kieu=s.Kieu;
            db.SaveChanges();
            return RedirectToAction("Manage");
        }
        
       

    }
    
    
}