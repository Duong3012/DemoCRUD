using DemoCRUD.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace DemoCRUD.Models.Dao
{
    public class SanPhamDao
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public IEnumerable<sanpham> ListSanPham(int page,int pageSize,string SearchString)
        {
            IQueryable<sanpham> lst = db.sanphams;
            if (!string.IsNullOrEmpty(SearchString))
            {
                lst = lst.Where(x => x.tensp.Contains(SearchString));
                    
            }
            return lst.OrderByDescending(x => x.tensp).ToPagedList(page, pageSize);
        }
        public sanpham GetById(int id)
        {
            return db.sanphams.SingleOrDefault(x => x.masp == id);
        }
        public void AddProduct(sanpham obj)
        {
   
            db.sanphams.Add(obj);
            db.SaveChanges();
        }
        public void EditProduct(sanpham obj)
        {
            sanpham sua = GetById(obj.masp);
            sua.maloai = obj.maloai;
            sua.tensp = obj.tensp;
            sua.soluong = obj.soluong;
            sua.giatien = obj.giatien;
            sua.hinhanh = obj.hinhanh;
            db.SaveChanges();

        }
        public void DeleteProduct(int id)
        {
            sanpham xoa = GetById(id);
            db.SaveChanges();
        }
    }
}