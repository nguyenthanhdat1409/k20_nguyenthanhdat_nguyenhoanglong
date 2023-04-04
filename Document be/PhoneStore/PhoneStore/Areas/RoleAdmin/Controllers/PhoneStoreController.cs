using PhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PhoneStore.Areas.RoleAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PhoneStoreController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: RoleAdmin/PhoneStore
        /*[Authorize(Roles = "Admin")]*/
        public ActionResult Index()
        {
            List<Phone> listPhone = dbContext.Phones.ToList();
            return View(listPhone);
        }
        public ActionResult Create()
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
            /*dbContext.Phones.Remove(phone);
            dbContext.SaveChanges();*/
            ViewBag.ManufacturerID = new SelectList(dbContext.Manufacturers, "ManufacturerID", "ManufacturerName", phone.ManufacturerID);
            return View(phone);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhoneID,PhoneName,Price,PhoneImg,ManufacturerID")] Phone phone, HttpPostedFileBase PhoneImg)
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

                phone.PhoneImg = "/Content/Image/" + Path.GetFileName(PhoneImg.FileName);
                dbContext.Phones.Remove(phone);
                dbContext.Phones.Add(phone);
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

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phone phone = dbContext.Phones.Find(id);
            dbContext.Phones.Remove(phone);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}