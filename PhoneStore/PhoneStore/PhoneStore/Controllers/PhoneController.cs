using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Windows.Documents;
using PhoneStore.Models;

namespace PhoneStore.Controllers
{
    public class PhoneController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Phone
        public ActionResult Index()
        {
            List<Phone> listPhone= dbContext.Phones.ToList();
            return View(listPhone);
        }
        public ActionResult Index1()
        {
            List<Phone> listPhone = dbContext.Phones.ToList();
            return View(listPhone);
        }
        public ActionResult SortPriceDescending()
        {
            List<Phone> listPhone = dbContext.Phones.OrderByDescending(m=>m.Price).ToList();
            return View(listPhone);
        }
        public ActionResult SortPriceIncreasing()
        {
            List<Phone> listPhone = dbContext.Phones.OrderBy(m => m.Price).ToList();
            return View(listPhone);
        }
        public ActionResult SortNameDescending()
        {
            List<Phone> listPhone = dbContext.Phones.OrderByDescending(m => m.PhoneName).ToList();
            return View(listPhone);
        }
        public ActionResult SortNameIncreasing()
        {
            List<Phone> listPhone = dbContext.Phones.OrderBy(m => m.PhoneName).ToList();
            return View(listPhone);
        }
        public ActionResult FindPhoneName(string phoneName)
        {
            var results = dbContext.Phones.Where(p => p.PhoneName.Contains(phoneName)).ToList();
            return View(results);
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = dbContext.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }
        private int isExist(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Phone.PhoneID.Equals(id))
                    return i;
            return -1;
        }

        public ActionResult UpdateCart()
        {
            int PhoneID = int.Parse(Request.Form["PhoneID"]);
            int Quantity = int.Parse(Request.Form["Quantity"]);

            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(PhoneID);
            if (index != -1)
            {
                cart[index].Quantity = Quantity;
            }
            Session["cart"] = cart;
            return RedirectToAction("ViewCart");
        }

        public ActionResult AddCart(int id)
        {
            Phone phone = dbContext.Phones.Find(id);
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Phone = phone, Quantity = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Phone = phone, Quantity = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }

        public ActionResult ViewCart()
        {

            return View();
        }
        public ActionResult Remove(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);

            if (cart[index].Quantity >= 2)
            {
                cart[index].Quantity--;
            }
            else
            {
                cart.RemoveAt(index);
            }
            Session["cart"] = cart;
            return RedirectToAction("ViewCart");
        }

        public ActionResult RemoveAll()
        {
            List<Item> cart = (List<Item>)Session["cart"];
            if (cart.Count > 0)
            {
                cart.Clear();
            }
            Session["cart"] = cart;
            return RedirectToAction("ViewCart");
        }
        /* public ActionResult Create()
         {
             ViewBag.ManufacturerID = new SelectList(dbContext.Manufacturers, "ManufacturerID", "ManufacturerName");
             return View();
         }
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Create([Bind(Include = "PhoneID,PhoneName,Price,PhoneImg,ManufacturerID")] Phone phone, HttpPostedFileBase PhoneImg)
         {
             if (ModelState.IsValid)
             {
                 if (PhoneImg != null && PhoneImg.ContentLength > 0)
                     try
                     {  //Server.MapPath takes the absolte path of folder 'Uploads'
                         string path = Path.Combine(Server.MapPath("/Content/Image/"),
                                        Path.GetFileName(PhoneImg.FileName));
                         //Save file using Path+fileName take from above string
                         PhoneImg.SaveAs(path);
                         ViewBag.Message = "File uploaded successfully";
                     }
                     catch (Exception ex)
                     {
                         ViewBag.Message = "ERROR:" + ex.Message.ToString();
                     }
                 else
                 {
                     ViewBag.Message = "You have not specified a file.";
                 }

                 // Lưu sách vào db
                 // Lưu hình vào sever
                 phone.PhoneImg = "/Content/Image/" + Path.GetFileName(PhoneImg.FileName);
                 dbContext.Phones.Add(phone);
                 dbContext.SaveChanges();
                 return RedirectToAction("Index");
             }

             ViewBag.ManufacturerID = new SelectList(dbContext.Manufacturers, "ManufacturerID", "ManufacturerName", phone.ManufacturerID);

             return View(phone);
         }
         public ActionResult Edit(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Phone phone = dbContext.Phones.Find(id);
             if (phone == null)
             {
                 return HttpNotFound();
             }
             dbContext.Phones.Remove(phone);
             dbContext.SaveChanges();
             ViewBag.ManufacturerID = new SelectList(dbContext.Manufacturers, "ManufacturerID", "ManufacturerName", phone.ManufacturerID);
             return View(phone);
         }
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Edit([Bind(Include = "PhoneID,PhoneName,Price,PhoneImg,ManufacturerID")] Phone phone)
         {
             if (ModelState.IsValid)
             {

                 dbContext.Entry(phone).State = EntityState.Modified;
                 dbContext.SaveChanges();
                 return RedirectToAction("Index");
             }
             ViewBag.ManufacturerID = new SelectList(dbContext.Manufacturers, "ManufacturerID", "ManufacturerName", phone.ManufacturerID);
             return View(phone);
         }
         public ActionResult Delete(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Phone phone = dbContext.Phones.Find(id);
             if (phone == null)
             {
                 return HttpNotFound();
             }
             return View(phone);
         }

         // POST: AdminPhoneStore/Phones/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public ActionResult DeleteConfirmed(int id)
         {
             Phone phone = dbContext.Phones.Find(id);
             dbContext.Phones.Remove(phone);
             dbContext.SaveChanges();
             return RedirectToAction("Index");
         }*/
    }
}