using DemoCRUD.Models.Dao;
using DemoCRUD.Models.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoCRUD.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        SanPhamDao daoSP = new SanPhamDao();
        // GET: Admin/SanPham
        public ActionResult Index(int? page,int ? pagesize,string SearchString)
        {
            int pageNumber = page ?? 1;
            int pageSize = pagesize ?? 4;
            var lst = daoSP.ListSanPham(pageNumber, pageSize, SearchString);
            return View(lst);
        }
        public void LoadDropdownList()
        {
            List<theloai> lst = db.theloais.ToList();
            ViewBag.danhsach = new SelectList(lst, "maloai", "tenloai");
        }
        public ActionResult Create()
        {
            LoadDropdownList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(sanpham obj,HttpPostedFileBase hinhanh)
        {
            try
            {
                string path = Path.Combine(Server.MapPath("~/Image/"), Path.GetFileName(hinhanh.FileName));
                hinhanh.SaveAs(path);
                obj.hinhanh = hinhanh.FileName;
                daoSP.AddProduct(obj);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            LoadDropdownList();
            return View(daoSP.GetById(id));
        }
        [HttpPost]
        public ActionResult Edit(sanpham obj)
        {
            try
            {
                daoSP.EditProduct(obj);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            daoSP.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}