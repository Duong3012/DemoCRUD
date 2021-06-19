using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoCRUD.Models.EF;
using PagedList;
using PagedList.Mvc;

namespace DemoCRUD.Models.Dao
{
    public class TheLoaiDao
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public IEnumerable<theloai> ListTheLoai(int page,int pagesize,string searchString)
        {
            IQueryable<theloai> lst = db.theloais;
            if (!string.IsNullOrEmpty(searchString))
            {
                lst = lst.Where(x => x.tenloai.Contains(searchString));
            }
            return lst.OrderByDescending(x => x.tenloai).ToPagedList(page, pagesize);
        }
        public void AddCategory(theloai obj)
        {
            db.theloais.Add(obj);
            db.SaveChanges();
        }
        public theloai GetById(int id)
        {
            return db.theloais.SingleOrDefault(x => x.maloai == id);
        }
        public void EditCategory(theloai obj)
        {
            theloai sua = GetById(obj.maloai);
            sua.tenloai = obj.tenloai;
            sua.mota = obj.mota;
            db.SaveChanges();
        }
        public void DeleteCategory(int id)
        {
            theloai xoa = GetById(id);
            db.theloais.Remove(xoa);
            db.SaveChanges();
        }
    }
}