using DemoCRUD.Models.Dao;
using DemoCRUD.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoCRUD.Areas.Admin.Controllers
{
    public class TheLoaiController : Controller
    {
        TheLoaiDao theLoaiDao = new TheLoaiDao();
        // GET: Admin/TheLoai
        public ActionResult Index(int? page,int? pagesize,string searchString)
        {
            int pageNumber = page ?? 1;
            int pageSize = pagesize ?? 4;
            var lst = theLoaiDao.ListTheLoai(pageNumber, pageSize, searchString);
            return View(lst);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(theloai obj)
        {
            try
            {
                theLoaiDao.AddCategory(obj);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            return View(theLoaiDao.GetById(id));
        }
        [HttpPost]
        public ActionResult Edit(theloai obj)
        {
            try
            {
                theLoaiDao.EditCategory(obj);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            theLoaiDao.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}